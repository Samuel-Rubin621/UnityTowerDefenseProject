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
    private GameObject dummyTower;
    private Button cancelButton;

    //Text variables
    private Text Lives;
    private Text Money;

    //Variable reference to objects
    public GameObject Tower;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        bBuyingTower = false;
        playerLives = 100;
        playerMoney = 500;

        Lives = GameObject.Find("Overlay/OverlayHolder/LivesText").GetComponent<Text>();
        Money = GameObject.Find("Overlay/OverlayHolder/MoneyText").GetComponent<Text>();
        UpdateText();

        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cancelButton = GameObject.Find("Overlay/OverlayHolder/CancelButton").GetComponent<Button>();
        cancelButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

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

    private void UpdateText()
    {
        Lives.text = "Lives: " + playerLives.ToString();
        Money.text = "Money: " + playerMoney.ToString();
    }


}
