using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedHandler : MonoBehaviour {

    [SerializeField]
    private Material selectedMechMaterial;

    [SerializeField]
    private Material defaultMechMaterial;

    private MeshRenderer objMeshRend;
    private Text objSelected;

    public bool isSelected = false;

	// Use this for initialization
	void Start () {
        objMeshRend = GetComponent<MeshRenderer>();
        objSelected = GameObject.Find("SelectedObject").GetComponent<Text>();

        Selected();
	}

    public void Selected ()
    {
        if (isSelected)
        {
            objMeshRend.material = selectedMechMaterial;
            objSelected.text = objMeshRend.gameObject.name;
        }
        else
        {
            objMeshRend.material = defaultMechMaterial;
            objSelected.text = "Selected Mech";
        }
    }
}
