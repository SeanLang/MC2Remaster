using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class UnitDisplayPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public int unitCost;
    public int unitTonnage;
    public string unitName;
    public string iconFileName;
    public Sprite iconSprite;
    public StoreController parentPanel;
    public UnitClass thisPanelUnit;

    public Text nameObject;
    public Text costObject;
    public Text tonnageObject;
    public Image iconObject;

    public static GameObject draggedObject;
    public GameObject canvasTopLayer;
    Vector3 returnPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        draggedObject = this.gameObject;
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
        costObject.text = unitCost.ToString();
        tonnageObject.text = unitTonnage.ToString();
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
