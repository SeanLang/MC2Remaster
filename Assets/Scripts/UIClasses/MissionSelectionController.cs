using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;

public class MissionSelectionController : MonoBehaviour {

    GameObject currentMissionIcon;

    public List<string> currentMissionNames = new List<string>();
    public List<MissionClass> currentMissionClasses = new List<MissionClass>();
    public GameObject missionIcon;
    public GameObject nextButton;
    public Text missionDescription;
    public VideoPlayer videoPlayer;

    void Start()
    {
        currentMissionNames = GameController.controller.activeMissionList;
        foreach (string a in currentMissionNames)
        {
            DirectoryInfo targetDirectory = new DirectoryInfo(Application.streamingAssetsPath + "/JSONs/MissionData");
            FileInfo[] fileInfoList = targetDirectory.GetFiles("*.*");
            List<string> fileList = new List<string>();
            foreach (FileInfo file in fileInfoList)
            {
                string targetFileName = Application.streamingAssetsPath + "/JSONs/MissionData/" + file.Name;
                fileList.Add(Path.GetFileNameWithoutExtension(targetFileName));
            }
                if (fileList.Contains(a))
                {
                    print(Application.streamingAssetsPath + "/JSONs/MissionData/" + a + ".json");
                    currentMissionClasses.Add(JsonUtility.FromJson<MissionClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/MissionData/" + a + ".json")));
                }
        }
        foreach (MissionClass a in currentMissionClasses)
        {
            currentMissionIcon = Instantiate(missionIcon, transform);
            currentMissionIcon.GetComponent<MissionButtonController>().missionClass = a;
            currentMissionIcon.GetComponent<MissionButtonController>().missionDescription = missionDescription;
            currentMissionIcon.GetComponent<MissionButtonController>().videoPlayer = videoPlayer;
            currentMissionIcon.GetComponent<MissionButtonController>().nextButton = nextButton;
        }
    }

    public void SetPurchaseLists()
    {
        GameController.controller.buyableMechList = GameController.controller.activeMission.mechShopList;
        GameController.controller.buyableVehicleList = GameController.controller.activeMission.vehicleShopList;
        GameController.controller.buyablePilotList = GameController.controller.activeMission.pilotShopList;
        GameController.controller.buyableConsumableList = GameController.controller.activeMission.consumableShopList;
    }
}
