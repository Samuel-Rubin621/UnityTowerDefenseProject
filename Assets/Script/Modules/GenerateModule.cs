using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleRarity { COMMON, UNCOMMON, RARE, EXOTIC, LEGENDARY };

public class GenerateModule : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonModules = new List<GameObject>();
    [SerializeField] private List<GameObject> uncommonModules = new List<GameObject>();
    [SerializeField] private List<GameObject> rareModules = new List<GameObject>();
    [SerializeField] private List<GameObject> exoticModules = new List<GameObject>();
    [SerializeField] private List<GameObject> legendaryModules = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnModule(ModuleRarity rarity, Vector3 position)
    {
        position = new Vector3(position.x + Random.Range(-15, 15), position.y + Random.Range(-15, 15), position.z);

        switch (rarity)
        {
            case ModuleRarity.COMMON:
                if (commonModules.Count > 0)
                {
                    GameObject addedItem = Instantiate(commonModules[Random.Range(0, commonModules.Count)], position, Quaternion.identity);
                }
                break;
            case ModuleRarity.UNCOMMON:
                if (uncommonModules.Count > 0)
                {
                    GameObject addedItem = Instantiate(uncommonModules[Random.Range(0, uncommonModules.Count)], position, Quaternion.identity);
                }
                break;
            case ModuleRarity.RARE:
                if (rareModules.Count > 0)
                {
                    GameObject addedItem = Instantiate(rareModules[Random.Range(0, rareModules.Count)], position, Quaternion.identity);
                }
                break;
            case ModuleRarity.EXOTIC:
                if (exoticModules.Count > 0)
                {
                    GameObject addedItem = Instantiate(exoticModules[Random.Range(0, exoticModules.Count)], position, Quaternion.identity);
                }
                break;
            case ModuleRarity.LEGENDARY:
                if (legendaryModules.Count > 0)
                {
                    GameObject addedItem = Instantiate(legendaryModules[Random.Range(0, legendaryModules.Count)], position, Quaternion.identity);
                }
                break;
        }
    }
}
