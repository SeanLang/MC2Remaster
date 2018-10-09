using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour {

    public KeyCode keyZoomIn = KeyCode.Plus;
    public KeyCode keyZoomOut = KeyCode.Minus;

    public KeyCode keyTiltUp = KeyCode.UpArrow;
    public KeyCode keyTiltDown = KeyCode.DownArrow;

    public KeyCode keyRotateLeft = KeyCode.Q;
    public KeyCode keyRotateRight = KeyCode.E;
    public KeyCode keyMouseRotation = KeyCode.Mouse1;

    [SerializeField]
    private string strKeyboardHorizontalAxis = "Horizontal";

    [SerializeField]
    private string strKeyboardVerticalAxis = "Vertical";

    public Vector2 inputKeyboard
    {
        get
        {
            return new Vector2(
                Input.GetAxis(strKeyboardHorizontalAxis), 
                Input.GetAxis(strKeyboardVerticalAxis));
        }
    }

    public int rotateDirection
    {
        get
        {
            bool left = Input.GetKey(keyRotateLeft);
            bool right = Input.GetKey(keyRotateRight);

            if (left && right)
            {
                return 0;
            }
            else if (left && !right)
            {
                return -1;
            }
            else if (!left && right)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
