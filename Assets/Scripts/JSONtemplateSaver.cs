using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


[System.Serializable]
public class JSONtemplateSaver : MonoBehaviour {

    public string weaponTemplateName;
    public ConsumableClass weaponTemplate;
    public string mechTemplateName;
    public UnitClass unitTemplate;
    public string dropShipTemplateName;
    public DropShipClass dropShipTemplate;
    public string pilotTemplateName;
    public PilotClass pilotTemplate;
    public string missionTemplateName;
    public MissionClass missionTemplate;
    public string campaignTemplateName;
    public CampaignClass campaignTemplate;
    public CampaignListClass campaignList;
    public string consumableTemplateName;
    public ConsumableClass consumableTemplate;

    void Start () {

        #region Weapon Save
        string jsonAsData = JsonConvert.SerializeObject(weaponTemplate, Formatting.Indented);
        string filePath = Application.streamingAssetsPath + "/JSONs/WeaponData/" + weaponTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region Unit Save
        jsonAsData = JsonConvert.SerializeObject(unitTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/MechData/" + mechTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region DropShip Save
        jsonAsData = JsonConvert.SerializeObject(dropShipTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/DropShipData/" + dropShipTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region Pilot Save
        jsonAsData = JsonConvert.SerializeObject(pilotTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/PilotData/" + pilotTemplate + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region Mission Save
        jsonAsData = JsonConvert.SerializeObject(missionTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/MissionData/" + missionTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region Campaign Save
        jsonAsData = JsonConvert.SerializeObject(campaignTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/CampaignData/" + campaignTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region Consumable Save
        jsonAsData = JsonConvert.SerializeObject(consumableTemplate, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/ConsumableData/" + consumableTemplateName + (".json");
        File.WriteAllText(filePath, jsonAsData);
        #endregion
        #region Campaign List Save
        jsonAsData = JsonConvert.SerializeObject(campaignList, Formatting.Indented);
        filePath = Application.streamingAssetsPath + "/JSONs/CampaignData/campaignList.json";
        File.WriteAllText(filePath, jsonAsData);
        #endregion


    }


    void Update () {
		
	}
}
