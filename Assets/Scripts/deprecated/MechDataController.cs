using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MechDataController : MonoBehaviour {

    List<GameObject> equipment = new List<GameObject>();
    List<GameObject> parts = new List<GameObject>();
    public GameObject currentEquipment;
    public string loadoutTargetFile;
    public MechData mechData;
    public ComponentLoadout componentLoadout;
    public string mechListTargetPath;
    string equipTargetFile;
    string mechTargetFile;
    string jsonAsData;
    string filePath;
    private string dataProjectFilePath = "/StreamingAssets/JSONs/";


    void Start ()
    {
        //filePath = Application.dataPath + dataProjectFilePath + mechTargetFile + (".json");
        //jsonAsData = File.ReadAllText(filePath);
        //mechData = JsonUtility.FromJson<MechData>(jsonAsData);
        //LoadMech();

        //filePath = Application.dataPath + dataProjectFilePath + loadoutTargetFile + (".json");
        //jsonAsData = File.ReadAllText(filePath);
        //componentLoadout = JsonUtility.FromJson<ComponentLoadout>(jsonAsData);
       // EquipMech("red");

        //string jsonAsData = JsonUtility.ToJson(mechData);
        //string filePath = Application.dataPath + dataProjectFilePath + targetFile + (".json");
        //File.WriteAllText(filePath, jsonAsData);

    }

    public void LoadMech(string partsTargetFile)
    {
        filePath = Application.dataPath + dataProjectFilePath + partsTargetFile + (".json");
        jsonAsData = File.ReadAllText(filePath);
        mechData = JsonUtility.FromJson<MechData>(jsonAsData);

        if (mechData != null)
        {
            if (parts != null)
            {
                foreach (GameObject part in parts)
                {
                    Destroy(part);
                }
                parts.Clear();
            }

            foreach(Vector3 entry in mechData.ComponentPositions)
            {
                    int currentArrayPosition = System.Array.IndexOf(mechData.ComponentPositions, entry);
                    if (mechData.ComponentPrefabs[currentArrayPosition] != null)
                    {
                        print(currentArrayPosition);
                        print(mechData.ComponentPrefabs[currentArrayPosition]);
                        GameObject currentPart = Instantiate(mechData.ComponentPrefabs[currentArrayPosition], mechData.ComponentPositions[currentArrayPosition], Quaternion.identity);
                        parts.Add(currentPart);
                    }
            }
        }
    }
    public void EquipMech(string equipTargetFile)
    {
        filePath = Application.dataPath + dataProjectFilePath + equipTargetFile + (".json");
        jsonAsData = File.ReadAllText(filePath);
        componentLoadout = JsonUtility.FromJson<ComponentLoadout>(jsonAsData);

        if (componentLoadout != null)
        {
            if (equipment != null)
            {
                foreach (GameObject part in equipment)
                {
                    Destroy(part);
                }
                equipment.Clear();
            }

            foreach (Vector3 entry in componentLoadout.equipmentLocations)
            {
                int currentArrayPosition = System.Array.IndexOf(componentLoadout.equipmentLocations, entry);
                if (componentLoadout.equipmentPrefabs[currentArrayPosition] != null)
                {
                    print(currentArrayPosition);
                    print(componentLoadout.equipmentPrefabs[currentArrayPosition]);
                    currentEquipment = Instantiate(componentLoadout.equipmentPrefabs[currentArrayPosition], componentLoadout.equipmentLocations[currentArrayPosition], Quaternion.identity);
                    equipment.Add(currentEquipment);
                }
        }
        }
    }
}
