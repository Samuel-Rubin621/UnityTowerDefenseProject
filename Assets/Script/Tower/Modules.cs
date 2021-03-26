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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddModule(GameObject module, int slot)
    {
        switch (slot)
        {
            case 1:
                for (int i = 0; i < moduleList.Count; i++)
                {
                    if (moduleList[i] == slots[0])
                    {
                        moduleList.RemoveAt(i);
                        break;
                    }
                }
                slots[0] = module;
                moduleList.Add(slots[0]);
                break;
            case 2:
                for (int i = 0; i < moduleList.Count; i++)
                {
                    if (moduleList[i] == slots[1])
                    {
                        moduleList.RemoveAt(i);
                        break;
                    }
                }
                slots[1] = module;
                moduleList.Add(slots[1]);
                break;
            case 3:
                for (int i = 0; i < moduleList.Count; i++)
                {
                    if (moduleList[i] == slots[2])
                    {
                        moduleList.RemoveAt(i);
                        break;
                    }
                }
                slots[2] = module;
                moduleList.Add(slots[2]);
                break;
            case 4:
                for (int i = 0; i < moduleList.Count; i++)
                {
                    if (moduleList[i] == slots[3])
                    {
                        moduleList.RemoveAt(i);
                        break;
                    }
                }
                slots[3] = module;
                moduleList.Add(slots[3]);
                break;
        }

        ApplyModule();
    }

    private void ApplyModule()
    {
        StartCoroutine(tower.ResetTower());

        foreach (GameObject module in moduleList)
        {
            StartCoroutine(module.GetComponent<IAddModule>().AddModuleToTower(tower));
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
