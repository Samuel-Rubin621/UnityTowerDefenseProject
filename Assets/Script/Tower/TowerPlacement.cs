using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour, IPointerClickHandler
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private bool bTowerPlaced;
    private GameObject builtTower;

    // Public variables

    // Reference variables
    private Overlay overlay;
    private RoundSpawning roundSpawning;

    // Prefab variables
    [SerializeField] private GameObject Tower;

    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();
        bTowerPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (overlay.bBuyingTower && !bTowerPlaced && overlay.CheckMoney())
        {
            bTowerPlaced = true;
            builtTower = Instantiate(Tower, this.transform);
            roundSpawning.AddTowerToList(builtTower);
            overlay.DecreaseMoney(overlay.towerCost);
            overlay.IncreaseTowerCost();
        }
    }
}
