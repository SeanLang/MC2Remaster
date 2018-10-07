using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using System;

public class StoreController : MonoBehaviour, IDropHandler
{

    public List<PilotClass> pilots = new List<PilotClass>();
    public List<UnitClass> mechs = new List<UnitClass>();
    public List<UnitClass> vehicles = new List<UnitClass>();
    public List<UnitClass> infantry = new List<UnitClass>();
    public List<UnitClass> VTOLs = new List<UnitClass>();
    public List<ConsumableClass> consumables = new List<ConsumableClass>();
    List<GameObject> thisDisplayList = new List<GameObject>();

    UnitDisplayPanelController scriptOfDraggedUnit;
    PilotDisplayPanelController scriptOfDraggedPilot;
    ConsumableDisplayPanelController scriptOfDraggedConsumable;

    public GameObject otherPanel;
    public GameObject selectedIcon;
    public GameObject unitPanel;
    public GameObject pilotPanel;
    public GameObject consumablePanel;
    public GameObject deploymentPanel;
    public GameObject canvasTopLayer;

    public bool isStoreScreen;
    public bool isStore;
    public bool isInventory;
    public bool isDeployment;

    public Vector3 dropPosition;

    public int maxPanelsOnScreen;

    RectTransform invPanel;
    int currentWindowID;
    GameObject dragged;
    GameObject currentInstantiate;
    UnitDisplayPanelController activeUnit;
    StoreController storeScript;

    public void SetPilotsDroppable()
    {
        foreach (PilotDropController a in GetComponentsInChildren<PilotDropController>())
        {
            a.enabled = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        switch (currentWindowID)
        {
            #region Mechs
            case 0:
             invPanel = transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
            {
                if (isDeployment == false)
                {
                    dragged = UnitDisplayPanelController.draggedUnit;
                    scriptOfDraggedUnit = dragged.GetComponent<UnitDisplayPanelController>();
                    dragged.transform.position = dropPosition;
                    dragged.transform.SetParent(this.transform);
                    if (!mechs.Contains(scriptOfDraggedUnit.thisPanelUnit))
                    {
                        mechs.Add(scriptOfDraggedUnit.thisPanelUnit);
                        otherPanel.GetComponent<StoreController>().mechs.Remove(scriptOfDraggedUnit.thisPanelUnit);
                        otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                        SetWindow(currentWindowID);
                    }
                    if (isStore == true)
                    {
                        GameController.controller.money = GameController.controller.money + scriptOfDraggedUnit.unitCost;
                    }
                    else if (isStoreScreen == true && isInventory == true)
                    {
                        GameController.controller.money = GameController.controller.money - scriptOfDraggedUnit.unitCost;
                    }
                }
                else
                {

                    dragged = UnitDisplayPanelController.draggedUnit;
                    scriptOfDraggedUnit = dragged.GetComponent<UnitDisplayPanelController>();
                    if (!mechs.Contains(scriptOfDraggedUnit.thisPanelUnit))
                    {
                        mechs.Add(scriptOfDraggedUnit.thisPanelUnit);
                        otherPanel.GetComponent<StoreController>().mechs.Remove(scriptOfDraggedUnit.thisPanelUnit);
                        otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                        Destroy(dragged);
                        SetWindow(currentWindowID);
                    }
                }
            }
            break;
            #endregion

            #region Vehicles
            case 1:
                 invPanel = transform as RectTransform;
                if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
                {
                    if (isDeployment == false)
                    {
                        dragged = UnitDisplayPanelController.draggedUnit;
                        scriptOfDraggedUnit = dragged.GetComponent<UnitDisplayPanelController>();
                        dragged.transform.position = dropPosition;
                        dragged.transform.SetParent(this.transform);
                        if (!vehicles.Contains(scriptOfDraggedUnit.thisPanelUnit))
                        {
                            vehicles.Add(scriptOfDraggedUnit.thisPanelUnit);
                            otherPanel.GetComponent<StoreController>().vehicles.Remove(scriptOfDraggedUnit.thisPanelUnit);
                            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                            SetWindow(currentWindowID);
                        }
                        if (isStore == true)
                        {
                            GameController.controller.money = GameController.controller.money + scriptOfDraggedUnit.unitCost;
                        }
                        else if (isStoreScreen == true && isInventory == true)
                        {
                            GameController.controller.money = GameController.controller.money - scriptOfDraggedUnit.unitCost;
                        }
                    }
                    else
                    {

                        dragged = UnitDisplayPanelController.draggedUnit;
                        scriptOfDraggedUnit = dragged.GetComponent<UnitDisplayPanelController>();
                        if (!vehicles.Contains(scriptOfDraggedUnit.thisPanelUnit))
                        {
                            vehicles.Add(scriptOfDraggedUnit.thisPanelUnit);
                            otherPanel.GetComponent<StoreController>().vehicles.Remove(scriptOfDraggedUnit.thisPanelUnit);
                            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                            Destroy(dragged);
                            SetWindow(currentWindowID);
                        }
                    }
                }
                break;
            #endregion

            #region Pilots
            case 2:
                invPanel = transform as RectTransform;
                if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
                {
                    if (isDeployment == false)
                    {
                        dragged = PilotDisplayPanelController.draggedPilot;
                        scriptOfDraggedPilot = dragged.GetComponent<PilotDisplayPanelController>();
                        dragged.transform.position = dropPosition;
                        dragged.transform.SetParent(this.transform);
                        if (!pilots.Contains(scriptOfDraggedPilot.thisPanelPilot))
                        {
                            pilots.Add(scriptOfDraggedPilot.thisPanelPilot);
                            otherPanel.GetComponent<StoreController>().pilots.Remove(scriptOfDraggedPilot.thisPanelPilot);
                            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                            SetWindow(currentWindowID);
                        }
                        if (isStore == true)
                        {
                            GameController.controller.money = GameController.controller.money + scriptOfDraggedPilot.unitCost;
                        }
                        else if (isStoreScreen == true && isInventory == true)
                        {
                            GameController.controller.money = GameController.controller.money - scriptOfDraggedPilot.unitCost;
                        }
                    }
                    else
                    {

                        dragged = UnitDisplayPanelController.draggedUnit;
                        scriptOfDraggedUnit = dragged.GetComponent<UnitDisplayPanelController>();
                        if (!pilots.Contains(scriptOfDraggedPilot.thisPanelPilot))
                        {
                            pilots.Add(scriptOfDraggedPilot.thisPanelPilot);
                            otherPanel.GetComponent<StoreController>().pilots.Remove(scriptOfDraggedPilot.thisPanelPilot);
                            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                            Destroy(dragged);
                            SetWindow(currentWindowID);
                        }
                    }
                }
                break;
            #endregion

            #region Consumables
            case 3:
                invPanel = transform as RectTransform;
                if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
                {
                    if (isDeployment == false)
                    {
                        dragged = ConsumableDisplayPanelController.draggedConsumable;
                        scriptOfDraggedConsumable = dragged.GetComponent<ConsumableDisplayPanelController>();
                        dragged.transform.position = dropPosition;
                        dragged.transform.SetParent(this.transform);
                        if (!consumables.Contains(scriptOfDraggedConsumable.thisPanelConsumable))
                        {
                            consumables.Add(scriptOfDraggedConsumable.thisPanelConsumable);
                            otherPanel.GetComponent<StoreController>().consumables.Remove(scriptOfDraggedConsumable.thisPanelConsumable);
                            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                            SetWindow(currentWindowID);
                        }
                        if (isStore == true)
                        {
                            GameController.controller.money = GameController.controller.money + scriptOfDraggedPilot.unitCost;
                        }
                        else if (isStoreScreen == true && isInventory == true)
                        {
                            GameController.controller.money = GameController.controller.money - scriptOfDraggedPilot.unitCost;
                        }
                    }
                    else
                    {

                        dragged = UnitDisplayPanelController.draggedUnit;
                        scriptOfDraggedUnit = dragged.GetComponent<UnitDisplayPanelController>();
                        if (!consumables.Contains(scriptOfDraggedConsumable.thisPanelConsumable))
                        {
                            consumables.Add(scriptOfDraggedConsumable.thisPanelConsumable);
                            otherPanel.GetComponent<StoreController>().consumables.Remove(scriptOfDraggedConsumable.thisPanelConsumable);
                            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
                            Destroy(dragged);
                            SetWindow(currentWindowID);
                        }
                    }
                }
                break;
                #endregion
        }
    }

    public void SetDeployementList()
    {
        SetWindow(currentWindowID);
    }

    public void AssignLists()
    {
        if (isStore == true)
        {
            GameController.controller.buyableMechList = new List<string>();
            GameController.controller.buyableVehicleList = new List<string>();
            GameController.controller.buyablePilotList = new List<string>();
            GameController.controller.buyableConsumableList = new List<string>();
            foreach (UnitClass a in mechs)
            {
                GameController.controller.buyableMechList.Add(a.unitName);
            }
            foreach (UnitClass a in vehicles)
            {
                GameController.controller.buyableVehicleList.Add(a.unitName);
            }
            foreach (PilotClass a in pilots)
            {
                GameController.controller.buyablePilotList.Add(a.pilotName);
            }
            foreach (ConsumableClass a in consumables)
            {
                GameController.controller.buyableConsumableList.Add(a.consumableName);
            }
        }
        if (isInventory == true)
        {
            GameController.controller.ownedMechList = new List<string>();
            GameController.controller.ownedVehicleList = new List<string>();
            GameController.controller.ownedPilotList = new List<string>();
            GameController.controller.ownedConsumableList = new List<string>();
            foreach (UnitClass a in mechs)
            {
                GameController.controller.ownedMechList.Add(a.unitName);
            }
            foreach (UnitClass a in vehicles)
            {
                GameController.controller.ownedVehicleList.Add(a.unitName);
            }
            foreach (PilotClass a in pilots)
            {
                GameController.controller.ownedPilotList.Add(a.pilotName);
            }
            foreach (ConsumableClass a in consumables)
            {
                GameController.controller.ownedConsumableList.Add(a.consumableName);
            }
        }
        if (isDeployment == true)
        {
            GameController.controller.unitDeploymentList = new List<string>();
            foreach(UnitClass a in mechs)
            {
                GameController.controller.unitDeploymentList.Add(a.unitName);
            }
            foreach (UnitClass a in vehicles)
            {
                GameController.controller.unitDeploymentList.Add(a.unitName);
            }
            pilots = new List<PilotClass>();
            foreach (PilotDropController a in GetComponentsInChildren<PilotDropController>())
            {
                a.CreateDeploymentPilotList();
            }
            foreach (PilotClass a in pilots)
            {
                GameController.controller.pilotDeploymentList.Add(a.pilotName);
            }
        }
    }

    void OnEnable()
    {
        if (isStore == true)
        {
            mechs = new List<UnitClass>();
            pilots = new List<PilotClass>();
            vehicles = new List<UnitClass>();
            infantry = new List<UnitClass>();
            VTOLs = new List<UnitClass>();
            foreach (string a in GameController.controller.buyableMechList)
            {
                mechs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyablePilotList)
            {
                pilots.Add(JsonUtility.FromJson<PilotClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/PilotData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyableVehicleList)
            {
                vehicles.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/VehicleData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyableConsumableList)
            {
                consumables.Add(JsonUtility.FromJson<ConsumableClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/ConsumableData/" + a + ".json")));
            }
        }

        if (isInventory == true)
        {
            mechs = new List<UnitClass>();
            pilots = new List<PilotClass>();
            vehicles = new List<UnitClass>();
            infantry = new List<UnitClass>();
            VTOLs = new List<UnitClass>();
            foreach (string a in GameController.controller.ownedMechList)
            {
                mechs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedPilotList)
            {
                pilots.Add(JsonUtility.FromJson<PilotClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/PilotData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedVehicleList)
            {
                vehicles.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/VehicleData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedConsumableList)
            {
                consumables.Add(JsonUtility.FromJson<ConsumableClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/ConsumableData/" + a + ".json")));
            }
        }
        SetWindow(0);
    }

    public void SetWindow(int windowID)
    {
        int count;
        currentWindowID = windowID;
        if (!isDeployment)
        {
            switch (windowID)
            {
                #region Mech List
                case 0:
                    foreach (GameObject c in thisDisplayList)
                {
                    Destroy(c);
                }
                thisDisplayList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in mechs)
                {
                    count++;
                    if (isDeployment == false)
                    {
                        currentInstantiate = Instantiate(unitPanel, transform, false);
                    }
                    else
                    {
                        currentInstantiate = Instantiate(deploymentPanel, transform, false);
                    }
                    UnitDisplayPanelController currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanelController>();
                    currentPanelClass.canvasTopLayer = canvasTopLayer;
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    thisDisplayList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                else
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (maxPanelsOnScreen * 100) + 10);
                }
                break;
                #endregion

                #region Vehicle List
                case 1:
                    foreach (GameObject c in thisDisplayList)
                {
                    Destroy(c);
                }
                thisDisplayList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in vehicles)
                {
                    count++;
                    if (isDeployment == false)
                    {
                        currentInstantiate = Instantiate(unitPanel, transform, false);
                    }
                    else
                    {
                        currentInstantiate = Instantiate(deploymentPanel, transform, false);
                    }
                    UnitDisplayPanelController currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanelController>();
                    currentPanelClass.canvasTopLayer = canvasTopLayer;
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    thisDisplayList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                else
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (maxPanelsOnScreen * 100) + 10);
                }
                break;
                #endregion

                #region Pilot List
                case 2:
                    foreach (GameObject c in thisDisplayList)
                {
                    Destroy(c);
                }
                thisDisplayList = new List<GameObject>();
                count = 0;
                foreach (PilotClass b in pilots)
                {
                    count++;
                    if (isDeployment == false)
                    {
                        currentInstantiate = Instantiate(pilotPanel, transform, false);
                    }
                    else
                    {
                        currentInstantiate = Instantiate(deploymentPanel, transform, false);
                    }
                    PilotDisplayPanelController currentPilotPanelClass = currentInstantiate.GetComponent<PilotDisplayPanelController>();
                    currentPilotPanelClass.canvasTopLayer = canvasTopLayer;
                    currentPilotPanelClass.thisPanelPilot = b;
                    currentPilotPanelClass.pilotName = b.pilotName;
                    currentPilotPanelClass.unitCost = b.purchaseCost;
                    currentPilotPanelClass.unitRank = b.rank;
                    currentPilotPanelClass.iconFileName = b.iconFileName;
                    currentPilotPanelClass.parentPanel = this;
                    thisDisplayList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                else
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (maxPanelsOnScreen * 100) + 10);
                }
                break;
                #endregion

                #region Consumable List
                case 3:
                    foreach (GameObject c in thisDisplayList)
                {
                    Destroy(c);
                }
                thisDisplayList = new List<GameObject>();
                count = 0;
                foreach (ConsumableClass b in consumables)
                {
                    count++;
                    if (isDeployment == false)
                    {
                        currentInstantiate = Instantiate(consumablePanel, transform, false);
                    }
                    ConsumableDisplayPanelController currentConsumablePanelClass = currentInstantiate.GetComponent<ConsumableDisplayPanelController>();
                    currentConsumablePanelClass.canvasTopLayer = canvasTopLayer;
                    currentConsumablePanelClass.thisPanelConsumable = b;
                    currentConsumablePanelClass.consumableName = b.consumableName;
                    currentConsumablePanelClass.consumableCost = b.purchaseCost;
                    currentConsumablePanelClass.iconFileName = b.iconFileName;
                    currentConsumablePanelClass.parentPanel = this;
                    thisDisplayList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                else
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (maxPanelsOnScreen * 100) + 10);
                }
                break;
                #endregion

                #region case4
                case 4:
                    foreach (GameObject c in thisDisplayList)
                {
                    Destroy(c);
                }
                thisDisplayList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in mechs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                    UnitDisplayPanelController currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanelController>();
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    thisDisplayList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                break;
                #endregion
            }
        }
        else
        {
            #region Deployment Mechs
            foreach (GameObject c in thisDisplayList)
            {
                Destroy(c);
            }
            thisDisplayList = new List<GameObject>();
            count = 0;
            foreach (UnitClass b in mechs)
            {
                count++;
                if (isDeployment == false)
                {
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                }
                else
                {
                    currentInstantiate = Instantiate(deploymentPanel, transform, false);
                }
                UnitDisplayPanelController currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanelController>();
                currentPanelClass.canvasTopLayer = canvasTopLayer;
                currentPanelClass.thisPanelUnit = b;
                currentPanelClass.unitName = b.unitName;
                currentPanelClass.unitCost = b.purchaseCost;
                currentPanelClass.unitTonnage = b.weight;
                currentPanelClass.iconFileName = b.iconFileName;
                currentPanelClass.parentPanel = this;
                thisDisplayList.Add(currentInstantiate);
            }
            if (count > maxPanelsOnScreen)
            {
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
            }
            else
            {
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (maxPanelsOnScreen * 100) + 10);
            }
            #endregion

            #region Deployment Vehicles
            foreach (UnitClass b in vehicles)
            {
                count++;
                if (isDeployment == false)
                {
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                }
                else
                {
                    currentInstantiate = Instantiate(deploymentPanel, transform, false);
                }
                UnitDisplayPanelController currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanelController>();
                currentPanelClass.canvasTopLayer = canvasTopLayer;
                currentPanelClass.thisPanelUnit = b;
                currentPanelClass.unitName = b.unitName;
                currentPanelClass.unitCost = b.purchaseCost;
                currentPanelClass.unitTonnage = b.weight;
                currentPanelClass.iconFileName = b.iconFileName;
                currentPanelClass.parentPanel = this;
                thisDisplayList.Add(currentInstantiate);
            }
            if (count > maxPanelsOnScreen)
            {
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
            }
            else
            {
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (maxPanelsOnScreen * 100) + 10);
            }
            #endregion
        }
    }

    void Update()
    {

    }
}