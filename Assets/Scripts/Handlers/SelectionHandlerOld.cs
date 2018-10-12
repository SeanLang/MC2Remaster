using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionHandler : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler, IPointerDownHandler {

    public static HashSet<SelectionHandler> allSelectedObjects = new HashSet<SelectionHandler>();
    public static HashSet<SelectionHandler> currentlySelectedObjects = new HashSet<SelectionHandler>();

    Renderer mRenderer;

    [SerializeField]
    private Material unselectedMaterial;

    [SerializeField]
    private Material selectedMaterial;

    private Text objSelected;

    void Awake()
    {
        allSelectedObjects.Add(this);
        mRenderer = GetComponent<Renderer>();

        objSelected = GameObject.Find("SelectedObject").GetComponent<Text>();

        //Debug.Log("Mechs on the field: " + allSelectedObjects.Count);
    }
 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            {
                DeselectAll(eventData);
            }

            OnSelect(eventData);
        }

        //Debug.LogFormat("{0} is selected", name);
    }

    public void OnSelect(BaseEventData eventData)
    {
        currentlySelectedObjects.Add(this);
        mRenderer.material = selectedMaterial;
        objSelected.text = this.name;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        mRenderer.material = unselectedMaterial;
    }

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach(SelectionHandler selectableObjects in currentlySelectedObjects)
        {
            selectableObjects.OnDeselect(eventData);
        }

        currentlySelectedObjects.Clear();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }
}
