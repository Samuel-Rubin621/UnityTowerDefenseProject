using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public int[] stock;

    public int CheckInventory(GameObject module)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == module)
            {
                return stock[i];
            }
        }
        return 0;
    }

    public void IncreaseInventory(GameObject module)
    {
        Debug.Log("Increasing stock of " + module.ToString());
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].name == module.name)
            {
                Debug.Log("Increasing stock");
                stock[i]++;
                slots[i].transform.Find("Stock").GetComponent<Text>().text = stock[i].ToString();
            }
        }
    }

    public void DecreaseInventory(GameObject module)
    {
        Debug.Log("Decreasing stock");
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].name == module.name)
            {
                stock[i]--;
                slots[i].transform.Find("Stock").GetComponent<Text>().text = stock[i].ToString();
            }
        }
    }
}
