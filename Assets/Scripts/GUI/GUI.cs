using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUI : MonoBehaviour {

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool blockedByCanvasUI = EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();

        Collider colliderOver = RaycastFirstCollider(Camera.main);
        if (colliderOver == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            //if (blockedByCanvasUI)
                //Debug.Log("Click to " + colliderOver.name + " Blocked by Canvas UI!");
            //else
                //Debug.Log("Click to " + colliderOver.name + " Success!");
        }
    }

    Collider RaycastFirstCollider(Camera cam)
    {
        if (cam == null)
            return null;

        Ray curRay = cam.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(curRay, cam.farClipPlane);

        if (hits.Length < 1)
            return null;

        // Ensure that hits are in order of shortest to longest (not guaranteed by default!)
        System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
        return hits[0].collider;
    }
}
