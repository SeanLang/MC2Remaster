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
    public List<UnitClass> tanks = new List<UnitClass>();
    public List<UnitClass> infantry = new List<UnitClass>();
    public List<UnitClass> VTOLs = new List<UnitClass>();
    List<GameObject> activeBuyList = new List<GameObject>();

    public GameObject otherPanel;
    public GameObject selectedIcon;
    public GameObject unitPanel;
    public GameObject canvasTopLayer;

    public bool isStoreScreen;
    public bool isStore;
    public bool isInventory;
    public bool isDeployment;

    public Vector3 dropPosition;

    public int maxPanelsOnScreen;

    int currentWindowID;
    GameObject currentInstantiate;
    UnitDisplayPanel activeUnit;
    StoreController storeScript;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped");
        Debug.Log(DragHandler.draggedObject);
        RectTransform invPanel = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition, null))
        {
            Debug.Log("Out of drop");
            GameObject dragged = UnitDisplayPanel.draggedObject;
            UnitDisplayPanel scriptOfDragged = dragged.GetComponent<UnitDisplayPanel>();
            dragged.transform.position = dropPosition;
            dragged.transform.SetParent(this.transform);
            mechs.Add(scriptOfDragged.thisPanelUnit);
            otherPanel.GetComponent<StoreController>().mechs.Remove(scriptOfDragged.thisPanelUnit);
            otherPanel.GetComponent<StoreController>().SetWindow(currentWindowID);
            SetWindow(currentWindowID);
            if (isStore == true)
            {
                GameController.controller.money = GameController.controller.money + scriptOfDragged.unitCost;
            }else if(isStoreScreen == true && isInventory == true)
            {
                GameController.controller.money = GameController.controller.money - scriptOfDragged.unitCost;
            }
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
            GameController.controller.buyableTankList = new List<string>();
            GameController.controller.buyableVTOLList = new List<string>();
            GameController.controller.buyableInfantryList = new List<string>();
            foreach (UnitClass a in mechs)
            {
                GameController.controller.buyableMechList.Add(a.unitName);
            }
            foreach (UnitClass a in tanks)
            {
                GameController.controller.buyableTankList.Add(a.unitName);
            }
            foreach (UnitClass a in VTOLs)
            {
                GameController.controller.buyableVTOLList.Add(a.unitName);
            }
            foreach (UnitClass a in infantry)
            {
                GameController.controller.buyableInfantryList.Add(a.unitName);
            }
        }
        if (isInventory == true)
        {
            GameController.controller.ownedMechList = new List<string>();
            GameController.controller.ownedTankList = new List<string>();
            GameController.controller.ownedVTOLList = new List<string>();
            GameController.controller.ownedInfantryList = new List<string>();
            foreach (UnitClass a in mechs)
            {
                GameController.controller.ownedMechList.Add(a.unitName);
            }
            foreach (UnitClass a in tanks)
            {
                GameController.controller.ownedTankList.Add(a.unitName);
            }
            foreach (UnitClass a in VTOLs)
            {
                GameController.controller.ownedVTOLList.Add(a.unitName);
            }
            foreach (UnitClass a in infantry)
            {
                GameController.controller.ownedInfantryList.Add(a.unitName);
            }
        }
        if (isDeployment == true)
        {
            GameController.controller.DeploymentList = new List<string>();
            foreach(UnitClass a in mechs)
            {
                GameController.controller.DeploymentList.Add(a.unitName);
            }
            foreach (UnitClass a in tanks)
            {
                GameController.controller.DeploymentList.Add(a.unitName);
            }
            foreach (UnitClass a in VTOLs)
            {
                GameController.controller.DeploymentList.Add(a.unitName);
            }
            foreach (UnitClass a in infantry)
            {
                GameController.controller.DeploymentList.Add(a.unitName);
            }
        }
    }

    void Start()
    {
        if (isStore == true) {
            foreach (string a in GameController.controller.buyableMechList)
            {
                mechs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyablePilotList)
            {
                pilots.Add(JsonUtility.FromJson<PilotClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/PilotData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyableTankList)
            {
                tanks.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/TankData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyableInfantryList)
            {
                infantry.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/InfantryData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.buyableVTOLList)
            {
                VTOLs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/VTOLData/" + a + ".json")));
            }
        }

        if (isInventory == true)
        {

            foreach (string a in GameController.controller.ownedMechList)
            {
                mechs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedPilotList)
            {
                pilots.Add(JsonUtility.FromJson<PilotClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/PilotData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedTankList)
            {
                tanks.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/TankData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedInfantryList)
            {
                infantry.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/InfantryData/" + a + ".json")));
            }
            foreach (string a in GameController.controller.ownedVTOLList)
            {
                VTOLs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/VTOLData/" + a + ".json")));
            }
        }
        SetWindow(0);
    }

    public void SetWindow(int windowID)
    {
        int count;
        currentWindowID = windowID;
        switch (windowID)
        {
            #region case0
            case 0:
                foreach (GameObject c in activeBuyList)
                {
                    Destroy(c);
                }
                activeBuyList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in mechs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                    UnitDisplayPanel currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanel>();
                    currentPanelClass.canvasTopLayer = canvasTopLayer;
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                break;
            #endregion

            #region case1
            case 1:
                foreach (GameObject c in activeBuyList)
                {
                    Destroy(c);
                }
                activeBuyList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in tanks)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                    UnitDisplayPanel currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanel>();
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                break;
            #endregion

            #region case2
            case 2:
                foreach (GameObject c in activeBuyList)
                {
                    Destroy(c);
                }
                activeBuyList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in VTOLs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                    UnitDisplayPanel currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanel>();
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                break;
            #endregion

            #region case3
            case 3:
                foreach (GameObject c in activeBuyList)
                {
                    Destroy(c);
                }
                activeBuyList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in infantry)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                    UnitDisplayPanel currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanel>();
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                break;
            #endregion

            #region case4
            case 4:
                foreach (GameObject c in activeBuyList)
                {
                    Destroy(c);
                }
                activeBuyList = new List<GameObject>();
                count = 0;
                foreach (UnitClass b in mechs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPanel, transform, false);
                    UnitDisplayPanel currentPanelClass = currentInstantiate.GetComponent<UnitDisplayPanel>();
                    currentPanelClass.thisPanelUnit = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                if (count > maxPanelsOnScreen)
                {
                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                }
                break;
                #endregion
        }
    }

    void Update()
    {

    }
}
