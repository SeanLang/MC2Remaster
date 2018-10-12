using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;
    private RaycastHit hit;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        bool blockedByCanvasUI = EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, cam.farClipPlane, movementMask.value);

            System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, movementMask.value))
            {
                if (blockedByCanvasUI)
                {
                    //Debug.Log("Click to " + hit.collider.name + " Blocked by Canvas UI!");
                }
                else
                {
                    motor.MoveToPoint(hit.point);
                }
            }
            else
            {

            }
        }
    }
}