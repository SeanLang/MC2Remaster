using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VTOLClass {

    public string unitName;
    public string iconFileName;
    public List<string> equipmentName = new List<string>();
    public int armour;
    public int maxArmour;
    public int upkeepCost;
    public int speed;
    public int weight;
    public int sensorRange;
    public int visionRangs;
    public int purchaseCost;
}
