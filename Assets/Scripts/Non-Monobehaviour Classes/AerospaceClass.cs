using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AerospaceClass {

    public string Name;
    public List<string> equipmentName = new List<string>();
    public int armour;
    public int armourMax;
    public int upkeepCost;
    public int speed;
    public int sensorRange;
    public int visionRangs;
    public int purchaseCost;
}
