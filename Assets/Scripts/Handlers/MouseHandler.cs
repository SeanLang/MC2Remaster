using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour {

    [SerializeField]
    private string strMouseAxisScrollWheel = "Mouse ScrollWheel";

    [SerializeField]
    private string strMouseAxisX = "Mouse X";

    [SerializeField]
    private string strMouseAxisY = "Mouse Y";

    public Vector2 inputMouse
    {
        get { return Input.mousePosition; }
    }
    public float inputScrollWheel
    {
        get { return Input.GetAxis(strMouseAxisScrollWheel); }
    }
    public float axisMouseX
    {
        get { return Input.GetAxis(strMouseAxisX); }
    }
    public float axisMouseY
    {
        get { return Input.GetAxis(strMouseAxisY); }
    }
    public Vector2 axisMouse
    {
        get { return new Vector2(axisMouseX, axisMouseY); }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
