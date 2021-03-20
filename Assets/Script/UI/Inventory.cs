using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleRarity
{
    Common,
    Uncommon,
    Rare,
    Exotic,
    Legendary
}

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonModules = new List<GameObject>();
    [SerializeField] private List<GameObject> uncommonModules = new List<GameObject>();
    [SerializeField] private List<GameObject> rareModules = new List<GameObject>();
    [SerializeField] private List<GameObject> exoticModules = new List<GameObject>();
    [SerializeField] private List<GameObject> legendaryModules = new List<GameObject>();

    [SerializeField] private List<GameObject> inventoryModules = new List<GameObject>();
    [SerializeField] private List<int> inventoryCount = new List<int>();

    public void SpawnModule(ModuleRarity moduleRarity, Vector3 position)
    {
        switch (moduleRarity)
        {
            case ModuleRarity.Common:
                if (commonModules.Count > 0)
                {
                    Debug.Log("Spawning Common item");
                    GameObject addedItem = Instantiate(commonModules[Random.Range(0, commonModules.Count)], position, Quaternion.identity);
                    Debug.Log(addedItem.ToString());
                    AddToInventory(addedItem);
                }
                break;
            case ModuleRarity.Uncommon:
                if (uncommonModules.Count > 0)
                {
                    Debug.Log("Spawning Uncommon item");
                    GameObject addedItem = Instantiate(uncommonModules[Random.Range(0, uncommonModules.Count)], position, Quaternion.identity);
                    AddToInventory(addedItem);
                }
                break;
            case ModuleRarity.Rare:
                if (rareModules.Count > 0)
                {
                    Debug.Log("Spawning Rare item");
                    GameObject addedItem = Instantiate(rareModules[Random.Range(0, rareModules.Count)], position, Quaternion.identity);
                    AddToInventory(addedItem);
                }
                break;
            case ModuleRarity.Exotic:
                if (exoticModules.Count > 0)
                {
                    Debug.Log("Spawning Exotic item");
                    GameObject addedItem = Instantiate(exoticModules[Random.Range(0, exoticModules.Count)], position, Quaternion.identity);
                    AddToInventory(addedItem);
                }
                break;
            case ModuleRarity.Legendary:
                if (legendaryModules.Count > 0)
                {
                    Debug.Log("Spawning Legendary item");
                    GameObject addedItem = Instantiate(legendaryModules[Random.Range(0, legendaryModules.Count)], position, Quaternion.identity);
                    AddToInventory(addedItem);
                }
                break;
        }
    }

    private void AddToInventory(GameObject module)
    {
        for (int i = 0; i < inventoryModules.Count; i++)
        {
            if (inventoryModules[i].ToString() == module.ToString())
            {
                inventoryCount[i]++;
                return;
            }
        }
        inventoryModules.Add(module);
        inventoryCount.Add(1);
    }








}
