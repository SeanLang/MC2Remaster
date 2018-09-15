using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class DeploymentBayController : MonoBehaviour {
    
    public List<PilotClass> pilots = new List<PilotClass>();
    public List<MechClass> mechs = new List<MechClass>();
    public List<TankClass> tanks = new List<TankClass>();
    public List<InfantryClass> infantry = new List<InfantryClass>();
    public List<VTOLClass> VTOLs = new List<VTOLClass>();
    public GameObject unitDeploymentPanel;
    public GameObject selectedIcon;
    public GameObject inventoryPanel;
    int currentWindowID;
    GameObject currentInstantiate;
    List<GameObject> activeDeploymentList = new List<GameObject>();
    DeploymentMechDisplayPanel activeMech;
    DeploymentTankDisplayPanel activeTank;
    DeploymentVTOLDisplayPanel activeVTOL;
    DeploymentInfantryDisplayPanel activeInfantry;
    InventoryBayController inventoryBayScript;

    void Start()
    {
        SetWindow(0);
    }

    public void SetDeployementList()
    {
        SetWindow(currentWindowID);
    }

    public void TransferUnit()
    {
        switch (currentWindowID)
        {
            case 0:
                inventoryBayScript = inventoryPanel.GetComponent<InventoryBayController>();
                activeMech = selectedIcon.GetComponent<DeploymentMechDisplayPanel>();
                inventoryBayScript.mechs.Add(activeMech.thisPanelMech);
                mechs.Remove(activeMech.thisPanelMech);
                inventoryBayScript.SetDeployementList();
                SetDeployementList();
            break;
            case 1:
                inventoryBayScript = inventoryPanel.GetComponent<InventoryBayController>();
                activeTank = selectedIcon.GetComponent<DeploymentTankDisplayPanel>();
                inventoryBayScript.tanks.Add(activeTank.thisPanelTank);
                tanks.Remove(activeTank.thisPanelTank);
                inventoryBayScript.SetDeployementList();
                SetDeployementList();
                break;
            case 2:
                inventoryBayScript = inventoryPanel.GetComponent<InventoryBayController>();
                activeVTOL = selectedIcon.GetComponent<DeploymentVTOLDisplayPanel>();
                inventoryBayScript.VTOLs.Add(activeVTOL.thisPanelVTOL);
                VTOLs.Remove(activeVTOL.thisPanelVTOL);
                inventoryBayScript.SetDeployementList();
                SetDeployementList();
                break;
            case 3:
                inventoryBayScript = inventoryPanel.GetComponent<InventoryBayController>();
                activeInfantry = selectedIcon.GetComponent<DeploymentInfantryDisplayPanel>();
                inventoryBayScript.infantry.Add(activeInfantry.thisPanelInfantry);
                infantry.Remove(activeInfantry.thisPanelInfantry);
                inventoryBayScript.SetDeployementList();
                SetDeployementList();
                break;
        }
    }

    public void SetWindow(int windowID)
    {
        currentWindowID = windowID;
        int count;
        switch (windowID)
        {
            #region Case0
            case 0:
                foreach (GameObject c in activeDeploymentList)
                {
                    Destroy(c);
                }
                activeDeploymentList = new List<GameObject>();
                count = 0;
                foreach (MechClass b in mechs)
                {
                    count++;
                    activeDeploymentList.Add(currentInstantiate);
                    currentInstantiate = Instantiate(unitDeploymentPanel, transform, false);
                    DeploymentMechDisplayPanel currentPanelClass = currentInstantiate.GetComponent<DeploymentMechDisplayPanel>();
                    currentPanelClass.thisPanelMech = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                break;
            #endregion

            #region Case1
            case 1:
                foreach (GameObject c in activeDeploymentList)
                {
                    Destroy(c);
                }
                activeDeploymentList = new List<GameObject>();
                count = 0;
                foreach (TankClass b in tanks)
                {
                    count++;
                    activeDeploymentList.Add(currentInstantiate);
                    currentInstantiate = Instantiate(unitDeploymentPanel, transform, false);
                    DeploymentTankDisplayPanel currentPanelClass = currentInstantiate.GetComponent<DeploymentTankDisplayPanel>();
                    currentPanelClass.thisPanelTank = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                break;
            #endregion

            #region Case2
            case 2:
                foreach (GameObject c in activeDeploymentList)
                {
                    Destroy(c);
                }
                activeDeploymentList = new List<GameObject>();
                count = 0;
                foreach (VTOLClass b in VTOLs)
                {
                    count++;
                    activeDeploymentList.Add(currentInstantiate);
                    currentInstantiate = Instantiate(unitDeploymentPanel, transform, false);
                    DeploymentVTOLDisplayPanel currentPanelClass = currentInstantiate.GetComponent<DeploymentVTOLDisplayPanel>();
                    currentPanelClass.thisPanelVTOL = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                break;
            #endregion

            #region Case3
            case 3:
                foreach (GameObject c in activeDeploymentList)
                {
                    Destroy(c);
                }
                activeDeploymentList = new List<GameObject>();
                count = 0;
                foreach (InfantryClass b in infantry)
                {
                    count++;
                    activeDeploymentList.Add(currentInstantiate);
                    currentInstantiate = Instantiate(unitDeploymentPanel, transform, false);
                    DeploymentInfantryDisplayPanel currentPanelClass = currentInstantiate.GetComponent<DeploymentInfantryDisplayPanel>();
                    currentPanelClass.thisPanelInfantry = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                break;
            #endregion

            #region Case4
            case 4:
                foreach (GameObject c in activeDeploymentList)
                {
                    Destroy(c);
                }
                activeDeploymentList = new List<GameObject>();
                count = 0;
                foreach (MechClass b in mechs)
                {
                    count++;
                    activeDeploymentList.Add(currentInstantiate);
                    currentInstantiate = Instantiate(unitDeploymentPanel, transform, false);
                    DeploymentMechDisplayPanel currentPanelClass = currentInstantiate.GetComponent<DeploymentMechDisplayPanel>();
                    currentPanelClass.thisPanelMech = b;
                    currentPanelClass.unitName = b.unitName;
                    currentPanelClass.unitCost = b.purchaseCost;
                    currentPanelClass.unitTonnage = b.weight;
                    currentPanelClass.iconFileName = b.iconFileName;
                    currentPanelClass.parentPanel = this;
                }
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (count * 100) + 10);
                break;
                #endregion
        }
    }
}
