using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class MechLabController : MonoBehaviour {

    public int activeItemID;
    public int currentEquipmentTabID;
    public int currentSlotVerticalCount;
    public int currentSlotHorizontalCount;

    public string currentItemName;
    public string targetFile;
    string jsonAsData;
    string dataProjectFilePath = "/StreamingAssets/JSONs/";

    public Color Short;
    public Color Medium;
    public Color Long;
    public Color Equipment;
    public Color blank;

    public UnitClass mechDataStorage;
    public WeaponIconClass[] weaponIcons;
    public MechLabButtonController[] equipmentButtons;
    public Color currentIconColour;

    void Start () {
		
	}
	
	void Update () {
        switch (activeItemID)
        {
            case 0:
                currentIconColour = Short;
                currentSlotVerticalCount = 2;
                currentSlotHorizontalCount = 3;
                currentItemName = "Heavy Autocannon";
                break;
            case 1:
                currentIconColour = Medium;
                currentSlotVerticalCount = 2;
                currentSlotHorizontalCount = 2;
                currentItemName = "Medium Autocannon";
                break;
            case 2:
                currentIconColour = Long;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 2;
                currentItemName = "Light Autocannon";
                break;
            case 3:
                currentIconColour = Short;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 1;
                currentItemName = "Machine Gun";
                break;
            case 4:
                currentIconColour = Short;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 1;
                currentItemName = "Small Laser";
                break;
            case 5:
                currentIconColour = Medium;
                currentSlotVerticalCount = 2;
                currentSlotHorizontalCount = 1;
                currentItemName = "Medium Laser";
                break;
            case 6:
                currentIconColour = Medium;
                currentSlotVerticalCount = 3;
                currentSlotHorizontalCount = 1;
                currentItemName = "Large Laser";
                break;
            case 7:
                currentIconColour = Short;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 1;
                currentItemName = "Flamer";
                break;
            case 8:
                currentIconColour = Long;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 1;
                currentItemName = "LRM";
                break;
            case 9:
                currentIconColour = Short;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 1;
                currentItemName = "SRM";
                break;
            case 10:
                currentIconColour = Long;
                currentSlotVerticalCount = 2;
                currentSlotHorizontalCount = 3;
                currentItemName = "Gauss";
                break;
            case 11:
                currentIconColour = blank;
                currentSlotVerticalCount = 1;
                currentSlotHorizontalCount = 1;
                currentItemName = "none";
                break;
        }
    }

    public void SetTabID(int tabID)
    {
        currentEquipmentTabID = tabID;
        foreach(MechLabButtonController button in equipmentButtons)
        {
            button.SetActiveTabEquipment(currentEquipmentTabID);
        }
    }

    public void SetItemID (int itemID)
    {
        activeItemID = itemID;
    }

    public void AddLoadoutItem( GameObject activeCell)
    {
        if (currentItemName != "none")
        {
            if (!mechDataStorage.equipmentSlot.Contains(activeCell.name))
            {
                mechDataStorage.equipmentSlot.Add(activeCell.name);
                mechDataStorage.equipmentName.Add(currentItemName);
            }
            else
            {
                mechDataStorage.equipmentName.RemoveAt(mechDataStorage.equipmentSlot.IndexOf(activeCell.name));
                mechDataStorage.equipmentSlot.Remove(activeCell.name);
                mechDataStorage.equipmentSlot.Add(activeCell.name);
                mechDataStorage.equipmentName.Add(currentItemName);
            }
        }
        else
        {
            mechDataStorage.equipmentName.RemoveAt(mechDataStorage.equipmentSlot.IndexOf(activeCell.name));
            mechDataStorage.equipmentSlot.Remove(activeCell.name);
        }
    }

    public void SaveChasis()
    {
        jsonAsData = JsonConvert.SerializeObject(mechDataStorage, Formatting.Indented);
        string filePath = Application.dataPath + dataProjectFilePath + targetFile + (".json");
        File.WriteAllText(filePath, jsonAsData);
        print("done");
    }
}
