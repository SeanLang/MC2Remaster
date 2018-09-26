using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MissionButtonController : MonoBehaviour {

    public MissionClass missionClass;
    public Text missionDescription;
    public VideoPlayer videoPlayer;
    public GameObject nextButton;

    void Start ()
    {
        this.name = missionClass.sceneName;
        missionDescription.text = missionClass.missionDescription;
        transform.localPosition = missionClass.missionIconLocation;
    }
    
    public void SetActiveMission ()
    {
        GameController.controller.activeMission = missionClass;
    }

    public void ActivateNextButton()
    {
        nextButton.SetActive(true);
    }
}
