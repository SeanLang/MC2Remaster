using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform mTransform;
    public Transform target;

    public bool followingTarget = false;

    //public float panSpeed = 100f;
    //public float panBorderPadding = 10f;
    //public Vector2 panLimit;

    public float minFOV = 10f;
    public float maxFOV = 40f;

    public bool useFixedCamera = true;
    public Vector3 fixedCameraStartingPosition = new Vector3(256f, 256f, -256f);
    public Vector3 fixedCameraStartingLookPoint = new Vector3(45f, -45f, 0f);

    // Keyboard
    public bool useKeyboardCameraPanning = true;
    public bool useKeyboardRotation = false;

    private Vector2 inputKeyboard
    {
        get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
    }

    public float keyboardPanningSensitivity = 200f;
    private int keyboardRotationDirection
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
    public float keyboardRotationSensitivity = 100f;

    // Mouse
    public bool useMouseCameraPanning = true;
    public bool useMouseRotation = false;

    public float mousePanningSensitivity = 200f;
    public float mousePanningBorderPadding = 25f;
    public Vector2 mousePanningBorderLimits;

    private Vector2 inputMouse
    {
        get { return Input.mousePosition; }
    }
    private float inputScrollWheel
    {
        get { return Input.GetAxis("Mouse ScrollWheel"); }
    }
    private float axisMouseX
    {
        get { return Input.GetAxis("Mouse X"); }
    }
    private float axisMouseY
    {
        get { return Input.GetAxis("Mouse Y"); }
    }
    private Vector2 axisMouse
    {
        get { return new Vector2(axisMouseX, axisMouseY); }
    }

    public float mouseLookSensitivity = 5f;
    public float mouseZoomSensitivity = 20f;

    #region Input

    // Default Input Mapping
    public KeyCode keyZoomIn = KeyCode.Plus;
    public KeyCode keyZoomOut = KeyCode.Minus;

    public KeyCode keyTiltUp = KeyCode.UpArrow;
    public KeyCode keyTiltDown = KeyCode.DownArrow;

    public KeyCode keyRotateLeft = KeyCode.Q;
    public KeyCode keyRotateRight = KeyCode.E;
    public KeyCode keyMouseRotation = KeyCode.Mouse1;

    #endregion

    private void Start()
    {
        mTransform = transform;

        if (useFixedCamera)
        {
            transform.position = fixedCameraStartingPosition;
            transform.LookAt(fixedCameraStartingLookPoint);
        }
    }

    // Update is called once per frame
    private void Update() {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (followingTarget)
        {

        }
        else
        {
            CameraMove();
        }

        if (useKeyboardRotation || useMouseRotation)
        {
            CameraRotation();
        }

        CameraZoom();
    }
    
    private void CameraRotation()
    {
        if (useKeyboardRotation)
        {
            mTransform.Rotate(Vector3.up, keyboardRotationDirection * Time.deltaTime * keyboardRotationSensitivity, Space.World);
        }

        if (useMouseRotation && Input.GetKey(keyMouseRotation))
        {
            float xRotation = mTransform.localEulerAngles.y + axisMouse.x * mouseLookSensitivity;
            float yRotation = ClampAngle(mTransform.localEulerAngles.x - axisMouse.y * mouseLookSensitivity, 0f, 90f);

            //mTransform.localEulerAngles = new Vector3(yRotation, xRotation, 0f);
            mTransform.localRotation = Quaternion.Euler(new Vector3(yRotation, xRotation, 0f));
            //mTransform.Rotate(new Vector3(yRotation, xRotation, 0f));
        }
    }

    private void CameraZoom()
    {
        float fov = Camera.main.fieldOfView;
        fov -= inputScrollWheel * mouseZoomSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }

    private void CameraMove()
    {
        if (useKeyboardCameraPanning)
        {
            Vector3 cPos = new Vector3(inputKeyboard.x, 0f, inputKeyboard.y);
            Vector3 velocity = Vector3.zero;

            float fov = Camera.main.fieldOfView;
            float zoomedPanningSensitivity = Mathf.Round(fov * 100);

            if (zoomedPanningSensitivity < keyboardPanningSensitivity)
            {
                cPos *= zoomedPanningSensitivity;
            }
            else
            {
                cPos *= keyboardPanningSensitivity;
            }

            cPos *= Time.deltaTime;
            cPos = Quaternion.Euler(new Vector3(0f, mTransform.eulerAngles.y, 0f)) * cPos;
            cPos = mTransform.InverseTransformDirection(cPos);

            mTransform.Translate(cPos, Space.Self);
        }

        if (useMouseCameraPanning)
        {
            Vector3 cPos = new Vector3();

            float fov = Camera.main.fieldOfView;
            float zoomedPanningSensitivity = Mathf.Round(fov * 100);

            Rect leftRect = new Rect(0, 0, mousePanningBorderPadding, Screen.height);
            Rect rightRect = new Rect(Screen.width - mousePanningBorderPadding, 0, mousePanningBorderPadding, Screen.height);
            Rect upRect = new Rect(0, Screen.height - mousePanningBorderPadding, Screen.width, mousePanningBorderPadding);
            Rect downRect = new Rect(0, 0, Screen.width, mousePanningBorderPadding);

            cPos.x = leftRect.Contains(inputMouse) ? -1 : rightRect.Contains(inputMouse) ? 1 : 0;
            cPos.z = upRect.Contains(inputMouse) ? 1 : downRect.Contains(inputMouse) ? -1 : 0;

            if (zoomedPanningSensitivity < mousePanningSensitivity)
            {
                cPos *= zoomedPanningSensitivity;
            }
            else
            {
                cPos *= mousePanningSensitivity;
            }

            cPos *= Time.deltaTime;
            cPos = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)) * cPos;
            cPos = mTransform.InverseTransformDirection(cPos);

            mTransform.Translate(cPos, Space.Self);
        }

/*        if (Input.GetKey(KeyCode.W) || inputMouse.y >= Screen.height - panBorderPadding)
        {
            tPos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || inputMouse.y <= panBorderPadding)
        {
            tPos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || inputMouse.x >= Screen.width - panBorderPadding)
        {
            tPos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || inputMouse.x <= panBorderPadding)
        {
            tPos.x -= panSpeed * Time.deltaTime;
        }

        tPos.x = Mathf.Clamp(tPos.x, -panLimit.x, panLimit.x);
        tPos.y = Mathf.Clamp(tPos.y, minY, maxY);
        tPos.z = Mathf.Clamp(tPos.z, -panLimit.y, panLimit.y);

        mTransform.position = tPos;*/
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;

        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }

        return Mathf.Clamp(angle, min, max);
    }
}
