using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.IO;

public class InventorySlotController : MonoBehaviour, IPointerClickHandler {


    int itemX;
    int itemY;
    public int ownX;
    public int ownY;
    public MechLabController mechLabController;
    public Image UIImage;
    List<GameObject> linkedCells = new List<GameObject>();
    Color tempColour;

    public Dictionary<string, GameObject> allOtherLocations = new Dictionary<string, GameObject>();

    void Start() {
        foreach (GameObject a in GameObject.FindGameObjectsWithTag(this.tag))
        {
            allOtherLocations.Add(a.name, a);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            mechLabController.activeItemID = 11;
            mechLabController.currentIconColour = mechLabController.blank;
            mechLabController.currentSlotVerticalCount = 1;
            mechLabController.currentSlotHorizontalCount = 1;
            this.SetColourBlank(true);
            foreach (GameObject a in linkedCells)
            {
                a.GetComponent<InventorySlotController>().SetColourBlank(false);
                Debug.Log(a);
                linkedCells = new List<GameObject>();
            }
        }
    }

    public void SetColourBlank(bool isFirst)
    {
        UIImage.sprite = mechLabController.weaponIcons[11].cellIcon[0];
        if (!isFirst)
        {

            linkedCells = new List<GameObject>();
        }
    }

    public void Activated(int iconImage, bool isBlankCell, bool isFirstCell, List<GameObject> affectedCells)
    {
        int cellCount = 0;

        foreach (GameObject a in linkedCells)
        {
            a.GetComponent<InventorySlotController>().SetColourBlank(false);
        }

        linkedCells = new List<GameObject>();

        foreach (GameObject a in affectedCells)
        {
            linkedCells.Add(a);
        }

        if (isFirstCell == true)
        {
            itemX = mechLabController.currentSlotHorizontalCount;
            itemY = mechLabController.currentSlotVerticalCount;

            for (int a = ownX; a < ownX + itemX; a++)
            {
                for (int b = ownY; b > ownY - itemY; b--)
                {
                    affectedCells.Add(allOtherLocations[a + "," + b]);
                }
            }

            foreach (GameObject a in affectedCells)
            {
                a.GetComponent<InventorySlotController>().Activated(cellCount, false, false, affectedCells);
                cellCount = cellCount + 1;
            }

        }

        print(iconImage);
        print(this);
        UIImage.sprite = mechLabController.weaponIcons[mechLabController.activeItemID].cellIcon[iconImage];
    }

    public void CallActivated ()
    {
        Activated(0, false, true, new List<GameObject>());
    }
}
