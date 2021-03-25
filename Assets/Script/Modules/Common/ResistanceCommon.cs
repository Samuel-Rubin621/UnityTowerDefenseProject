using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceCommon : MonoBehaviour, IAddModule
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
                increasePhysicalResistancePercent = 15.0f;
                increasePhysicalResistancePoints = 0.0f;
                textDetails = "This module will increase the resistance to physical damage of the tower by " + increasePhysicalResistancePercent.ToString() + "%.";
                break;
            case 1:
                increasePhysicalResistancePoints = 5.0f;
                increasePhysicalResistancePercent = 0.0f;
                textDetails = "This module will increase the resistance to physical damage of the tower by " + increasePhysicalResistancePoints.ToString() + " points.";
                break;
        }
    }

    public void Select()
    {
        InventoryPanel.transform.Find("ModuleDetails").GetComponent<Text>().text = textDetails;
        InventoryPanel.GetComponent<InventoryPanel>().ModuleSelected(gameObject);
    }

    public IEnumerator AddModuleToTower(Tower tower)
    {
        tower.PhysicalDamageResistance = tower.PhysicalDamageResistance + (tower.PhysicalDamageResistance * increasePhysicalResistancePercent * 0.01f) + increasePhysicalResistancePoints;
        yield return null;
    }
}
