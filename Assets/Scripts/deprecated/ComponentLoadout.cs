using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComponentLoadout
{
    public string jsonType = "LoadoutData";
    public Vector3[] equipmentLocations;
    public GameObject[] equipmentPrefabs;
    public int armourMax;
    public int armourValue;
    public int internalMax;
    public int internalValue;
    public string[] equipmentArray;
}
