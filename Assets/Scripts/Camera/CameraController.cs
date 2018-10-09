using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private KeyboardHandler kbHandler;
    private MouseHandler mHandler;

    private Transform mTransform;
    public Transform target;

    public bool followingTarget = false;

    public float minFOV = 10f;
    public float maxFOV = 40f;

    public bool useFixedCamera = true;
    public Vector3 fixedCameraStartingPosition = new Vector3(256f, 256f, -256f);
    public Vector3 fixedCameraStartingLookPoint = new Vector3(45f, -45f, 0f);
    public Vector3 fixedCameraPanningXLimits = new Vector3(0f, 0f, 900f);
    public Vector3 fixedCameraPanningZLimits = new Vector3(-400f, 0f, 600f);

    // Keyboard
    public bool useKeyboardCameraPanning = true;
    public bool useKeyboardRotation = false;

    public float keyboardPanningSensitivity = 200f;
    public float keyboardRotationSensitivity = 100f;

    // Mouse
    public bool useMouseCameraPanning = true;
    public bool useMouseRotation = false;

    public float mousePanningSensitivity = 200f;
    public float mousePanningBorderPadding = 25f;
    public Vector2 mousePanningBorderLimits;

    public float mouseLookSensitivity = 5f;
    public float mouseZoomSensitivity = 42f;

    #region Input

    // Default Input Mapping


    #endregion

    private void Awake()
    {
        kbHandler = GetComponent<KeyboardHandler>();
        mHandler = GetComponent<MouseHandler>();
    }

    private void Start()
    {
        mTransform = transform;

        if (useFixedCamera)
        {
            mTransform.position = fixedCameraStartingPosition;
            mTransform.LookAt(fixedCameraStartingLookPoint);
        }
        else
        {
            // Initiate Rotational Camera
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
            mTransform.Rotate(Vector3.up, kbHandler.rotateDirection * Time.deltaTime * keyboardRotationSensitivity, Space.World);
        }

        if (useMouseRotation && Input.GetKey(kbHandler.keyMouseRotation))
        {
            float xRotation = mTransform.localEulerAngles.y + mHandler.axisMouse.x * mouseLookSensitivity;
            float yRotation = Calculations.ClampAngle(mTransform.localEulerAngles.x - mHandler.axisMouse.y * mouseLookSensitivity, 0f, 90f);

            //mTransform.localEulerAngles = new Vector3(yRotation, xRotation, 0f);
            mTransform.localRotation = Quaternion.Euler(new Vector3(yRotation, xRotation, 0f));
            //mTransform.Rotate(new Vector3(yRotation, xRotation, 0f));
        }
    }

    private void CameraZoom()
    {
        float fov = Camera.main.fieldOfView;

        fov -= mHandler.inputScrollWheel * mouseZoomSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        
        Camera.main.fieldOfView = fov;
        //Camera.main.fieldOfView = Mathf.Round(Mathf.Lerp(Camera.main.fieldOfView, fov, Time.deltaTime * mouseZoomSensitivity));
    }

    private void CameraMove()
    {
        if (useKeyboardCameraPanning)
        {
            Vector3 cPos = mTransform.position;
            Vector3 cMove = new Vector3(kbHandler.inputKeyboard.x, 0f, kbHandler.inputKeyboard.y);
            Vector3 velocity = Vector3.zero;

            float fov = Camera.main.fieldOfView;
            float zoomedPanningSensitivity = fov * 100;

            // ### WIP ### Dynamic panning sensitivity while zoomed
            // Disabled
            if (fov < maxFOV)
            {
                //cPos *= zoomedPanningSensitivity;
                cMove *= keyboardPanningSensitivity;
            }
            else
            {
                cMove *= keyboardPanningSensitivity;
            }

            cMove *= Time.deltaTime;
            cMove = Quaternion.Euler(new Vector3(0f, mTransform.eulerAngles.y, 0f)) * cMove;
            cMove = mTransform.InverseTransformDirection(cMove);

            mTransform.Translate(cMove, Space.Self);

            cPos = mTransform.position;
            cPos.x = Mathf.Clamp(cPos.x, fixedCameraPanningXLimits.x, fixedCameraPanningXLimits.z);
            cPos.z = Mathf.Clamp(cPos.z, fixedCameraPanningZLimits.x, fixedCameraPanningZLimits.z);

            mTransform.position = cPos;
        }

        if (useMouseCameraPanning)
        {
            Vector3 cPos = mTransform.position;
            Vector3 cMove = new Vector3();

            float fov = Camera.main.fieldOfView;
            float zoomedPanningSensitivity = fov * 100;

            Rect leftRect = new Rect(0, 0, mousePanningBorderPadding, Screen.height);
            Rect rightRect = new Rect(Screen.width - mousePanningBorderPadding, 0, mousePanningBorderPadding, Screen.height);
            Rect upRect = new Rect(0, Screen.height - mousePanningBorderPadding, Screen.width, mousePanningBorderPadding);
            Rect downRect = new Rect(0, 0, Screen.width, mousePanningBorderPadding);

            cMove.x = leftRect.Contains(mHandler.inputMouse) ? -1 : rightRect.Contains(mHandler.inputMouse) ? 1 : 0;
            cMove.z = upRect.Contains(mHandler.inputMouse) ? 1 : downRect.Contains(mHandler.inputMouse) ? -1 : 0;

            // ### WIP ### Dynamic panning sensitivity while zoomed
            // Disabled
            if (zoomedPanningSensitivity < mousePanningSensitivity)
            {
                //cPos *= zoomedPanningSensitivity;
                cMove *= mousePanningSensitivity;
            }
            else
            {
                cMove *= mousePanningSensitivity;
            }

            cMove *= Time.deltaTime;
            cMove = Quaternion.Euler(new Vector3(0f, mTransform.eulerAngles.y, 0f)) * cMove;
            cMove = mTransform.InverseTransformDirection(cMove);

            mTransform.Translate(cMove, Space.Self);

            cPos = mTransform.position;
            cPos.x = Mathf.Clamp(cPos.x, fixedCameraPanningXLimits.x, fixedCameraPanningXLimits.z);
            cPos.z = Mathf.Clamp(cPos.z, fixedCameraPanningZLimits.x, fixedCameraPanningZLimits.z);

            mTransform.position = cPos;
        }
    }
}
