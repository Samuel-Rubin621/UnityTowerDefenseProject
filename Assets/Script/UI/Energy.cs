using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private float currentEnergy;
    private float maxEnergy;

    private Image energyRadialImage;
    private RoundSpawning roundSpawning;


    // Start is called before the first frame update
    void Start()
    {
        energyRadialImage = GameObject.Find("Overlay/OverlayHolder/EnergyCircleSprite").GetComponent<Image>();
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();

        currentEnergy = 0.0f;
        maxEnergy = 100.0f;
        energyRadialImage.fillAmount = currentEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnergy < maxEnergy && roundSpawning.bInRound)
        {
            currentEnergy += 0.01f;
            energyRadialImage.fillAmount = currentEnergy/ maxEnergy;
        }
    }

    public bool CheckEnergy()
    {
        return false;
    }

    public void DecreaseEnergy()
    {

    }



}
