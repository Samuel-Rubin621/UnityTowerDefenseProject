﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCommon : MonoBehaviour, IAddModule
{
    private Tower towerReference;
    private GameObject inventoryPanel;
    private float changeValue;
    private string textDetails;
    private Button moduleButton;

    public Tower TowerReference { get => towerReference; set => towerReference = value; }
    public GameObject InventoryPanel { get => inventoryPanel; set => inventoryPanel = value; }

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel = GameObject.Find("Overlay/InventoryPanel");

        changeValue = 2.0f;
        textDetails = "This module will increase the damage of the tower by " + changeValue.ToString() + " points.";
    }

    public void Select()
    {
        InventoryPanel.transform.Find("ModuleDetails").GetComponent<Text>().text = textDetails;
        InventoryPanel.GetComponent<InventoryPanel>().ModuleSelected(gameObject);
    }

    public IEnumerator AddModuleToTower(Tower tower)
    {
        tower.ProjectilePhysicalDamage += changeValue;
        yield return null;
    }

    public IEnumerator RemoveModuleFromTower(Tower tower)
    {
        tower.ProjectilePhysicalDamage -= changeValue;
        yield return null;
    }
}
