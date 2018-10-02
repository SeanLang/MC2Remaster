using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionClass  {

    public string sceneName;
    public string missionDescription;
    public string missionBriefing;
    public int missionReward;
    public List<string> mechShopList = new List<string>();
    public List<string> tankShopList = new List<string>();
    public List<string> VTOLShopList = new List<string>();
    public List<string> InfantryShopList = new List<string>();
    public List<string> pilotPurchaseList = new List<string>();
    public List<string> nextMissionsList = new List<string>();
    public Vector2 missionIconLocation;

}
