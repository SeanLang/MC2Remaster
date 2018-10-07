using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class UnitDisplayPanelController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public int unitCost;
    public int unitTonnage;
    public string unitName;
    public string iconFileName;
    public Sprite iconSprite;
    public StoreController parentPanel;
    public UnitClass thisPanelUnit;

    public bool notDeployment;
    public Text nameObject;
    public Text costObject;
    public Text tonnageObject;
    public Image iconObject;

    public static GameObject draggedUnit;
    public GameObject canvasTopLayer;
    Vector3 returnPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        draggedUnit = this.gameObject;
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
        gameObject.name = unitName;
        nameObject.text = unitName;
        if (notDeployment == true)
        {
            costObject.text = unitCost.ToString();
            tonnageObject.text = unitTonnage.ToString();
        }
        iconObject.sprite = Resources.Load<Sprite>("UnitIcons/Units/" + iconFileName);
        returnPosition = transform.localPosition;

    }

    public void RemoveFromInventory()
    {
        parentPanel.selectedIcon = gameObject;
    }

    void Update () {
		
	}
}
