using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechLabButtonController : MonoBehaviour {

    public int equipmentID;


    void Start () {
		
	}
	
	void Update () {
		
	}

    public void SetActiveTabEquipment(int activeEquipmentTab)
    {
        if (equipmentID != activeEquipmentTab)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
