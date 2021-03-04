using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    private GameObject Canvas;
    private CanvasScript canvasScript;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("MainCanvas");
        canvasScript = Canvas.GetComponent<CanvasScript>();
    }

    private bool CanPlaceTower()
    {
        if (Tower == null) return true;
        else return false;
    }

    public GameObject purchaseMenuPrefab;
    private PurchaseMenuScript purchaseMenuScript;

    public GameObject towerMenuPrefab;
    private TowerMenuScript towerMenuScript;

    public void CreateUI()
    {
        if (CanPlaceTower())
        {
            canvasScript.CreateMenu(purchaseMenuPrefab, purchaseMenuScript, this.name);
        }
        else
        {
            canvasScript.CreateMenu(towerMenuPrefab, towerMenuScript, this.name);
        }
    }

    private GameObject TowerPrefab;
    private GameObject Tower;

    public void BuildTower(GameObject TowerToBuild)
    {
        TowerPrefab = TowerToBuild;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Tower = (GameObject)Instantiate(TowerPrefab, this.transform);
    }
}
