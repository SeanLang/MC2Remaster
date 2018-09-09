using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class InventoryBayController : MonoBehaviour {

    public List<PilotClass> pilots = new List<PilotClass>();
    public List<MechClass> mechs = new List<MechClass>();
    public List<TankClass> tanks = new List<TankClass>();
    public List<InfantryClass> infantry = new List<InfantryClass>();
    public List<VTOLClass> VTOLs = new List<VTOLClass>();
    public GameObject unitPurchasePanel;
    public GameObject selectedIcon;
    public GameObject deploymentPanel;
    int currentWindowID;
    GameObject currentInstantiate;
    List<GameObject> activeBuyList = new List<GameObject>();
    InventoryMechDisplayPanel activeMech;
    InventoryTankDisplayPanel activeTank;
    InventoryVTOLDisplayPanel activeVTOL;
    InventoryInfantryDisplayPanel activeInfantry;
    DeploymentBayController deploymentBayScript;

    void Start ()
    {
        foreach (string a in GameController.controller.buyableMechList)
        {
            mechs.Add(JsonUtility.FromJson<MechClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json")));
        }
        foreach (string a in GameController.controller.buyablePilotList)
        {
            pilots.Add(JsonUtility.FromJson<PilotClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/PilotData/" + a + ".json")));
        }
        foreach (string a in GameController.controller.buyableTankList)
        {
            tanks.Add(JsonUtility.FromJson<TankClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/TankData/" + a + ".json")));
        }
        foreach (string a in GameController.controller.buyableInfantryList)
        {
            infantry.Add(JsonUtility.FromJson<InfantryClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/InfantryData/" + a + ".json")));
        }
        foreach (string a in GameController.controller.buyableVTOLList)
        {
            VTOLs.Add(JsonUtility.FromJson<VTOLClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/VTOLData/" + a + ".json")));
        }
        SetWindow(0);
    }

    public void SetDeployementList()
    {
        SetWindow(currentWindowID);
    }

    public void SetActiveIcon(GameObject icon)
    {
        selectedIcon = icon;
    }

    public void TransferUnit()
    {
        switch (currentWindowID)
        {
            case 0:
                deploymentBayScript = deploymentPanel.GetComponent<DeploymentBayController>();
                activeMech = selectedIcon.GetComponent<InventoryMechDisplayPanel>();
                deploymentBayScript.mechs.Add(activeMech.thisPanelMech);
                mechs.Remove(activeMech.thisPanelMech);
                deploymentBayScript.SetDeployementList();
                SetDeployementList();
            break;
            case 1:
                deploymentBayScript = deploymentPanel.GetComponent<DeploymentBayController>();
                activeTank = selectedIcon.GetComponent<InventoryTankDisplayPanel>();
                deploymentBayScript.tanks.Add(activeTank.thisPanelTank);
                tanks.Remove(activeTank.thisPanelTank);
                deploymentBayScript.SetDeployementList();
                SetDeployementList();
                break;
            case 2:
                deploymentBayScript = deploymentPanel.GetComponent<DeploymentBayController>();
                activeVTOL = selectedIcon.GetComponent<InventoryVTOLDisplayPanel>();
                deploymentBayScript.VTOLs.Add(activeVTOL.thisPanelVTOL);
                VTOLs.Remove(activeVTOL.thisPanelVTOL);
                deploymentBayScript.SetDeployementList();
                SetDeployementList();
                break;
            case 3:
                deploymentBayScript = deploymentPanel.GetComponent<DeploymentBayController>();
                activeInfantry = selectedIcon.GetComponent<InventoryInfantryDisplayPanel>();
                deploymentBayScript.infantry.Add(activeInfantry.thisPanelInfantry);
                infantry.Remove(activeInfantry.thisPanelInfantry);
                deploymentBayScript.SetDeployementList();
                SetDeployementList();
                break;
        }
    }

    public void SetWindow (int windowID)
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
                foreach (MechClass b in mechs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPurchasePanel, transform, false);
                    InventoryMechDisplayPanel currentPanelClass = currentInstantiate.GetComponent<InventoryMechDisplayPanel>();
                    currentPanelClass.thisPanelMech = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
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
                foreach (TankClass b in tanks)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPurchasePanel, transform, false);
                    InventoryTankDisplayPanel currentPanelClass = currentInstantiate.GetComponent<InventoryTankDisplayPanel>();
                    currentPanelClass.thisPanelTank = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
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
                foreach (VTOLClass b in VTOLs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPurchasePanel, transform, false);
                    InventoryVTOLDisplayPanel currentPanelClass = currentInstantiate.GetComponent<InventoryVTOLDisplayPanel>();
                    currentPanelClass.thisPanelVTOL = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
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
                foreach (InfantryClass b in infantry)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPurchasePanel, transform, false);
                    InventoryInfantryDisplayPanel currentPanelClass = currentInstantiate.GetComponent<InventoryInfantryDisplayPanel>();
                    currentPanelClass.thisPanelInfantry = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
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
                foreach (MechClass b in mechs)
                {
                    count++;
                    currentInstantiate = Instantiate(unitPurchasePanel, transform, false);
                    InventoryMechDisplayPanel currentPanelClass = currentInstantiate.GetComponent<InventoryMechDisplayPanel>();
                    currentPanelClass.thisPanelMech = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                    activeBuyList.Add(currentInstantiate);
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                break;
                #endregion
        }
    }
}
