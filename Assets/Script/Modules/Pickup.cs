using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickup : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        inventory.IncreaseInventory(gameObject);
        Destroy(gameObject);
    }
}
