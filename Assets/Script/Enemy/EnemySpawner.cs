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

        lowestEnemyStrength = soldier.GetComponent<DefaultEnemy>().EnemyStrength;
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

        //Debug.Log("Lowest enemy strength is " + lowestEnemyStrength.ToString());
        RoundBudget = roundSpawning.RoundBudget;
        Round = roundSpawning.Round;

        // Secondary spawning method - not in use
        /*
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
            else if ((randomEnemy > 70.0f) && (randomEnemy <= 80.0f) && (RoundBudget >= Sergeant.GetComponent<Sergeant>().EnemyStrength) && Round > 3)
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
            if (Random.Range(0, 101) > 85 && (RoundBudget >= soldier.GetComponent<DefaultEnemy>().EnemyStrength))
            {
                //Debug.Log("Soldier: Decreasing budget by " + soldier.EnemyStrength.ToString());
                EnemiesToSpawn.Add(soldier);
                RoundBudget -= soldier.GetComponent<DefaultEnemy>().EnemyStrength;
            }
            else
            {
                // Corporal
                if (Random.Range(0, 101) > 85 && (RoundBudget >= corporal.GetComponent<DefaultEnemy>().EnemyStrength))
                {
                    //Debug.Log("Corporal: Decreasing budget by " + corporal.EnemyStrength.ToString());
                    EnemiesToSpawn.Add(corporal);
                    RoundBudget -= corporal.GetComponent<DefaultEnemy>().EnemyStrength;
                }
                else
                {
                    // Sergeant
                    if (Random.Range(0, 101) > 85 && (RoundBudget >= sergeant.GetComponent<DefaultEnemy>().EnemyStrength))
                    {
                        //Debug.Log("Sergeant: Decreasing budget by " + sergeant.GetComponent<Sergeant>().EnemyStrength.ToString());
                        EnemiesToSpawn.Add(sergeant);
                        RoundBudget -= sergeant.GetComponent<DefaultEnemy>().EnemyStrength;
                    }
                    else
                    {
                        // Lieutenant
                        if (Random.Range(0, 101) > 85 && (RoundBudget >= lieutenant.GetComponent<DefaultEnemy>().EnemyStrength))
                        {
                            //Debug.Log("Lieutenant: Decreasing budget by " + lieutenant.GetComponent<Lieutenant>().EnemyStrength.ToString());
                            EnemiesToSpawn.Add(lieutenant);
                            RoundBudget -= lieutenant.GetComponent<DefaultEnemy>().EnemyStrength;
                        }
                        else
                        {
                            // Colonel
                            if (Random.Range(0, 101) > 85 && (RoundBudget >= colonel.GetComponent<DefaultEnemy>().EnemyStrength))
                            {
                                //Debug.Log("Colonel: Decreasing budget by " + colonel.GetComponent<Colonel>().EnemyStrength.ToString());
                                EnemiesToSpawn.Add(colonel);
                                RoundBudget -= colonel.GetComponent<DefaultEnemy>().EnemyStrength;
                            }
                            else
                            {
                                // General
                                if (Random.Range(0, 101) > 85 && (RoundBudget >= general.GetComponent<DefaultEnemy>().EnemyStrength))
                                {
                                    //Debug.Log("General: Decreasing budget by " + general.GetComponent<General>().EnemyStrength.ToString());
                                    EnemiesToSpawn.Add(general);
                                    RoundBudget -= general.GetComponent<DefaultEnemy>().EnemyStrength;
                                }
                                else
                                {
                                    // Great General
                                    if (Random.Range(0, 101) > 85 && (RoundBudget >= greatGeneral.GetComponent<DefaultEnemy>().EnemyStrength))
                                    {
                                        //Debug.Log("Great_General: Decreasing budget by " + greatGeneral.GetComponent<Great_General>().EnemyStrength.ToString());
                                        EnemiesToSpawn.Add(greatGeneral);
                                        RoundBudget -= greatGeneral.GetComponent<DefaultEnemy>().EnemyStrength;
                                    }
                                    else
                                    {
                                        // Master General
                                        if (Random.Range(0, 101) > 85 && (RoundBudget >= masterGeneral.GetComponent<DefaultEnemy>().EnemyStrength))
                                        {
                                            //Debug.Log("Master_General: Decreasing budget by " + masterGeneral.GetComponent<Master_General>().EnemyStrength.ToString());
                                            EnemiesToSpawn.Add(masterGeneral);
                                            RoundBudget -= masterGeneral.GetComponent<DefaultEnemy>().EnemyStrength;
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
