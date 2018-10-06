using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public Vector3 dropPosition;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped");
        Debug.Log(UnitDisplayPanelController.draggedUnit);
        RectTransform invPanel = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
        {
            Debug.Log("Out of drop");
            UnitDisplayPanelController.draggedUnit.transform.position = dropPosition;
            UnitDisplayPanelController.draggedUnit.transform.SetParent(this.transform);
        }
    }


    void Start()
    {

    }
    
    void Update()
    {

    }
}