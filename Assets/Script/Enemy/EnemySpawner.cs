using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private bool bDoneSpawning;
    private bool bIsActive;
    private float spawnRate;
    private int round;
    private int roundBudget;
    private int lowestEnemyStrength;

    // Lists of enemies
    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private List<GameObject> enemiesSpawned = new List<GameObject>();

    // Public variables

    // Reference variables

    // Prefab variables

    // Enemy variation prefabs
    [SerializeField] private GameObject Soldier;
    [SerializeField] private GameObject Corporal;
    [SerializeField] private GameObject Sergeant;
    [SerializeField] private GameObject Lieutenant;
    [SerializeField] private GameObject Colonel;
    [SerializeField] private GameObject General;
    [SerializeField] private GameObject Great_General;
    [SerializeField] private GameObject Master_General;

    // Reference variables
    private Overlay overlay;
    private RoundSpawning roundSpawning;

    public List<GameObject> EnemiesSpawned { get => enemiesSpawned; set => enemiesSpawned = value; }
    public List<GameObject> EnemiesToSpawn { get => enemiesToSpawn; set => enemiesToSpawn = value; }
    public int RoundBudget { get => roundBudget; set => roundBudget = value; }
    public int Round { get => round; set => round = value; }

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1.75f;
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();

        lowestEnemyStrength = Soldier.GetComponent<Soldier>().EnemyStrength;
        Invoke("PreloadRound", 0.1f);
    }

    void Update()
    {

    }
    
    public void PreloadRound()
    {
        if (EnemiesToSpawn.Count > 0)
        {
            EnemiesToSpawn.Clear();
        }

        RoundBudget = roundSpawning.RoundBudget;
        Round = roundSpawning.Round;/*
        while (RoundBudget >= lowestEnemyStrength)
        {
            float randomEnemy = Random.Range(0.0f, 100.0f);
            
            // Soldier
            if ((randomEnemy >= 0.0) && (randomEnemy <= 40.0f) && (RoundBudget >= Soldier.GetComponent<Soldier>().EnemyStrength))
            {
                EnemiesToSpawn.Add(Soldier);
                RoundBudget -= Soldier.GetComponent<Soldier>().EnemyStrength;
            }
            // Corporal
            else if ((randomEnemy > 40.0f) && (randomEnemy <= 70.0f) && (RoundBudget >= Corporal.GetComponent<Corporal>().EnemyStrength))
            {
                EnemiesToSpawn.Add(Corporal);
                RoundBudget -= Corporal.GetComponent<Corporal>().EnemyStrength;
            }
            // Sergeant
            else if ((randomEnemy > 7.0f) && (randomEnemy <= 80.0f) && (RoundBudget >= Sergeant.GetComponent<Sergeant>().EnemyStrength) && Round > 3)
            {
                EnemiesToSpawn.Add(Sergeant);
                RoundBudget -= Sergeant.GetComponent<Sergeant>().EnemyStrength;
            }
            // Lieutenant
            else if ((randomEnemy > 80.0f) && (randomEnemy <= 85.0f) && (RoundBudget >= Lieutenant.GetComponent<Lieutenant>().EnemyStrength) && Round > 3)
            {
                EnemiesToSpawn.Add(Lieutenant);
                RoundBudget -= Lieutenant.GetComponent<Lieutenant>().EnemyStrength;
            }
            // Colonel
            else if ((randomEnemy >= 85.0) && (randomEnemy <= 92.0f) && (RoundBudget >= Colonel.GetComponent<Colonel>().EnemyStrength) && Round > 3)
            {
                EnemiesToSpawn.Add(Colonel);
                RoundBudget -= Colonel.GetComponent<Colonel>().EnemyStrength;
            }
            // General
            else if ((randomEnemy > 92.0f) && (randomEnemy <= 96.0f) && (RoundBudget >= General.GetComponent<General>().EnemyStrength) && Round > 3)
            {
                EnemiesToSpawn.Add(General);
                RoundBudget -= General.GetComponent<General>().EnemyStrength;
            }
            // Great General
            else if ((randomEnemy > 96.0f) && (randomEnemy <= 99.0f) && (RoundBudget >= Great_General.GetComponent<Great_General>().EnemyStrength) && Round > 3)
            {
                EnemiesToSpawn.Add(Great_General);
                RoundBudget -= Great_General.GetComponent<Great_General>().EnemyStrength;
            }
            // Master General
            else if ((randomEnemy > 99.0f) && (randomEnemy <= 100.0f) && (RoundBudget >= Master_General.GetComponent<Master_General>().EnemyStrength) && Round > 3)
            {
                EnemiesToSpawn.Add(Master_General);
                RoundBudget -= Master_General.GetComponent<Master_General>().EnemyStrength;
            }
        }*/
        
        while (RoundBudget >= lowestEnemyStrength)
        {
            // Soldier
            if (Random.Range(0, 101) > 85 && (RoundBudget >= Soldier.GetComponent<Soldier>().EnemyStrength))
            {
                EnemiesToSpawn.Add(Soldier);
                RoundBudget -= Soldier.GetComponent<Soldier>().EnemyStrength;
            }
            else
            {
                // Corporal
                if (Random.Range(0, 101) > 85 && (RoundBudget >= Corporal.GetComponent<Corporal>().EnemyStrength))
                {
                    EnemiesToSpawn.Add(Corporal);
                    RoundBudget -= Corporal.GetComponent<Corporal>().EnemyStrength;
                }
                else
                {
                    // Sergeant
                    if (Random.Range(0, 101) > 85 && (RoundBudget >= Sergeant.GetComponent<Sergeant>().EnemyStrength))
                    {
                        EnemiesToSpawn.Add(Sergeant);
                        RoundBudget -= Sergeant.GetComponent<Sergeant>().EnemyStrength;
                    }
                    else
                    {
                        // Lieutenant
                        if (Random.Range(0, 101) > 85 && (RoundBudget >= Lieutenant.GetComponent<Lieutenant>().EnemyStrength))
                        {
                            EnemiesToSpawn.Add(Lieutenant);
                            RoundBudget -= Lieutenant.GetComponent<Lieutenant>().EnemyStrength;
                        }
                        else
                        {
                            // Colonel
                            if (Random.Range(0, 101) > 85 && (RoundBudget >= Colonel.GetComponent<Colonel>().EnemyStrength))
                            {
                                EnemiesToSpawn.Add(Colonel);
                                RoundBudget -= Colonel.GetComponent<Colonel>().EnemyStrength;
                            }
                            else
                            {
                                // General
                                if (Random.Range(0, 101) > 85 && (RoundBudget >= General.GetComponent<General>().EnemyStrength))
                                {
                                    EnemiesToSpawn.Add(General);
                                    RoundBudget -= General.GetComponent<General>().EnemyStrength;
                                }
                                else
                                {
                                    // Great General
                                    if (Random.Range(0, 101) > 85 && (RoundBudget >= Great_General.GetComponent<Great_General>().EnemyStrength))
                                    {
                                        EnemiesToSpawn.Add(Great_General);
                                        RoundBudget -= Great_General.GetComponent<Great_General>().EnemyStrength;
                                    }
                                    else
                                    {
                                        // Master General
                                        if (Random.Range(0, 101) > 85 && (RoundBudget >= Master_General.GetComponent<Master_General>().EnemyStrength))
                                        {
                                            EnemiesToSpawn.Add(Master_General);
                                            RoundBudget -= Master_General.GetComponent<Master_General>().EnemyStrength;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void RoundStart()
    {
        bDoneSpawning = false;
        Spawn();
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(EnemiesToSpawn[0], this.transform);
        EnemiesSpawned.Add(enemy);
        EnemiesToSpawn.RemoveAt(0);
        if (EnemiesToSpawn.Count > 0)
        {
            Invoke("Spawn", spawnRate);
        }
        else
        {
            bDoneSpawning = true;
            PreloadRound();
        }
    }

    public void RemoveSpawnedEnemy(GameObject enemyToRemove)
    {
        EnemiesSpawned.Remove(enemyToRemove);

        if (bDoneSpawning && EnemiesSpawned.Count <= 0)
        {
            roundSpawning.CheckRoundCompletion(gameObject);
        }
    }



}
