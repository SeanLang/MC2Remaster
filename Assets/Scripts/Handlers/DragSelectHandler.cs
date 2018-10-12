using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class DragSelectHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image selectionBoxSprite;

    [SerializeField]
    private LayerMask movementMask;

    private Vector2 clickPos1;
    private Rect selectionRect;
    private RaycastHit hit;

    private Text objSelected;

    void Awake()
    {
        objSelected = GameObject.Find("SelectedObject").GetComponent<Text>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            {
                //SelectionHandler.DeselectAll(new BaseEventData(EventSystem.current));
            }

            selectionBoxSprite.gameObject.SetActive(true);
            clickPos1 = eventData.position;
            selectionRect = new Rect();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.position.x < clickPos1.x)
            {
                selectionRect.xMin = eventData.position.x;
                selectionRect.xMax = clickPos1.x;
            }
            else
            {
                selectionRect.xMin = clickPos1.x;
                selectionRect.xMax = eventData.position.x;
            }

            if (eventData.position.y < clickPos1.y)
            {
                selectionRect.yMin = eventData.position.y;
                selectionRect.yMax = clickPos1.y;
            }
            else
            {
                selectionRect.yMin = clickPos1.y;
                selectionRect.yMax = eventData.position.y;
            }

            selectionBoxSprite.rectTransform.offsetMin = selectionRect.min;
            selectionBoxSprite.rectTransform.offsetMax = selectionRect.max;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            selectionBoxSprite.gameObject.SetActive(false);
        }

        objSelected.text = "";

        foreach(SelectionHandler selectableObjects in SelectionHandler.allSelectedObjects)
        {
            if (selectionRect.Contains(Camera.main.WorldToScreenPoint(selectableObjects.transform.position)))
            {
                selectableObjects.OnSelect(eventData);
                objSelected.text += this.name;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        float mDistance = 0;

        foreach(RaycastResult result in results)
        {
            if (result.gameObject == gameObject)
            {
                mDistance = result.distance;
                break;
            }
        }

        GameObject nextObj = null;

        float maxDistance = Mathf.Infinity;

        foreach(RaycastResult result in results)
        {
            if (result.distance > mDistance && result.distance < maxDistance)
            {
                nextObj = result.gameObject;
                maxDistance = result.distance;
            }
        }

        if (nextObj)
        {
            ExecuteEvents.Execute<IPointerClickHandler>(nextObj, eventData, (x, y) => { x.OnPointerClick((PointerEventData)y); });
        }
    }
}
