using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lieutenant : DefaultEnemy
{
    #region Variables
    // Enemy stat variables
    private float enemyHealth = 1.0f;
    private float enemyDamage = 1.0f;
    private float enemySpeed = 50.0f;
    private int enemyValue = 1;
    private int enemyStrength = 1;

    // Boolean variables for checking
    private bool bAttacking;
    private EnemySpawner parentSpawner;

    // Border variables for spawning modules
    private float common;
    private float uncommon;
    private float rare;
    private float exotic;
    private float legendary;


    // Reference variables
    private Overlay overlay;
    private GenerateModule moduleGeneration;

    // Getter and Setter functions
    public float EnemyHealth { get => enemyHealth; set => enemyHealth = value; }
    public float EnemyDamage { get => enemyDamage; set => enemyDamage = value; }
    public float EnemySpeed { get => enemySpeed; set => enemySpeed = value; }
    public int EnemyValue { get => enemyValue; set => enemyValue = value; }
    public int EnemyStrength { get => enemyStrength; set => enemyStrength = value; }
    public bool BAttacking { get => bAttacking; set => bAttacking = value; }
    public EnemySpawner ParentSpawner { get => parentSpawner; set => parentSpawner = value; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        moduleGeneration = GameObject.Find("GameManager").GetComponent<GenerateModule>();
        ParentSpawner = this.transform.parent.gameObject.GetComponent<EnemySpawner>();
        BAttacking = false;

        common = 15.0f;
        uncommon = 25.0f;
        rare = 65.0f;
        exotic = 85.0f;
        legendary = 98.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BAttacking)
        {
            transform.Translate(Vector3.left * EnemySpeed * Time.deltaTime);
        }
    }
    #region Attack
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Debug.Log("Colliding with tower");
            AttackTower();
        }
    }

    public void AttackTower()
    {
        Debug.Log("Attacking tower");
    }
    #endregion

    #region Damage and Death
    public void TakeDamage(float incomingDamage)
    {
        EnemyHealth -= incomingDamage;

        if (EnemyHealth <= 0)
        {
            Death();
            overlay.IncreaseMoney(EnemyValue);
        }
    }

    private void Death()
    {
        Vector3 position = this.transform.position;
        // Probability of spawning a module when Soldier is destroyed
        float itemRarity = Random.Range(0.0f, 100.0f);
        if (itemRarity >= common && itemRarity < uncommon) { moduleGeneration.SpawnModule(ModuleRarity.COMMON, position); }
        else if (itemRarity >= uncommon && itemRarity < rare) { moduleGeneration.SpawnModule(ModuleRarity.UNCOMMON, position); }
        else if (itemRarity >= rare && itemRarity < exotic) { moduleGeneration.SpawnModule(ModuleRarity.RARE, position); }
        else if (itemRarity >= exotic && itemRarity < legendary) { moduleGeneration.SpawnModule(ModuleRarity.EXOTIC, position); }
        else if (itemRarity >= legendary) { moduleGeneration.SpawnModule(ModuleRarity.LEGENDARY, position); }

        ParentSpawner.RemoveSpawnedEnemy(gameObject);
        Destroy(gameObject);
    }

    // Called specifically when the enemy is destroyed via the out-of-bounds gameobject
    public void RemoveFromSpawner(GameObject enemyToRemvoe)
    {
        ParentSpawner.RemoveSpawnedEnemy(enemyToRemvoe);
    }
    #endregion
}
