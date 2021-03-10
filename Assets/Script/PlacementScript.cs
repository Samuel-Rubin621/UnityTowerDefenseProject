using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    //Variables local variables for the script
    private bool bHasTower;

    //Reference variables
    private CanvasScript canvasScript;
    public GameObject TowerInPosition;

    /*****************************************************************************/
    //Variables for creating the purchase menu
    [SerializeField] private GameObject purchaseMenuPrefab;
    private PurchaseMenuScript purchaseMenuScript;

    //Variables for creating the tower menu
    [SerializeField] private GameObject towerMenuPrefab;
    private TowerMenuScript towerMenuScript;
    /*****************************************************************************/

    // Start is called before the first frame update
    void Start()
    {
        canvasScript = GameObject.Find("MainCanvas").GetComponent<CanvasScript>();
        bHasTower = false;
    }

    public void CreateUI()
    {
        //If statement to determine which version of CreateMenu() to call in the canvas
        if (!bHasTower) { canvasScript.CreateMenu(purchaseMenuPrefab, purchaseMenuScript, this.name); }
        else { canvasScript.CreateMenu(towerMenuPrefab, towerMenuScript, this.name); }
    }

    public void BuildTower(GameObject TowerToBuild)
    {
        TowerInPosition = Instantiate(TowerToBuild, this.transform);
        bHasTower = true;
    }
}
