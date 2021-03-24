using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCommon : MonoBehaviour
{
    private Tower towerReference;

    public Tower TowerReference { get => towerReference; set => towerReference = value; }

    // Start is called before the first frame update
    void Start()
    {
        //TowerReference = transform.parent.GetComponent<InventoryPanel>().TowerReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
