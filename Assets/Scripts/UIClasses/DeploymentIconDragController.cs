using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeploymentIconDragController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject canvasTopLayer;
    public bool isUnit;
    public DeploymentSlotController previousSlot;
    public Transform originPoint;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        originPoint = transform.parent;
        if (isUnit)
        {
            UnitDisplayPanelController.draggedUnit = this.gameObject;
        }
        if (!isUnit)
        {
            PilotDisplayPanelController.draggedPilot = this.gameObject;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.SetParent(canvasTopLayer.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetParent(originPoint);
    }

    public void NewLocation ()
    {
        transform.SetParent(originPoint);
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
