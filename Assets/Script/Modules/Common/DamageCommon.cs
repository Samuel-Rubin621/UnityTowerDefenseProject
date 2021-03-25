using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCommon : MonoBehaviour
{
    private Tower towerReference;
    private GameObject inventoryPanel;
    private float increaseDamageValue;
    private float increaseDamagePercent;
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
                increaseDamagePercent = 5.0f;
                increaseDamageValue = 0.0f;
                textDetails = "This module will increase the damage of the tower by " + increaseDamagePercent.ToString() + "%.";
                break;
            case 1:
                increaseDamageValue = 2.0f;
                increaseDamagePercent = 0.0f;
                textDetails = "This module will increase the damage of the tower by " + increaseDamageValue.ToString() + " points.";
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
