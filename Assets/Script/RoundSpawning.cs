using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct EnemySpawnerStruct
{
    public GameObject spawner;
    public bool bAllEnemiesDead;

    public EnemySpawnerStruct(GameObject spawnerToAdd, bool bAreEnemiesDead)
    {
        this.spawner = spawnerToAdd;
        this.bAllEnemiesDead = bAreEnemiesDead;
    }
}

public class RoundSpawning : MonoBehaviour
{
    #region Variables
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private int round;
    private List<GameObject> towerList = new List<GameObject>();
    private List<EnemySpawnerStruct> enemySpawnersList = new List<EnemySpawnerStruct>();
    private Button startRoundButton;
    private Text startRoundButtonText;

    // Public variables
    public bool bInRound;
    public float roundBudget;

    // Reference variables
    private Overlay overlay;

    // Prefab variables

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Set References
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        startRoundButton = GameObject.Find("Overlay/OverlayHolder/ButtonHolder/StartRoundButton").GetComponent<Button>();
        startRoundButtonText = GameObject.Find("Overlay/OverlayHolder/ButtonHolder/StartRoundButton/StartRoundButtonText").GetComponent<Text>();
        startRoundButton.interactable = true;

        // Set up the spawners
        SetupSpawnerReference();

        // Set up starting values
        round = 1;
        roundBudget = 5.0f;
        startRoundButtonText.text = "Start Round " + round.ToString();
    }

    private void SetupSpawnerReference()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("EnemySpawner"))
        {
            enemySpawnersList.Add(new EnemySpawnerStruct(spawner, false));
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

        for (int i = 0; i < enemySpawnersList.Count; i++)
        {
            enemySpawnersList[i].spawner.GetComponent<EnemySpawnerScript>().RoundStart();
        }

        foreach (GameObject tower in towerList)
        {
            tower.GetComponent<TowerScript>().RoundStart();
        }

    }

    private void IncreaseRound()
    {
        round++;
        roundBudget = roundBudget * 1.2f;
        startRoundButton.interactable = true;
        enemySpawnersList.Clear();
        SetupSpawnerReference();
        startRoundButtonText.text = "Start Round " + round.ToString();
    }

    public void CheckRoundCompletion(GameObject spawnerToChange)
    {
        //Debug.Log("Checking Round completion " + spawnerToChange.ToString());
        EnemySpawnerStruct tempHolder = new EnemySpawnerStruct(spawnerToChange, true);
        int i = 0;
        foreach(var s in enemySpawnersList)
        {
            if (s.spawner == spawnerToChange)
            {
                break;
            }
            i++;
        }

        enemySpawnersList[i] = tempHolder;

        for (int j = 0; j < enemySpawnersList.Count; j++)
        {
            if (enemySpawnersList[j].bAllEnemiesDead == false) return;
        }
        bInRound = false;
        IncreaseRound();
    }



}
