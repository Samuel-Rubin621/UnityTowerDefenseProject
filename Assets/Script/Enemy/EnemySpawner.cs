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
    private int roundBudget;
    private int lowestEnemyStrength;
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

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1.5f;
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        roundSpawning = GameObject.Find("Overlay").GetComponent<RoundSpawning>();

        lowestEnemyStrength = Soldier.GetComponent<Soldier>().GetStrength();
        Invoke("PreloadRound", 0.1f);
    }

    void Update()
    {

    }
    
    private void PreloadRound()
    {
        roundBudget = roundSpawning.roundBudget;
        while (roundBudget >= lowestEnemyStrength)
        {
            float randomEnemy = Random.Range(0.0f, 100.0f);
            
            if ((randomEnemy >= 0.0) && (randomEnemy <= 100.0f) && (roundBudget >= Soldier.GetComponent<Soldier>().GetStrength()))
            {
                enemiesToSpawn.Add(Soldier);
                roundBudget -= Soldier.GetComponent<Soldier>().GetStrength();
            }
            else if ((randomEnemy > 50.0f) && (randomEnemy <= 75.0f) && (roundBudget >= Corporal.GetComponent<Corporal>().GetStrength()))
            {
                enemiesToSpawn.Add(Corporal);
                roundBudget -= Corporal.GetComponent<Corporal>().GetStrength();
            }
            else if ((randomEnemy > 75.0f) && (randomEnemy <= 95.0f) && (roundBudget >= Sergeant.GetComponent<Sergeant>().GetStrength()))
            {
                enemiesToSpawn.Add(Sergeant);
                roundBudget -= Sergeant.GetComponent<Sergeant>().GetStrength();
            }
            else if ((randomEnemy > 95.0f) && (randomEnemy <= 100.0f) && (roundBudget >= Lieutenant.GetComponent<Lieutenant>().GetStrength()))
            {
                enemiesToSpawn.Add(Lieutenant);
                roundBudget -= Lieutenant.GetComponent<Lieutenant>().GetStrength();
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

        if (bDoneSpawning && enemiesSpawned.Count <= 0)
        {
            roundSpawning.CheckRoundCompletion(gameObject);
        }
    }



}
