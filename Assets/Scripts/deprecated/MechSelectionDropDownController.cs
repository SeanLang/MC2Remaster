using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class MechSelectionDropDownController : MonoBehaviour {

    Dropdown dropDown;
    List<string> mechList;
    List<string> equipmentList;
    GameObject targetObject;
    public MechArray mechArray;
    public GameObject targetMechBase;
    public string jsonAsData;
    public string filePath;
    public string mechListTargetPath;
    public string equipmentListTargetPath;
    string equipmentFile;
    string partsFile;
    string dataProjectFilePath = "/StreamingAssets/JSONs/";
    int dropDownValue;

    void Start () {
        filePath = Application.dataPath + dataProjectFilePath + mechListTargetPath + (".json");
        jsonAsData = File.ReadAllText(filePath);
        mechArray = JsonUtility.FromJson<MechArray>(jsonAsData);
        LoadList();
    }
	

	void Update () {
        
    }

    void LoadList()
    {
        mechList = mechArray.listOfAvailableMechs.ToList();
        equipmentList = mechArray.listOfLoadouts.ToList();
        dropDown = gameObject.GetComponent<Dropdown>();
        dropDown.AddOptions(mechList);
    }

    public void AssignMechFiles()
    {
        dropDownValue = gameObject.GetComponent<Dropdown>().value;
        if (targetMechBase.GetComponent<MechDataController>())
        {
            equipmentFile = equipmentList[dropDownValue];
            targetMechBase.GetComponent<MechDataController>().EquipMech(equipmentFile);
        }
        if (targetMechBase.GetComponent<MechDataController>())
        {
            partsFile = mechList[dropDownValue];
            targetMechBase.GetComponent<MechDataController>().LoadMech(partsFile);
        }
    }
}
