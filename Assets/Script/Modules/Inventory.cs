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
    public bool[] isFull;
    public GameObject[] slots;

}
