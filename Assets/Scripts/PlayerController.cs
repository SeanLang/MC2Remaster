using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, movementMask))
            {
                motor.MoveToPoint(hit.point);
                Debug.Log(hit.collider.name);
            }
            else
            {
                Debug.Log("We ain't hit shit!");
            }
        }
    }
}