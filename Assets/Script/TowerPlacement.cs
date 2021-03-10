using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Overlay overlay;
    private bool bTowerPlaced;
    private GameObject builtTower;

    [SerializeField] private GameObject Tower;

    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        bTowerPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (overlay.bBuyingTower && !bTowerPlaced)
        {
            bTowerPlaced = true;
            builtTower = Instantiate(Tower, this.transform);
        }
    }

    void OnMouseOver()
    {

    }



}
