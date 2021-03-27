using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modules : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public List<GameObject> moduleList = new List<GameObject>();
    public GameObject defaultSlot;

    private Tower tower;
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
        tower = GetComponent<Tower>();
    }

    public void AddModule(GameObject module, int slot)
    {
        switch (slot)
        {
            case 1:
                if (slots[0] != defaultSlot)
                {
                    StartCoroutine(slots[0].GetComponent<IAddModule>().RemoveModuleFromTower(tower));
                }
                slots[0] = module;
                StartCoroutine(slots[0].GetComponent<IAddModule>().AddModuleToTower(tower));
                break;
            case 2:
                if (slots[1] != defaultSlot)
                {
                    StartCoroutine(slots[1].GetComponent<IAddModule>().RemoveModuleFromTower(tower));
                }
                slots[1] = module;
                StartCoroutine(slots[1].GetComponent<IAddModule>().AddModuleToTower(tower));
                break;
            case 3:
                if (slots[2] != defaultSlot)
                {
                    StartCoroutine(slots[2].GetComponent<IAddModule>().RemoveModuleFromTower(tower));
                }
                slots[2] = module;
                StartCoroutine(slots[2].GetComponent<IAddModule>().AddModuleToTower(tower));
                break;
            case 4:
                if (slots[3] != defaultSlot)
                {
                    StartCoroutine(slots[3].GetComponent<IAddModule>().RemoveModuleFromTower(tower));
                }
                slots[3] = module;
                StartCoroutine(slots[3].GetComponent<IAddModule>().AddModuleToTower(tower));
                break;
        }
        UpdateTowerPanel();
    }

    private void UpdateTowerPanel()
    {
        towerPanel.SetupText();
        towerPanel.SetupSlots();
    }

    public IEnumerator MovedTower(Modules movedTower)
    {
        yield return new WaitForSeconds(1);
        Debug.Log(slots.ToString() + movedTower.slots.ToString());
        slots = movedTower.slots;
    }



}
