using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignButtonController : MonoBehaviour {

    public CampaignClass campaignClass;
    public Text description;
    public Text title;
    public int test;

    public void SetCampaignText ()
    {
        title.text = campaignClass.campaignName;
        description.text = campaignClass.campaignDescription;
        GameController.controller.activeMissionList = campaignClass.missionList;
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
