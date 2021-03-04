using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateBuyButton : MonoBehaviour
{
    private Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        buyButton = GameObject.Find("BuyButton").GetComponent<Button>();

        buyButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableBuyButton()
    {
        buyButton.interactable = true;
    }
}
