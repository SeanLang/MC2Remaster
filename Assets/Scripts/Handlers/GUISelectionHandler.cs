using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUISelectionHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {

    [SerializeField]
    private LayerMask mLayerMask;

    [SerializeField]
    private RectTransform selectionBoxSprite;

    public GameObject[] allGameObjects;

    private Vector3 initialPos = Vector3.zero;
    private Vector2 currentPos;

    public Material assignedMaterial;
    public Material highlightedMaterial;
    public Material selectedMaterial;

    [System.NonSerialized]
    public List<GameObject> selectedGameObjects = new List<GameObject>();

    GameObject highlightedGameObject;

    private bool downPointerOnGUI = false;

    float clickDelay = 0.3f;
    float clickTime = 0f;

    Vector3 topLeft, topRight, bottomLeft, bottomRight;

    void Start()
    {
        this.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        selectionBoxSprite.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!downPointerOnGUI)
        {
            HighlightGameObject();

            dragSelector();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downPointerOnGUI = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downPointerOnGUI = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    void dragSelector()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mLayerMask))
            {
                initialPos = hit.point;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (initialPos != Vector3.zero)
            {
                if (!selectionBoxSprite.gameObject.activeInHierarchy)
                {
                    selectionBoxSprite.gameObject.SetActive(true);
                }

                Vector3 startScreen = Camera.main.WorldToScreenPoint(initialPos);
                RaycastHit hit;

                currentPos = Input.mousePosition;

                Vector3 endPos = new Vector3(currentPos.x, currentPos.y, 0f);
                Vector3 center = (startScreen + endPos) / 2f;

                selectionBoxSprite.position = center;

                float sizeX = Mathf.Abs(startScreen.x - currentPos.x);
                float sizeY = Mathf.Abs(startScreen.y - currentPos.y);

                selectionBoxSprite.sizeDelta = new Vector2(sizeX, sizeY);

                topLeft = new Vector3(center.x - sizeX / 2f, center.y + sizeY / 2f, 0f);
                topRight = new Vector3(center.x + sizeX / 2f, center.y + sizeY / 2f, 0f);
                bottomLeft = new Vector3(center.x - sizeX / 2f, center.y - sizeY / 2f, 0f);
                bottomRight = new Vector3(center.x + sizeX / 2f, center.y - sizeY / 2f, 0f);

                int i = 0;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(topLeft), out hit, 200f, mLayerMask))
                {
                    topLeft = hit.point;
                    i++;
                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(topRight), out hit, 200f, mLayerMask))
                {
                    topRight = hit.point;
                    i++;
                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(bottomLeft), out hit, 200f, mLayerMask))
                {
                    bottomLeft = hit.point;
                    i++;
                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(bottomRight), out hit, 200f, mLayerMask))
                {
                    bottomRight = hit.point;
                    i++;
                }
            }
            else
            {
                Debug.Log("Ray didn't hit anything?");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectionBoxSprite.gameObject.SetActive(false);
            selectionBoxSprite.anchoredPosition = Vector2.zero;
        }
    }

    void HighlightGameObject()
    {
        if (highlightedGameObject != null)
        {
            bool isSelected = false;

            for (int i = 0; i< selectedGameObjects.Count; i++)
            {
                if (selectedGameObjects[i] == highlightedGameObject)
                {
                    isSelected = true;
                }
            }

            if (!isSelected)
            {
                highlightedGameObject.GetComponent<MeshRenderer>().material = assignedMaterial;
            }

            highlightedGameObject = null;
        }

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f))
        {
            Debug.Log("hit");
            if (hit.collider.CompareTag("SelectableUnit"))
            {
                GameObject currentGameObject = hit.collider.gameObject;

                bool isSelected = false;

                for (int i = 0; i < selectedGameObjects.Count; i++)
                {
                    if (selectedGameObjects[i] == currentGameObject)
                    {
                        isSelected = true;
                        break;
                    }
                }

                if (!isSelected)
                {
                    highlightedGameObject = currentGameObject;
                    highlightedGameObject.GetComponent<MeshRenderer>().material = highlightedMaterial;
                }
            }
        }
    }
}
