using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class CampaignListController : MonoBehaviour {

    public CampaignListClass campaignList;
    public List<CampaignClass> campaignClassList = new List<CampaignClass>();
    public GameObject campaignPanel;
    public Text titlePanel;
    public Text descriptionPanel;
    GameObject currentPanel;

	void Start () {

        campaignList = JsonUtility.FromJson<CampaignListClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/CampaignData/CampaignList.json"));


        foreach (string a in campaignList.campaignList)
        {
            campaignClassList.Add(JsonUtility.FromJson<CampaignClass>(File.ReadAllText(Application.streamingAssetsPath + "/JSONs/CampaignData/" + a + ".json")));
        }

        foreach (CampaignClass a in campaignClassList)
        {
            currentPanel = Instantiate(campaignPanel, transform, false);
            currentPanel.GetComponent<CampaignButtonController>().campaignClass = a;
            currentPanel.GetComponentInChildren<Text>().text = a.campaignName;
            currentPanel.GetComponent<CampaignButtonController>().title = titlePanel;
            currentPanel.GetComponent<CampaignButtonController>().description = descriptionPanel;
        }
	}
	
	void Update () {
		
	}
}
