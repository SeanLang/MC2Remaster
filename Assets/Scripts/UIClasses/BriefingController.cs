using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefingController : MonoBehaviour {

    public Text briefing;
    public Image Map;

	void Start () {
        briefing.text = GameController.controller.activeMission.missionBriefing;
	}
	
	void Update () {
		
	}
}
