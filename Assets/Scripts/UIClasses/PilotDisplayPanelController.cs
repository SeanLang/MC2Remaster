using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class PilotDisplayPanelController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public int unitCost;
    public int unitRank;
    public string pilotName;
    public string iconFileName;
    public Sprite iconSprite;
    public StoreController parentPanel;
    public PilotClass thisPanelPilot;

    public bool notDeployment;
    public Text nameObject;
    public Text costObject;
    public Text rankObject;
    public Image iconObject;

    public static GameObject draggedPilot;
    public GameObject canvasTopLayer;
    Vector3 returnPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        draggedPilot = this.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.SetParent(canvasTopLayer.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Start () {
        gameObject.name = pilotName;
        nameObject.text = pilotName;
        if (notDeployment == true)
        {
            costObject.text = unitCost.ToString();
            rankObject.text = unitRank.ToString();
        }
        iconObject.sprite = Resources.Load<Sprite>("UnitIcons/Mechs/" + iconFileName);
        returnPosition = transform.localPosition;

    }

    public void RemoveFromInventory()
    {
        parentPanel.selectedIcon = gameObject;
    }

    void Update () {
		
	}
}
