using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DeploymentSlotController : MonoBehaviour, IDropHandler
{
    public GameObject otherPanel;
    public GameObject unitIconPanel;
    public GameObject pilotIconPanel;
    public Transform unitIconSpawn;
    public Transform pilotIconSpawn;
    public Text pilotNameObject;
    public Text unitNameObject;
    GameObject draggedObject;
    UnitClass draggedUnit;
    PilotClass draggedPilot;
    public int screenState;
    PilotClass assignedPilot;
    UnitClass assignedUnit;

    public void OnDrop(PointerEventData eventData)
    {
        if (screenState == 2)
        {
            draggedObject = PilotDisplayPanelController.draggedPilot;
            draggedPilot = draggedObject.GetComponent<PilotDisplayPanelController>().thisPanelPilot;
            //pilotIconObject.sprite = Resources.Load<Sprite>("UnitIcons/Pilots/" + draggedPilot.iconFileName);
            pilotNameObject.text = draggedPilot.pilotName;
        }
        else if(screenState == 1)
        {
            draggedObject = UnitDisplayPanelController.draggedUnit;
            draggedUnit = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
            //unitIconObject.sprite = Resources.Load<Sprite>("UnitIcons/Vehicles/" + draggedUnit.iconFileName);
            unitNameObject.text = draggedUnit.unitName;
        }else if (screenState == 0)
        {
            draggedObject = UnitDisplayPanelController.draggedUnit;
            draggedUnit = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
            //unitIconObject.sprite = Resources.Load<Sprite>("UnitIcons/Mechs/" + draggedUnit.iconFileName);
            unitNameObject.text = draggedUnit.unitName;
        }
    }

    public void AssignDeploymentList()
    {

    }
}
