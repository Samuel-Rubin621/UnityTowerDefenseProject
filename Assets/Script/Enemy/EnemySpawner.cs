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
    [SerializeField] private GameObject soldier;
    [SerializeField] private GameObject corporal;
    [SerializeField] private GameObject sergeant;
    [SerializeField] private GameObject lieutenant;
    [SerializeField] private GameObject colonel;
    [SerializeField] private GameObject general;
    [SerializeField] private GameObject greatGeneral;
    [SerializeField] private GameObject masterGeneral;

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

        lowestEnemyStrength = soldier.GetComponent<Enemy>().EnemyStrength;
        Invoke("PreloadRound", 0.1f);
    }
    
    public void PreloadRound()
    {
        if (EnemiesToSpawn.Count > 0)
        {
            EnemiesToSpawn.Clear();
        }

        //Debug.Log("Lowest enemy strength is " + lowestEnemyStrength.ToString());
        RoundBudget = roundSpawning.RoundBudget;
        Round = roundSpawning.Round;
        
        while (RoundBudget >= lowestEnemyStrength)
        {
            // Soldier
            if (Random.Range(0, 101) > 85 && (RoundBudget >= soldier.GetComponent<Enemy>().EnemyStrength))
            {
                //Debug.Log("Soldier: Decreasing budget by " + soldier.EnemyStrength.ToString());
                EnemiesToSpawn.Add(soldier);
                RoundBudget -= soldier.GetComponent<Enemy>().EnemyStrength;
            }
            else
            {
                // Corporal
                if (Random.Range(0, 101) > 85 && (RoundBudget >= corporal.GetComponent<Enemy>().EnemyStrength))
                {
                    //Debug.Log("Corporal: Decreasing budget by " + corporal.EnemyStrength.ToString());
                    EnemiesToSpawn.Add(corporal);
                    RoundBudget -= corporal.GetComponent<Enemy>().EnemyStrength;
                }
                else
                {
                    // Sergeant
                    if (Random.Range(0, 101) > 85 && (RoundBudget >= sergeant.GetComponent<Enemy>().EnemyStrength))
                    {
                        //Debug.Log("Sergeant: Decreasing budget by " + sergeant.GetComponent<Sergeant>().EnemyStrength.ToString());
                        EnemiesToSpawn.Add(sergeant);
                        RoundBudget -= sergeant.GetComponent<Enemy>().EnemyStrength;
                    }
                    else
                    {
                        // Lieutenant
                        if (Random.Range(0, 101) > 85 && (RoundBudget >= lieutenant.GetComponent<Enemy>().EnemyStrength))
                        {
                            //Debug.Log("Lieutenant: Decreasing budget by " + lieutenant.GetComponent<Lieutenant>().EnemyStrength.ToString());
                            EnemiesToSpawn.Add(lieutenant);
                            RoundBudget -= lieutenant.GetComponent<Enemy>().EnemyStrength;
                        }
                        else
                        {
                            // Colonel
                            if (Random.Range(0, 101) > 85 && (RoundBudget >= colonel.GetComponent<Enemy>().EnemyStrength))
                            {
                                //Debug.Log("Colonel: Decreasing budget by " + colonel.GetComponent<Colonel>().EnemyStrength.ToString());
                                EnemiesToSpawn.Add(colonel);
                                RoundBudget -= colonel.GetComponent<Enemy>().EnemyStrength;
                            }
                            else
                            {
                                // General
                                if (Random.Range(0, 101) > 85 && (RoundBudget >= general.GetComponent<Enemy>().EnemyStrength))
                                {
                                    //Debug.Log("General: Decreasing budget by " + general.GetComponent<General>().EnemyStrength.ToString());
                                    EnemiesToSpawn.Add(general);
                                    RoundBudget -= general.GetComponent<Enemy>().EnemyStrength;
                                }
                                else
                                {
                                    // Great General
                                    if (Random.Range(0, 101) > 85 && (RoundBudget >= greatGeneral.GetComponent<Enemy>().EnemyStrength))
                                    {
                                        //Debug.Log("Great_General: Decreasing budget by " + greatGeneral.GetComponent<Great_General>().EnemyStrength.ToString());
                                        EnemiesToSpawn.Add(greatGeneral);
                                        RoundBudget -= greatGeneral.GetComponent<Enemy>().EnemyStrength;
                                    }
                                    else
                                    {
                                        // Master General
                                        if (Random.Range(0, 101) > 85 && (RoundBudget >= masterGeneral.GetComponent<Enemy>().EnemyStrength))
                                        {
                                            //Debug.Log("Master_General: Decreasing budget by " + masterGeneral.GetComponent<Master_General>().EnemyStrength.ToString());
                                            EnemiesToSpawn.Add(masterGeneral);
                                            RoundBudget -= masterGeneral.GetComponent<Enemy>().EnemyStrength;
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
        Invoke("Spawn", 5.0f);
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
