using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour, IPointerClickHandler
{
    // Private variables only changeable through script
    private bool bTowerPlaced;
    private GameObject builtTower;

    // Reference variables
    private Overlay overlay;
    private RoundSpawning roundSpawning;
    private Energy energy;
    private TowerPanel towerPanel;

    // Prefab variables
    [SerializeField] private GameObject Tower;

    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();
        energy = GameObject.Find("GameManager").GetComponent<Energy>();
        towerPanel = GameObject.Find("TowerPanel").GetComponent<TowerPanel>();
        bTowerPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (overlay.bBuyingTower && !bTowerPlaced && overlay.CheckMoney(overlay.towerCost))
        {
            bTowerPlaced = true;
            builtTower = Instantiate(Tower, this.transform);
            roundSpawning.AddTowerToList(builtTower);
            overlay.DecreaseMoney(overlay.towerCost);
            overlay.IncreaseCost();
        }
        else if (towerPanel.bMovingTower && !bTowerPlaced && overlay.CheckMoney(overlay.movementCost))
        {
            Debug.Log("Moved tower");
            bTowerPlaced = true;

            towerPanel.tower.gameObject.transform.parent.GetComponent<TowerPlacement>().bTowerPlaced = false;

            towerPanel.tower.gameObject.transform.SetParent(this.gameObject.transform);
            towerPanel.tower.gameObject.transform.position = this.gameObject.transform.position;

            if (this.gameObject.transform.localScale.x < 0)
            {
                towerPanel.tower.gameObject.transform.localScale = new Vector3(-0.25f, 0.25f, 0f);
            }
            else
            {
                towerPanel.tower.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0f);
            }
            overlay.DecreaseMoney(overlay.movementCost);
        }
    }
}
