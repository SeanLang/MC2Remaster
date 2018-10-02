using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignButtonController : MonoBehaviour {

    public CampaignClass campaignClass;
    public GameObject nextButton;
    public Text description;
    public Text title;
    public int test;

    public void SetCampaignText ()
    {
        //title.text = campaignClass.campaignName;
        //description.text = campaignClass.campaignDescription;
        GameController.controller.activeMissionList = campaignClass.missionList;
    }

    public void ActivateNextButton()
    {
        nextButton.SetActive(true);
    }

	void Start () {

	}
	
	void Update () {
		
	}
}
