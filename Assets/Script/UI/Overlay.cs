using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    #region Variables
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private int playerMoney;
    private int playerLives;
    private GameObject followTower;

    // Public variables
    public int towerCost;
    public int movementCost;
    public bool bBuyingTower;

    // Reference variables
    private Camera camera;
    private TowerPanel towerPanel;

    // Prefab variables
    [SerializeField] private GameObject dummyTower;

    // Text variables
    private Text livesText;
    private Text moneyText;
    private Text towerCostText;

    // Button variables
    public Button cancelButton;
    public Button buyButton;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Initialize references to scene objects
        towerPanel = GameObject.Find("TowerPanel").GetComponent<TowerPanel>();
        livesText = GameObject.Find("Overlay/OverlayHolder/LivesText").GetComponent<Text>();
        moneyText = GameObject.Find("Overlay/OverlayHolder/MoneyText").GetComponent<Text>();
        towerCostText = GameObject.Find("Overlay/OverlayHolder/ButtonHolder/BuyButton/BuyButtonText").GetComponent<Text>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cancelButton = GameObject.Find("Overlay/OverlayHolder/ButtonHolder/CancelButton").GetComponent<Button>();
        buyButton = GameObject.Find("Overlay/OverlayHolder/ButtonHolder/BuyButton").GetComponent<Button>();

        // Initialize variables
        bBuyingTower = false;
        playerLives = 100;
        playerMoney = 500;
        towerCost = 100;
        movementCost = (int)(towerCost / 3);
        cancelButton.interactable = false;
        buyButton.interactable = true;

        UpdateText();
    }

    #region UI
    // Methods for the UI buttons on screen
    public void BuyButton()
    {
        if (!bBuyingTower)
        {
            bBuyingTower = true;

            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            followTower = Instantiate(dummyTower, mousePosition, Quaternion.identity);

            ToggleButtons();
        }
    }

    public void CancelButton()
    {
        if (bBuyingTower)
        {
            bBuyingTower = false;
            Destroy(followTower);

            ToggleButtons();
        }
    }

    public void ToggleButtons()
    {
        if (bBuyingTower || towerPanel.bMovingTower) { cancelButton.interactable = true; buyButton.interactable = false; }
        else { cancelButton.interactable = false; buyButton.interactable = true; }
    }

    private void UpdateText()
    {
        livesText.text = "Lives: " + playerLives.ToString();
        moneyText.text = "Money: " + playerMoney.ToString();
        towerCostText.text = "Buy Tower: " + towerCost.ToString();
    }
    #endregion

    #region Money and Lives
    // Methods for changing values for money and lives
    public void IncreaseMoney(int moneyToAdd)
    {
        playerMoney += moneyToAdd;
        UpdateText();
    }

    public void DecreaseMoney(int moneyToSubtract)
    {
        playerMoney -= moneyToSubtract;
        UpdateText();
    }

    public void IncreaseLives(int livesToAdd)
    {
        playerLives += livesToAdd;
        UpdateText();
    }

    public void DecreaseLives(int livesToSubtract)
    {
        playerLives -= livesToSubtract;
        UpdateText();
    }
    #endregion

    #region Tower Creation
    // Mothods used when creating new towers to validate placement
    public void IncreaseCost()
    {
        towerCost = (int)(towerCost * 1.33);
        movementCost = (int)(towerCost / 3);
        UpdateText();
    }

    public void DecreaseTowerCost()
    {
        towerCost = (int)(towerCost * 0.95);
        UpdateText();
    }

    public bool CheckMoney(int cost)
    {
        if (playerMoney >= cost) return true;
        else return false;
    }
    #endregion
}
