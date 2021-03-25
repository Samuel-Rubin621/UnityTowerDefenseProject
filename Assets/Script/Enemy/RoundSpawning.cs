using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSpawning : MonoBehaviour
{
    #region Variables
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private int round;
    private List<GameObject> towerList = new List<GameObject>();
    private List<GameObject> spawnerList = new List<GameObject>();
    private List<GameObject> activeSpawners = new List<GameObject>();
    private Button startRoundButton;
    private Text startRoundButtonText;

    // Public variables
    public bool bInRound;
    private int roundBudget;

    // Reference variables
    private Overlay overlay;

    public List<GameObject> TowerList { get => towerList; set => towerList = value; }
    public List<GameObject> SpawnerList { get => spawnerList; set => spawnerList = value; }
    public List<GameObject> ActiveSpawners { get => activeSpawners; set => activeSpawners = value; }
    public int RoundBudget { get => roundBudget; set => roundBudget = value; }
    public int Round { get => round; set => round = value; }

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

        // Set up starting values
        Round = 1;
        RoundBudget = 10;
        bInRound = false;
        startRoundButtonText.text = "Start Round " + Round.ToString();

        // Create a list that stores references to all spawners in the scene
        GetAllSpawners();
    }

    private void Update()
    {
        
    }

    private void GetAllSpawners()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("EnemySpawner"))
        {
            SpawnerList.Add(spawner);
        }

        SetActiveSpawners(2);
    }

    private void SetActiveSpawners(int amountToActivate)
    {
        if (ActiveSpawners.Count > 0)
        {
            ActiveSpawners.Clear();
        }

        while (ActiveSpawners.Count < amountToActivate && SpawnerList.Count > amountToActivate)
        {
            GameObject spawnerToAdd = SpawnerList[Random.Range(0, SpawnerList.Count)];
            if (ActiveSpawners.Count > 0)
            {
                bool spawnerFound = false;
                for (int i = 0; i < ActiveSpawners.Count; i++)
                {
                    if (ActiveSpawners[i] == spawnerToAdd)
                    {
                        spawnerFound = true;
                        break;
                    }
                }
                if (!spawnerFound)
                {
                    activeSpawners.Add(spawnerToAdd);
                }
            }
            else
            {
                ActiveSpawners.Add(spawnerToAdd);
            }
        }
    }

    public void AddTowerToList(GameObject towerToAdd)
    {
        TowerList.Add(towerToAdd);
    }

    public void StartRound()
    {
        bInRound = true;
        startRoundButton.interactable = false;

        foreach (GameObject spawner in ActiveSpawners)
        {
            spawner.GetComponent<EnemySpawner>().RoundStart();
        }

        foreach (GameObject tower in TowerList)
        {
            tower.GetComponent<Tower>().RoundStart();
        }
    }

    private void RoundComplete()
    {
        bInRound = false;
        Round++;
        RoundBudget = (int)(RoundBudget * 1.1);

        foreach (GameObject spawner in SpawnerList)
        {
            spawner.GetComponent<EnemySpawner>().PreloadRound();
        }

        startRoundButton.interactable = true;
        if (Round < 5) SetActiveSpawners(2);
        else if (Round < 10) SetActiveSpawners(3);
        startRoundButtonText.text = "Start Round " + Round.ToString();
    }

    public void CheckRoundCompletion(GameObject completedSpawner)
    {
        foreach (GameObject spawner in ActiveSpawners)
        {
            if (spawner == completedSpawner)
            {
                ActiveSpawners.Remove(spawner);
                break;
            }
        }
        if (ActiveSpawners.Count == 0)
        {
            RoundComplete();
        }
    }



}
