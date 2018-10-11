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
    public int screenState;
    public PilotClass assignedPilot;
    public UnitClass assignedUnit;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(UnitDisplayPanelController.draggedUnit);
        Debug.Log(PilotDisplayPanelController.draggedPilot);
        
        if (eventData.pointerDrag.tag == "NotDeployment")
        {
            if (screenState == 2)
            {
                draggedObject = eventData.pointerDrag;
                assignedPilot = draggedObject.GetComponent<PilotDisplayPanelController>().thisPanelPilot;
                instantiatedPilotIcon = Instantiate(pilotIconPanel, pilotIconSpawn);
                instantiatedPilotIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Pilots/" + assignedPilot.iconFileName);
                instantiatedPilotIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedPilotIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                instantiatedPilotIcon.GetComponent<DeploymentIconDragController>().thisPilot = assignedPilot;
                pilotNameObject.text = assignedPilot.pilotName;
                otherPanel.pilots.Remove(assignedPilot);
                PilotDisplayPanelController.draggedPilot = null;
                Destroy(draggedObject);
            }
            else if (screenState == 1)
            {
                draggedObject = eventData.pointerDrag;
                assignedUnit = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
                instantiatedUnitIcon = Instantiate(unitIconPanel, unitIconSpawn);
                instantiatedUnitIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Units/" + assignedUnit.iconFileName);
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().thisUnit = assignedUnit;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().isUnit = true;
                unitNameObject.text = assignedUnit.unitName;
                otherPanel.vehicles.Remove(assignedUnit);
                UnitDisplayPanelController.draggedUnit = null;
                Destroy(draggedObject);
            }
            else if (screenState == 0)
            {
                draggedObject = eventData.pointerDrag;
                assignedUnit = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
                instantiatedUnitIcon = Instantiate(unitIconPanel, unitIconSpawn);
                instantiatedUnitIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Units/" + assignedUnit.iconFileName);
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().thisUnit = assignedUnit;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().isUnit = true;
                unitNameObject.text = assignedUnit.unitName;
                otherPanel.mechs.Remove(assignedUnit);
                UnitDisplayPanelController.draggedUnit = null;
                Destroy(draggedObject);
            }
        }
        else if (eventData.pointerDrag.tag == "Deployment")
        {
            if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().thisUnit != null)
            {
                draggedObject = eventData.pointerDrag;
                DeploymentIconDragController draggedObjectScript = draggedObject.GetComponent<DeploymentIconDragController>();
                draggedObjectScript.originPoint = unitIconSpawn;
                assignedUnit = draggedObjectScript.thisUnit;
                draggedObjectScript.previousSlot.assignedUnit = null;
                draggedObjectScript.NewLocation();
                draggedObjectScript.previousSlot = this;
                UnitDisplayPanelController.draggedUnit = null;
            }
            if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().thisPilot != null)
            {
                draggedObject = eventData.pointerDrag;
                DeploymentIconDragController draggedObjectScript = draggedObject.GetComponent<DeploymentIconDragController>();
                draggedObjectScript.originPoint = pilotIconSpawn;
                assignedPilot = draggedObjectScript.thisPilot;
                draggedObjectScript.previousSlot.assignedPilot = null;
                draggedObjectScript.NewLocation();
                draggedObjectScript.previousSlot = this;
                PilotDisplayPanelController.draggedPilot = null;
            }
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
