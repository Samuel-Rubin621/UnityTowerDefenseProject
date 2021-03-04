using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseMenuScript : MonoBehaviour
{
    private GameObject MenuHolder;
    private CanvasScript _canvasScript;

    public string refName;

    private GameObject TowerToBuild;

    // Start is called before the first frame update
    void Start()
    {
        MenuHolder = GameObject.Find("MainCanvas");
        _canvasScript = MenuHolder.GetComponent<CanvasScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CancelButton()
    {
        _canvasScript.UIExists = false;
        Destroy(gameObject);
    }
    
    public void BuyButton()
    {
        GameObject refPlacement = GameObject.Find(refName);
        PlacementScript refScript = refPlacement.GetComponent<PlacementScript>();
        refScript.BuildTower(TowerToBuild);

        _canvasScript.UIExists = false;
        Destroy(gameObject);
    }

    public GameObject MainTowerPrefab;
    public GameObject SecondaryTowerPrefab;

    public void ToggleTower1()
    {
        BuyButtonActivation();
        TowerToBuild = MainTowerPrefab;
    }

    public void ToggleTower2()
    {
        BuyButtonActivation();
        TowerToBuild = SecondaryTowerPrefab;
    }

    private void BuyButtonActivation()
    {
        ActivateBuyButton childScript = GameObject.Find("Button Holder").GetComponent<ActivateBuyButton>();
        childScript.EnableBuyButton();
    }
}
