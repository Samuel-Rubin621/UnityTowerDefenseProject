using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSpawning : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private int round;
    private int roundDifficultyBudget;
    private List<GameObject> towerList = new List<GameObject>();
    private Button startRoundButton;

    // Public variables
    public bool bInRound;

    // Reference variables
    private Overlay overlay;

    // Prefab variables

    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        startRoundButton = GameObject.Find("Overlay/OverlayHolder/ButtonHolder/StartRoundButton").GetComponent<Button>();
        startRoundButton.interactable = true;

        round = 1;
        roundDifficultyBudget = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (bInRound)
        {

        }
    }

    public void AddTowerToList(GameObject towerToAdd)
    {
        towerList.Add(towerToAdd);
    }

    public void StartRound()
    {
        bInRound = true;
        startRoundButton.interactable = false;


        foreach (GameObject tower in towerList)
        {
            tower.GetComponent<TowerScript>().RoundStart();
        }

    }

    void IncreaseRound()
    {
        round++;
        roundDifficultyBudget = (int)(roundDifficultyBudget * 1.1);
    }

    public int GetDifficulty()
    {
        return roundDifficultyBudget;
    }





}
