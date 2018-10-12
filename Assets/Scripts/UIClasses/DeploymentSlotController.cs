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
    public bool occupied;
    GameObject draggedObject;
    GameObject instantiatedUnitIcon;
    GameObject instantiatedPilotIcon;
    public int screenState;
    public PilotClass assignedPilot;
    public UnitClass assignedMech;
    public UnitClass assignedVehicle;

    void Start()
    {
        assignedVehicle = null;
        assignedMech = null;
        assignedPilot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(UnitDisplayPanelController.draggedUnit);
        Debug.Log(PilotDisplayPanelController.draggedPilot);
        if (occupied == true)
        {
            if (eventData.pointerDrag.tag == "Deployment")
            {
                if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().thisPilot != null)
                {
                    if (assignedPilot != null)
                    {
                        otherPanel.pilots.Add(assignedPilot);
                        otherPanel.SetWindow(2);
                        assignedPilot = null;
                        Destroy(instantiatedPilotIcon);
                    }
                }
                if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().thisUnit != null)
                {
                    if (assignedMech != null)
                    {
                        otherPanel.mechs.Add(assignedMech);
                        otherPanel.SetWindow(0);
                        assignedVehicle = null;
                        Destroy(instantiatedUnitIcon);
                    }
                    else if (assignedVehicle != null)
                    {
                        otherPanel.vehicles.Add(assignedVehicle);
                        otherPanel.SetWindow(1);
                        assignedVehicle = null;
                        Destroy(instantiatedUnitIcon);
                    }
                }
            }
            else if (eventData.pointerDrag.tag == "NotDeployment")
            {
                if (screenState == 2)
                {
                    if (assignedPilot != null)
                    {
                        otherPanel.pilots.Add(assignedPilot);
                        otherPanel.pilots.Remove(eventData.pointerDrag.GetComponent<PilotDisplayPanelController>().thisPanelPilot);
                        otherPanel.SetWindow(2);
                        assignedPilot = null;
                        Destroy(instantiatedPilotIcon);
                    }
                }
                else if (screenState == 1 || screenState == 0)
                {
                    if (assignedVehicle != null)
                    {
                        otherPanel.vehicles.Add(assignedVehicle);
                        if (screenState == 1)
                        {
                            otherPanel.vehicles.Remove(eventData.pointerDrag.GetComponent<UnitDisplayPanelController>().thisPanelUnit);
                            otherPanel.SetWindow(1);
                        }
                        else if (screenState == 0)
                        {
                            otherPanel.mechs.Remove(eventData.pointerDrag.GetComponent<UnitDisplayPanelController>().thisPanelUnit);
                            otherPanel.SetWindow(0);
                        }
                        assignedVehicle = null;
                        Destroy(instantiatedUnitIcon);
                    }
                    else if (assignedMech != null)
                    {
                        otherPanel.mechs.Add(assignedMech);
                        if (screenState == 1)
                        {
                            otherPanel.vehicles.Remove(eventData.pointerDrag.GetComponent<UnitDisplayPanelController>().thisPanelUnit);
                            otherPanel.SetWindow(1);
                        }
                        else if (screenState == 0)
                        {
                            otherPanel.mechs.Remove(eventData.pointerDrag.GetComponent<UnitDisplayPanelController>().thisPanelUnit);
                            otherPanel.SetWindow(0);
                        }
                        assignedVehicle = null;
                        Destroy(instantiatedUnitIcon);
                    }
                }
            }
        }
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
                if (occupied == false)
                {
                    otherPanel.pilots.Remove(assignedPilot);
                }
                PilotDisplayPanelController.draggedPilot = null;
                Destroy(draggedObject);
                occupied = true;
            }
            else if (screenState == 1)
            {
                draggedObject = eventData.pointerDrag;
                assignedVehicle = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
                instantiatedUnitIcon = Instantiate(unitIconPanel, unitIconSpawn);
                instantiatedUnitIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Units/" + assignedVehicle.iconFileName);
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().thisUnit = assignedVehicle;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().isUnit = true;
                unitNameObject.text = assignedVehicle.unitName;
                if (occupied == false)
                {
                    otherPanel.vehicles.Remove(assignedVehicle);
                }
                UnitDisplayPanelController.draggedUnit = null;
                Destroy(draggedObject);
                occupied = true;
            }
            else if (screenState == 0)
            {
                draggedObject = eventData.pointerDrag;
                assignedMech = draggedObject.GetComponent<UnitDisplayPanelController>().thisPanelUnit;
                instantiatedUnitIcon = Instantiate(unitIconPanel, unitIconSpawn);
                instantiatedUnitIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("UnitIcons/Units/" + assignedMech.iconFileName);
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().canvasTopLayer = canvasTopLayer;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().previousSlot = this;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().thisUnit = assignedMech;
                instantiatedUnitIcon.GetComponent<DeploymentIconDragController>().isUnit = true;
                unitNameObject.text = assignedMech.unitName;
                if (occupied == false)
                {
                    otherPanel.mechs.Remove(assignedMech);
                }
                UnitDisplayPanelController.draggedUnit = null;
                Destroy(draggedObject);
                occupied = true;
            }
        }
        else if (eventData.pointerDrag.tag == "Deployment")
        {
            if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().thisUnit != null)
            {
                draggedObject = eventData.pointerDrag;
                DeploymentIconDragController draggedObjectScript = draggedObject.GetComponent<DeploymentIconDragController>();
                draggedObjectScript.originPoint = unitIconSpawn;
                if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().previousSlot.assignedVehicle != null)
                {
                    assignedVehicle = draggedObjectScript.thisUnit;
                    draggedObjectScript.previousSlot.assignedVehicle = null;
                    Destroy(instantiatedUnitIcon);
                    instantiatedUnitIcon = eventData.pointerDrag;
                    eventData.pointerDrag.GetComponent<DeploymentIconDragController>().previousSlot.occupied = false;
                }
                else if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().previousSlot.assignedMech != null)
                {
                    assignedMech = draggedObjectScript.thisUnit;
                    draggedObjectScript.previousSlot.assignedMech = null;
                    Destroy(instantiatedUnitIcon);
                    instantiatedUnitIcon = eventData.pointerDrag;
                    eventData.pointerDrag.GetComponent<DeploymentIconDragController>().previousSlot.occupied = false;
                }
                draggedObjectScript.NewLocation();
                draggedObjectScript.previousSlot = this;
                UnitDisplayPanelController.draggedUnit = null;
                occupied = true;
            }
            if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().thisPilot != null)
            {
                draggedObject = eventData.pointerDrag;
                DeploymentIconDragController draggedObjectScript = draggedObject.GetComponent<DeploymentIconDragController>();
                draggedObjectScript.originPoint = pilotIconSpawn;
                if (eventData.pointerDrag.GetComponent<DeploymentIconDragController>().previousSlot.assignedPilot != null)
                {
                    assignedPilot = draggedObjectScript.thisPilot;
                    draggedObjectScript.previousSlot.assignedPilot = null;
                    Destroy(instantiatedPilotIcon);
                    instantiatedPilotIcon = eventData.pointerDrag;
                    eventData.pointerDrag.GetComponent<DeploymentIconDragController>().previousSlot.occupied = false;
                }
                draggedObjectScript.previousSlot.assignedPilot = null;
                draggedObjectScript.NewLocation();
                draggedObjectScript.previousSlot = this;
                PilotDisplayPanelController.draggedPilot = null;
                occupied = true;
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
