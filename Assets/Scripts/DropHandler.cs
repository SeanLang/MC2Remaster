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
        Debug.Log(UnitDisplayPanel.draggedObject);
        RectTransform invPanel = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
        {
            Debug.Log("Out of drop");
            UnitDisplayPanel.draggedObject.transform.position = dropPosition;
            UnitDisplayPanel.draggedObject.transform.SetParent(this.transform);
        }
    }


    void Start()
    {

    }
    
    void Update()
    {

    }
}