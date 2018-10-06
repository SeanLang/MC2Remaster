using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class GameController : MonoBehaviour {


    public static GameController controller;

    public int money;
    public string missionName;
    public string campaignName;
    public string saveName;
    public MissionClass activeMission;

    public List<PilotClass> pilots = new List<PilotClass>();
    public List<UnitClass> mechs = new List<UnitClass>();
    public List<UnitClass> tanks = new List<UnitClass>();
    public List<UnitClass> infantry = new List<UnitClass>();
    public List<UnitClass> VTOLs = new List<UnitClass>();
    public List<UnitClass> aerospace = new List<UnitClass>();
    public List<DropShipClass> dropShips = new List<DropShipClass>();
    public List<MissionClass> missions = new List<MissionClass>();
    public List<CampaignClass> campaigns = new List<CampaignClass>();
    public List<ConsumableClass> weapons = new List<ConsumableClass>();

    public List<string> buyableVehicleList = new List<string>();
    public List<string> buyableMechList = new List<string>();
    public List<string> buyablePilotList = new List<string>();
    public List<string> buyabelWeaponList = new List<string>();
    public List<string> buyableConsumableList = new List<string>();
    public List<string> campaignList = new List<string>();
    public List<string> deploymentList = new List<string>();
    public List<string> pilotDeploymentList = new List<string>();
    public List<string> activeMissionList = new List<string>();
    public List<string> ownedTankList = new List<string>();
    public List<string> ownedMechList = new List<string>();
    public List<string> ownedInfantryList = new List<string>();
    public List<string> ownedVTOLList = new List<string>();
    public List<string> ownedAerospaceList = new List<string>();
    public List<string> ownedDropShipList = new List<string>();
    public List<string> ownedPilotList = new List<string>();
    public List<string> weaponList = new List<string>();



    void Awake ()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        loadData();
    }
	
	void Start ()
    {
        
    }

    public void saveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Open(Application.persistentDataPath + "/SaveFiles/" + saveName + ".dat", FileMode.Open);

        GameData saveData = new GameData();
        saveData.money = money;
        saveData.missionName = missionName;
        saveData.campaignName = campaignName;
        
        saveData.buyableMechList = buyableMechList;
        saveData.buyableTankList = buyableVehicleList;
        saveData.buyablePilotList = buyablePilotList;
        saveData.buyabelWeaponList = buyabelWeaponList;
        saveData.MechList = ownedMechList;
        saveData.TankList = ownedTankList;
        saveData.InfantryList = ownedInfantryList;
        saveData.VTOLList = ownedVTOLList;
        saveData.pilotList = ownedPilotList;
        saveData.weaponList = weaponList;
        saveData.campaignList = campaignList;
        saveData.missionList = activeMissionList;

        bf.Serialize(saveFile, saveData);
        saveFile.Close();
    }

    public void loadData()
    {
        #region Mechs
        DirectoryInfo targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/MechData");
        FileInfo[] fileInfoList = targetDirectory.GetFiles("*.*");
        List<string> fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/MechData/" + file.Name;
            fileList.Add (Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedMechList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json");
                mechs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MechData/" + a + ".json")));
            }
        }
        #endregion

        #region Tanks
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/VehicleData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/VehicleData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedTankList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/VehicleData/" + a + ".json");
                tanks.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/VehicleData/" + a + ".json")));
            }
        }
        #endregion

        #region Infantry
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/InfantryData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/InfantryData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedInfantryList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/InfantryData/" + a + ".json");
                infantry.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/InfantryData/" + a + ".json")));
            }
        }
        #endregion

        #region VTOL
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/VTOLData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/VTOLData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedVTOLList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/VTOLData/" + a + ".json");
                VTOLs.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/InfantryData/" + a + ".json")));
            }
        }
        #endregion

        #region Aerospace
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/AerospaceData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/AerospaceData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedAerospaceList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/AerospaceData/" + a + ".json");
                aerospace.Add(JsonUtility.FromJson<UnitClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/AerospaceData/" + a + ".json")));
            }
        }
        #endregion

        #region DropShips
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/DropShipData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/DropShipData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedDropShipList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/DropShipData/" + a + ".json");
                dropShips.Add(JsonUtility.FromJson<DropShipClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/DropShipData/" + a + ".json")));
            }
        }
        #endregion

        #region Missions
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/MissionData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/MissionData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in activeMissionList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/MissionData/" + a + ".json");
                missions.Add(JsonUtility.FromJson<MissionClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MissionData/" + a + ".json")));
            }
        }
        #endregion

        #region Weapons
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/WeaponData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/WeaponData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in weaponList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/WeaponData/" + a + ".json");
                weapons.Add(JsonUtility.FromJson<ConsumableClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/WeaponData/" + a + ".json")));
            }
        }
        #endregion

        #region Campaigns
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/CampaignData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/CampaignData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in campaignList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/CampaignData/" + a + ".json");
                campaigns.Add(JsonUtility.FromJson<CampaignClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/CampaignData/" + a + ".json")));
            }
        }
        #endregion

        #region Pilots
        targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/PilotData");
        fileInfoList = targetDirectory.GetFiles("*.*");
        fileList = new List<string>();
        foreach (FileInfo file in fileInfoList)
        {
            string targetFileName = Application.streamingAssetsPath + "/JSONs/PilotData/" + file.Name;
            fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
        }
        foreach (string a in ownedPilotList)
        {
            if (fileList.Contains(a))
            {
                print(Application.streamingAssetsPath + "/JSONs/CampaignData/" + a + ".json");
                pilots.Add(JsonUtility.FromJson<PilotClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/PilotData/" + a + ".json")));
            }
        }
        #endregion

    }
}


[Serializable]
class GameData
{
    public int money;
    public string missionName;
    public string campaignName;

    public List<string> unitList = new List<string>();
    public List<string> buyableMechList = new List<string>();
    public List<string> buyableTankList = new List<string>();
    public List<string> buyableInfantryList = new List<string>();
    public List<string> buyableVTOLList = new List<string>();
    public List<string> buyablePilotList = new List<string>();
    public List<string> buyabelWeaponList = new List<string>();
    public List<string> TankList = new List<string>();
    public List<string> MechList = new List<string>();
    public List<string> InfantryList = new List<string>();
    public List<string> VTOLList = new List<string>();
    public List<string> pilotList = new List<string>();
    public List<string> weaponList = new List<string>();
    public List<string> campaignList = new List<string>();
    public List<string> missionList = new List<string>();
}
