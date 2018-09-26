
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
   public static GameObject draggedObject;
   public  GameObject CanvasTopLayer;
   Vector3 returnPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(CanvasTopLayer.transform);
        draggedObject = this.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Start()
    {
        returnPosition = transform.localPosition;
    }

    void Update()
    {

    }
}
