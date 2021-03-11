using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    //Class variables
    public bool bBuyingTower;
    private int playerMoney;
    private int playerLives;
    public int towerCost;
    private GameObject dummyTower;
    private Button cancelButton;

    //Text variables
    private Text Lives;
    private Text Money;
    private Text TowerCost;

    //Variable reference to objects
    public GameObject Tower;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        bBuyingTower = false;
        playerLives = 100;
        playerMoney = 500;
        towerCost = 150;

        Lives = GameObject.Find("Overlay/OverlayHolder/LivesText").GetComponent<Text>();
        Money = GameObject.Find("Overlay/OverlayHolder/MoneyText").GetComponent<Text>();
        TowerCost = GameObject.Find("Overlay/OverlayHolder/BuyButton/BuyButtonText").GetComponent<Text>();
        UpdateText();

        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cancelButton = GameObject.Find("Overlay/OverlayHolder/CancelButton").GetComponent<Button>();
        cancelButton.interactable = false;
    }

    #region UI
    // Methods for the UI buttons on screen
    public void BuyButton()
    {
        if (!bBuyingTower)
        {
            bBuyingTower = true;

            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            dummyTower = Instantiate(Tower, mousePosition, Quaternion.identity);

            ToggleCancelButton();
        }
    }

    public void CancelButton()
    {
        if (bBuyingTower)
        {
            bBuyingTower = false;
            Debug.Log("Canceling");
            Destroy(dummyTower);

            ToggleCancelButton();
        }
    }

    private void ToggleCancelButton()
    {
        if (bBuyingTower) { cancelButton.interactable = true; }
        else { cancelButton.interactable = false; }
    }

    private void UpdateText()
    {
        Lives.text = "Lives: " + playerLives.ToString();
        Money.text = "Money: " + playerMoney.ToString();
        TowerCost.text = "Buy Tower: " + towerCost.ToString();
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
    public void IncreaseTowerCost()
    {
        towerCost = (int)Mathf.Pow(towerCost, 1.025f);
        UpdateText();
    }

    public bool CheckMoney()
    {
        if (playerMoney >= towerCost) return true;
        else return false;
    }
    #endregion
}
