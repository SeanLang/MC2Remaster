using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class ConsumableDisplayPanelController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public int consumableCost;
    public int unitTonnage;
    public string consumableName;
    public string iconFileName;
    public Sprite iconSprite;
    public StoreController parentPanel;
    public ConsumableClass thisPanelConsumable;

    public bool notDeployment;
    public Text nameObject;
    public Text costObject;
    public Text tonnageObject;
    public Image iconObject;

    public static GameObject draggedConsumable;
    public GameObject canvasTopLayer;
    Vector3 returnPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        draggedConsumable = this.gameObject;
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
        gameObject.name = consumableName;
        nameObject.text = consumableName;
        if (notDeployment == true)
        {
            costObject.text = consumableName.ToString();
            tonnageObject.text = unitTonnage.ToString();
        }
        iconObject.sprite = Resources.Load<Sprite>("UnitIcons/Consumeables/" + iconFileName);
        returnPosition = transform.localPosition;

    }

    public void RemoveFromInventory()
    {
        parentPanel.selectedIcon = gameObject;
    }

    void Update () {
		
	}
}
