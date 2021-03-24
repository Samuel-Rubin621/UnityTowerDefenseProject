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
    public List<GameObject> TowerList
    {
        get { return towerList; }
    }

    private List<EnemySpawnerStruct> enemySpawnersList = new List<EnemySpawnerStruct>();
    private Button startRoundButton;
    private Text startRoundButtonText;

    // Public variables
    public bool bInRound;
    public int roundBudget;

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
        SetupActiveSpawners();

        // Set up starting values
        round = 1;
        roundBudget = 10;
        startRoundButtonText.text = "Start Round " + round.ToString();
    }

    private void SetupActiveSpawners()
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
            enemySpawnersList[i].spawner.GetComponent<EnemySpawner>().RoundStart();
        }

        foreach (GameObject tower in towerList)
        {
            tower.GetComponent<Tower>().RoundStart();
        }
        roundBudget = (int)(roundBudget * 1.1);

    }

    private void IncreaseRound()
    {
        round++;
        startRoundButton.interactable = true;
        enemySpawnersList.Clear();
        SetupActiveSpawners();
        startRoundButtonText.text = "Start Round " + round.ToString();
    }

    public void CheckRoundCompletion(GameObject spawnerToChange)
    {
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
