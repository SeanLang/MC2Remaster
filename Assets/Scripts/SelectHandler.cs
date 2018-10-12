using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHandler : MonoBehaviour {

    [SerializeField]
    private LayerMask clickableLayer;

    private List<GameObject> selectedGameObjects;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;

        selectedGameObjects = new List<GameObject>();
    }

    void Update ()
    {
        bool blockedByCanvasUI = EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();

        Collider colliderOver = RaycastFirstCollider(Camera.main);
        if (colliderOver == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (blockedByCanvasUI)
            {
                //Debug.Log("Click to " + colliderOver.name + " Blocked by Canvas UI!");
            }
            else
            {
                SelectedHandler selHandle = colliderOver.GetComponent<SelectedHandler>();

                if (selHandle == null)
                    return;

                selHandle.isSelected = !selHandle.isSelected;
                selHandle.Selected();
                //Debug.Log(selHandle.isSelected);
            }
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
