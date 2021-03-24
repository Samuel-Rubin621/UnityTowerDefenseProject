using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : DefaultEnemy
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private float enemyHealth = 1.0f;
    private float enemyDamage = 1.0f;
    private float enemySpeed = 50.0f;
    private int enemyValue = 1;
    private int enemyStrength = 1;
    private bool bAttacking;
    private EnemySpawner parentSpawner;

    // Public variables
    public GameObject module;

    // Reference variables
    private Overlay overlay;
    private Inventory inventory;

    // Prefab variables

    // Start is called before the first frame update
    void Start()
    {
        parentSpawner = this.transform.parent.gameObject.GetComponent<EnemySpawner>();
        bAttacking = false;

        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bAttacking)
        {
            transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(float incomingDamage)
    {
        enemyHealth -= incomingDamage;

        if (enemyHealth <= 0)
        {
            Death();
            overlay.IncreaseMoney(enemyValue);
        }
    }

    private void Death()
    {
        Vector3 position = this.transform.position;
        Instantiate(module, position, Quaternion.identity);

        /*
        Vector3 position = this.transform.position;
        // Probability of spawning a module when Soldier is destroyed
        float itemRarity = Random.Range(0.0f, 100.0f);
             if (itemRarity >= 50.0f && itemRarity < 70.0f) { inventory.SpawnModule(ModuleRarity.Common, position); }
        else if (itemRarity >= 70.0f && itemRarity < 85.0f) { inventory.SpawnModule(ModuleRarity.Uncommon, position); }
        else if (itemRarity >= 85.0f && itemRarity < 95.0f) { inventory.SpawnModule(ModuleRarity.Rare, position); }
        else if (itemRarity >= 95.0f && itemRarity < 99.0f) { inventory.SpawnModule(ModuleRarity.Exotic, position); }
        else if (itemRarity >= 99.0f)                       { inventory.SpawnModule(ModuleRarity.Legendary, position); }
        */
        parentSpawner.RemoveSpawnedEnemy(gameObject);
        Destroy(gameObject);
    }

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

    public int GetStrength()
    {
        return enemyStrength;
    }

    // Called specifically when the enemy is destroyed via the out-of-bounds gameobject
    public void RemoveFromSpawner(GameObject enemyToRemvoe)
    {
        parentSpawner.RemoveSpawnedEnemy(enemyToRemvoe);
    }




}
