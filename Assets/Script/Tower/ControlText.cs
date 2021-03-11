using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlText : MonoBehaviour
{
    //Debugging variables
    private Text NoSpawn;
    private Text Common;
    private Text Uncommon;
    private Text Rare;
    private Text Exotic;
    private Text Legendary;
    private Text ERROR;

    private int NoSpawnCount;
    private int CommonCount;
    private int UncommonCount;
    private int RareCount;
    private int ExoticCount;
    private int LegendaryCount;
    private int ERRORCount;

    // Start is called before the first frame update
    void Start()
    {
        //Debugging functionality
        NoSpawn = GameObject.Find("Overlay/OverlayHolder/TextHolder/NoSpawn").GetComponent<Text>();
        Common = GameObject.Find("Overlay/OverlayHolder/TextHolder/Common").GetComponent<Text>();
        Uncommon = GameObject.Find("Overlay/OverlayHolder/TextHolder/Uncommon").GetComponent<Text>();
        Rare = GameObject.Find("Overlay/OverlayHolder/TextHolder/Rare").GetComponent<Text>();
        Exotic = GameObject.Find("Overlay/OverlayHolder/TextHolder/Exotic").GetComponent<Text>();
        Legendary = GameObject.Find("Overlay/OverlayHolder/TextHolder/Legendary").GetComponent<Text>();
        ERROR = GameObject.Find("Overlay/OverlayHolder/TextHolder/ERROR").GetComponent<Text>();

        NoSpawnCount = 0;
        CommonCount = 0;
        UncommonCount = 0;
        RareCount = 0;
        ExoticCount = 0;
        LegendaryCount = 0;
        ERRORCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValues(float randomNumber)
    {
        if (randomNumber < 50.0f)
        {
            NoSpawnCount = NoSpawnCount + 1;
            NoSpawn.text = "No Spawn: " + NoSpawnCount.ToString();
        }
        else if (randomNumber >= 50.0f && randomNumber < 70.0f)
        {
            CommonCount++;
            Common.text = "Common: " + CommonCount.ToString();
        }
        else if (randomNumber >= 70.0f && randomNumber < 85.0f)
        {
            UncommonCount++;
            Uncommon.text = "Uncommon: " + UncommonCount.ToString();
        }
        else if (randomNumber >= 85.0f && randomNumber < 95.0f)
        {
            RareCount++;
            Rare.text = "Rare: " + RareCount.ToString();
        }
        else if (randomNumber >= 95.0f && randomNumber < 99.0f)
        {
            ExoticCount++;
            Exotic.text = "Exotic: " + ExoticCount.ToString();
        }
        else if (randomNumber >= 99.0f)
        {
            LegendaryCount++;
            Legendary.text = "Legendary: " + LegendaryCount.ToString();
        }
        else
        {
            ERRORCount++;
            ERROR.text = "ERRORS: " + ERRORCount.ToString();
        }
    }




}
