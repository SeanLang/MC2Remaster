using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DeploymentSlotController : MonoBehaviour, IDropHandler
{
    public StoreController otherPanel;
    public GameObject canvasTopLayer;
    public GameObject unitIconPanel;
    public GameObject pilotIconPanel;
    public Transform unitIconSpawn;
    public Transform pilotIconSpawn;
    public Text pilotNameObject;
    public Text unitNameObject;
    GameObject draggedObject;
    GameObject instantiatedUnitIcon;
    GameObject instantiatedPilotIcon;
    UnitClass draggedUnit;
    PilotClass draggedPilot;
    public int screenState;
    PilotClass assignedPilot;
    UnitClass assignedUnit;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(UnitDisplayPanelController.draggedUnit);
        Debug.Log(PilotDisplayPanelController.draggedPilot);
        if (UnitDisplayPanelController.draggedUnit.tag == "NotDeployment" || PilotDisplayPanelController.draggedPilot.tag == "NotDeployment") {
            if (screenState == 2)
            {
                draggedObject = PilotDisplayPanelController.draggedPilot;
                draggedPilot = draggedObject.GetComponent<PilotDisplayPanelController>().thisPanelPilot;
                instantiatedPilotIcon = Instantiate(pilotIconPanel, pilotIconSpawn);
                instantiatedPilotIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Pilots/" + draggedPilot.iconFileName);
                instantiatedPilotIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                pilotNameObject.text = draggedPilot.pilotName;
                otherPanel.pilots.Remove(draggedPilot);
                PilotDisplayPanelController.draggedPilot = null;
                Destroy(draggedObject);
            }
            else if (screenState == 1)
            {
                draggedObject = UnitDisplayPanelController.draggedUnit;
                draggedUnit = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
                instantiatedUnitIcon = Instantiate(unitIconPanel, unitIconSpawn);
                instantiatedUnitIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Units/" + draggedUnit.iconFileName);
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                unitNameObject.text = draggedUnit.unitName;
                otherPanel.vehicles.Remove(draggedUnit);
                UnitDisplayPanelController.draggedUnit = null;
                Destroy(draggedObject);
            }
            else if (screenState == 0)
            {
                draggedObject = UnitDisplayPanelController.draggedUnit;
                draggedUnit = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
                instantiatedUnitIcon = Instantiate(unitIconPanel, unitIconSpawn);
                instantiatedUnitIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Units/" + draggedUnit.iconFileName);
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                unitNameObject.text = draggedUnit.unitName;
                otherPanel.mechs.Remove(draggedUnit);
                UnitDisplayPanelController.draggedUnit = null;
                Destroy(draggedObject);
            }
        }
        else if (UnitDisplayPanelController.draggedUnit.tag == "Deployment")
        {
            draggedObject = UnitDisplayPanelController.draggedUnit;
            DeploymentIconDragController draggedObjectScript = GetComponent<DeploymentIconDragController>();
            draggedObjectScript.originPoint = this.transform;
            draggedObjectScript.NewLocation();
            draggedObjectScript.previousSlot = this;
            UnitDisplayPanelController.draggedUnit = null;
        }
        else if (PilotDisplayPanelController.draggedPilot.tag == "Deployment")
        {
            draggedObject = PilotDisplayPanelController.draggedPilot;
            DeploymentIconDragController draggedObjectScript = GetComponent<DeploymentIconDragController>();
            draggedObjectScript.originPoint = this.transform;
            draggedObjectScript.NewLocation();
            draggedObjectScript.previousSlot = this;
            PilotDisplayPanelController.draggedPilot = null;
        }
    }

    public void SetScreenState (int input)
    {
        screenState = input;
    }

    public void AssignDeploymentList()
    {

    }
}
