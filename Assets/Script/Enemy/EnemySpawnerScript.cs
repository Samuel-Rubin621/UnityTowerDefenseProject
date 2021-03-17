using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private float spawnRate;
    private float roundBudget;
    private int lowestEnemyStrength;
    private List<int> enemyStrengths = new List<int>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    // Public variables
    public bool bDoneSpawning;
    public List<GameObject> enemiesSpawned = new List<GameObject>();

    // Reference variables

    // Prefab variables

    // Enemy variation prefabs
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private GameObject Enemy4;

    // Reference variables
    private Overlay overlay;
    private RoundSpawning roundSpawning;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1.5f;
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        roundSpawning = GameObject.Find("Overlay").GetComponent<RoundSpawning>();

        lowestEnemyStrength = 1000;

        enemyStrengths.Add(Enemy1.GetComponent<EnemyScript>().GetStrength());
        enemyStrengths.Add(Enemy2.GetComponent<EnemyScript>().GetStrength());
        enemyStrengths.Add(Enemy3.GetComponent<EnemyScript>().GetStrength());
        enemyStrengths.Add(Enemy4.GetComponent<EnemyScript>().GetStrength());

        foreach (int strength in enemyStrengths)
        {
            if (strength < lowestEnemyStrength)
            {
                lowestEnemyStrength = strength;
            }

        }
        Invoke("PreloadRound", 0.1f);
    }

    void Update()
    {

    }

    private void PreloadRound()
    {
        roundBudget = roundSpawning.roundBudget;
        while (roundBudget > lowestEnemyStrength)
        {
            float randomEnemy = Random.Range(0.0f, 100.0f);

            if ((randomEnemy >= 0.0) && (randomEnemy <= 50.0f) && (roundBudget > enemyStrengths[0]))
            {
                enemiesToSpawn.Add(Enemy1);
                roundBudget -= enemyStrengths[0];
            }
            else if ((randomEnemy > 50.0f) && (randomEnemy <= 75.0f) && (roundBudget > enemyStrengths[1]))
            {
                enemiesToSpawn.Add(Enemy2);
                roundBudget -= enemyStrengths[1];
            }
            else if ((randomEnemy > 75.0f) && (randomEnemy <= 95.0f) && (roundBudget > enemyStrengths[2]))
            {
                enemiesToSpawn.Add(Enemy3);
                roundBudget -= enemyStrengths[2];
            }
            else if ((randomEnemy > 95.0f) && (randomEnemy <= 100.0f) && (roundBudget > enemyStrengths[3]))
            {
                enemiesToSpawn.Add(Enemy4);
                roundBudget -= enemyStrengths[3];
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
        GameObject enemy = Instantiate(enemiesToSpawn[0], this.transform);
        enemiesSpawned.Add(enemy);
        enemiesToSpawn.RemoveAt(0);
        if (enemiesToSpawn.Count > 0)
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
        enemiesSpawned.Remove(enemyToRemove);
        Debug.Log("Removed enemy\nbDoneSpawning: " +bDoneSpawning.ToString() + 
            "\nEnemiesSpawned: " + enemiesSpawned.Count.ToString() + 
            "\nEnemiesToSpawn: " + enemiesToSpawn.Count.ToString());

        if (bDoneSpawning && enemiesSpawned.Count <= 0)
        {
            roundSpawning.CheckRoundCompletion(gameObject);
        }
    }


}
