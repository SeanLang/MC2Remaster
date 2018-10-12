using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour {

    [SerializeField]
    private LayerMask movementMask;

    private Camera cam;
    private RaycastHit hit;
    private PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            MoveToPoint();
        }
    }

    private void MoveToPoint()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, movementMask.value))
        {
            motor.MoveToPoint(hit.point);
            //Debug.LogFormat("Hit: {0}, Mask: {1}", hit.point, movementMask);
        }
    }
}
