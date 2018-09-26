using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBillController : MonoBehaviour {

    public Text cBillText;

	void Start () {

    }
	
	void Update ()
    {
        cBillText.text = GameController.controller.money.ToString();
    }
}
