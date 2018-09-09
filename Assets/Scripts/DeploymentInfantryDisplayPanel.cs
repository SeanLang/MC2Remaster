using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeploymentInfantryDisplayPanel : MonoBehaviour {

    public int unitCost;
    public int unitTonnage;
    public string unitName;
    public string iconFileName;
    public Sprite iconSprite;
    public DeploymentBayController parentPanel;
    public InfantryClass thisPanelInfantry;

    public Text nameObject;
    public Text costObject;
    public Text tonnageObject;
    public Image iconObject;

	void Start () {
        gameObject.name = unitName;
        nameObject.text = unitName;
        tonnageObject.text = unitTonnage.ToString();
        iconObject.sprite = Resources.Load<Sprite>("UnitIcons/Mechs/" + iconFileName);

    }

    public void RemoveFromInventory()
    {
        parentPanel.selectedIcon = gameObject;
    }

    void Update () {
		
	}
}
