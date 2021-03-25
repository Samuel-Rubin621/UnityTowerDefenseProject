using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceCommon : MonoBehaviour
{
    private Tower towerReference;
    private GameObject inventoryPanel;
    private float increasePhysicalResistancePercent;
    private float increasePhysicalResistancePoints;
    private string textDetails;
    private Button moduleButton;

    public Tower TowerReference { get => towerReference; set => towerReference = value; }
    public GameObject InventoryPanel { get => inventoryPanel; set => inventoryPanel = value; }

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel = GameObject.Find("Overlay/InventoryPanel");

        int chooseModifier = Random.Range(0, 2);
        switch (chooseModifier)
        {
            case 0:
                increasePhysicalResistancePoints = 5.0f;
                increasePhysicalResistancePercent = 0.0f;
                textDetails = "This module will increase the resistance to physical damage of the tower by " + increasePhysicalResistancePoints.ToString() + "%.";
                break;
            case 1:
                increasePhysicalResistancePercent = 2.0f;
                increasePhysicalResistancePoints = 0.0f;
                textDetails = "This module will increase the resistance to physical damage of the tower by " + increasePhysicalResistancePercent.ToString() + " points.";
                break;
        }
    }

    public void Select()
    {
        InventoryPanel.transform.Find("ModuleDetails").GetComponent<Text>().text = textDetails;
        InventoryPanel.GetComponent<InventoryPanel>().ModuleSelected(gameObject);
    }

    public void Use()
    {

    }
}
