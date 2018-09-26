using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitClass{

    public string unitName;
    public string iconFileName;
    public List<string> equipmentSlot = new List<string>();
    public List<string> equipmentName = new List<string>();
    public int weight;
    public int armour;
    public int maxArmour;
    public int heat;
    public int maxHeat;
    public int speed;
    public int sensorRange;
    public int visionRange;
    public int upkeepCost;
    public int purchaseCost;
}
