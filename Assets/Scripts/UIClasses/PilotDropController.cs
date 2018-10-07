using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class PilotDropController : MonoBehaviour, IDropHandler
{

    public Text pilotNameObject;
    public Image pilotImageObject;
    PilotClass assignedPilot;

    GameObject dragged;

    public void OnDrop (PointerEventData eventData)
    {
        dragged = PilotDisplayPanelController.draggedPilot;
        gameObject.name = dragged.GetComponent<PilotDisplayPanelController>().thisPanelPilot.pilotName;
        pilotNameObject.text = dragged.GetComponent<PilotDisplayPanelController>().thisPanelPilot.pilotName;
        pilotImageObject.sprite = Resources.Load<Sprite>("UnitIcons/Pilots/" + dragged.GetComponent<PilotDisplayPanelController>().thisPanelPilot.iconFileName);
        assignedPilot = dragged.GetComponent<PilotDisplayPanelController>().thisPanelPilot;
        Destroy(dragged);
    }


    public void CreateDeploymentPilotList()
    {
        GetComponentInParent<StoreController>().pilots.Add(assignedPilot);
    }
	void Start () {
		
	}
	
	void Update () {
		
	}
}
