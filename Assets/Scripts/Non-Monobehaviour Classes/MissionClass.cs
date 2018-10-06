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
    public List<string> vehicleShopList = new List<string>();
    public List<string> equipmentShopList = new List<string>();
    public List<string> pilotShopList = new List<string>();
    public List<string> consumableShopList = new List<string>();
    public List<string> nextMissionsList = new List<string>();
    public Vector2 missionIconLocation;

}
