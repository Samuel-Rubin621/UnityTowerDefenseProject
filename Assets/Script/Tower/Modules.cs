using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modules : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject defaultSlot;

    private Tower tower;
    public Tower Tower { get => tower; set => tower = value; }
    private TowerPanel towerPanel;

    private GameObject module1;
    private GameObject module2;
    private GameObject module3;
    private GameObject module4;

    // Start is called before the first frame update
    void Start()
    {
        towerPanel = GameObject.Find("Overlay/TowerPanel").GetComponent<TowerPanel>();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = defaultSlot;
        }
        Tower = transform.parent.GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddModule(GameObject module, int slot)
    {
        switch (slot)
        {
            case 1:
                slots[0] = module;
                break;
            case 2:
                slots[1] = module;
                break;
            case 3:
                slots[2] = module;
                break;
            case 4:
                slots[3] = module;
                break;
        }
        towerPanel.SetupText();
        towerPanel.SetupSlots();
    }
}
