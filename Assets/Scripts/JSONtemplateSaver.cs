using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


[System.Serializable]
public class JSONtemplateSaver : MonoBehaviour {

    public string weaponTemplateName;
    public WeaponClass weaponTemplate;
    public string mechTemplateName;
    public MechClass mechTemplate;
    public string tankTemplateName;
    public TankClass tankTemplate;
    public string infantryTemplateName;
    public InfantryClass infantryTemplate;
    public string VTOLTemplateName;
    public VTOLClass VTOLTemplate;
    public string aerospaceTemplateName;
    public AerospaceClass aerospaceTemplate;
    public string dropShipTemplateName;
    public DropShipClass dropShipTemplate;
    public string pilotTemplateName;
    public PilotClass pilotTemplate;
    public string missionTemplateName;
    public MissionClass missionTemplate;
    public string campaignTemplateName;
    public CampaignClass campaignTemplate;
    public CampaignListClass campaignList;

    void Start () {

        #region Weapon Save
        string jsonAsData = JsonConvert.SerializeObject(weaponTemplate, Formatting.Indented);
        string filePath = Application.streamingAssetsPath + "/JSONs/WeaponData/" + weaponTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("weapon");
        #region Mech Save
        jsonAsData = JsonConvert.SerializeObject(mechTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/MechData/" + mechTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("mech");
        #region Tank Save
        jsonAsData = JsonConvert.SerializeObject(tankTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/TankData/" + tankTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("tank");
        #region Infantry Save
        jsonAsData = JsonConvert.SerializeObject(infantryTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/InfantryData/" + infantryTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("infantry");
        #region VTOL Save
        jsonAsData = JsonConvert.SerializeObject(VTOLTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/VTOLData/" + VTOLTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("VTOL");
        #region Aerospace Save
        jsonAsData = JsonConvert.SerializeObject(aerospaceTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/AerospaceData/" + aerospaceTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("aerospace");
        #region DropShip Save
        jsonAsData = JsonConvert.SerializeObject(dropShipTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/DropShipData/" + dropShipTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("dropship");
        #region Pilot Save
        jsonAsData = JsonConvert.SerializeObject(pilotTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/PilotData/" + pilotTemplate + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("pilot");
        #region Mission Save
        jsonAsData = JsonConvert.SerializeObject(missionTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/MissionData/" + missionTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("mission");
        #region Campaign Save
        jsonAsData = JsonConvert.SerializeObject(campaignTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/CampaignData/" + campaignTemplate + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        print("campaign");

        jsonAsData = JsonConvert.SerializeObject(campaignList, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/CampaignData/campaignList.json";
        File.WriteAllText(filePath, jsonAsData);


    }


    void Update () {
		
	}
}
