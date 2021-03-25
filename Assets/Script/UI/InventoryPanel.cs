﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    #region Variables
    // Variables for moving the panel on/off screen
    private RectTransform position;
    private Vector2 onScreenPosition = new Vector2(0,0f);
    private Vector2 offScreenPosition = new Vector2(0,400f);

    // Module display info
    private Text moduleDetails;
    public GameObject selectedModule;
    private Button addModule;
    private int moduleSlot;

    // Reference variables
    private GameObject tower;

    // Get and Set functions
    public GameObject Tower { get => tower; set => tower = value; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Set up references
        addModule = transform.Find("AddButton").GetComponent<Button>();
        moduleDetails = transform.Find("ModuleDetails").GetComponent<Text>();
        position = GetComponent<RectTransform>();
        MoveOffScreen();
    }

    public void MoveOnScreen(int slot)
    {
        moduleSlot = slot;
        position.anchoredPosition = onScreenPosition;
    }

    public void MoveOffScreen()
    {
        position.anchoredPosition = offScreenPosition;
        moduleDetails.text = "";
        selectedModule = null;
        addModule.interactable = false;
    }

    public void ModuleSelected(GameObject module)
    {
        selectedModule = module;
        addModule.interactable = true;
    }

    public void AddModuleToTower()
    {
        Tower.GetComponent<Modules>().AddModule(selectedModule, moduleSlot);

        selectedModule.transform.parent.GetComponent<Slot>().DropItem();




        MoveOffScreen();
    }

}
