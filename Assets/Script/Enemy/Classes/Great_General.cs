using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Great_General : DefaultEnemy
{
    #region Variables
    // Enemy stat variables
    private float enemyHealth = 1.0f;
    private float enemyDamage = 1.0f;
    private float enemySpeed = 50.0f;
    private int enemyValue = 1;
    private int enemyStrength = 1;

    // Border variables for spawning modules
    private float common = 0.0f;
    private float uncommon = 0.0f;
    private float rare = 10.0f;
    private float exotic = 70.0f;
    private float legendary = 85.0f;

    // Boolean variables for checking
    private bool bAlive;
    private bool bAttacking;
    private EnemySpawner parentSpawner;

    // Reference variables
    private Overlay overlay;
    private GenerateModule moduleGeneration;
    //private Animator animator;

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
        //animator = GetComponent<Animator>();
        ParentSpawner = this.transform.parent.gameObject.GetComponent<EnemySpawner>();
        bAlive = true;
        BAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BAttacking && bAlive)
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
            StartCoroutine(DeathCoroutine());
            overlay.IncreaseMoney(EnemyValue);
        }
    }

    IEnumerator DeathCoroutine()
    {
        bAlive = false;
        GetComponent<Collider2D>().enabled = false;
        //animator.SetTrigger("Die");
        yield return new WaitForSeconds(1);

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
    /*
    public AnimationClip FindAnimation(string name)
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }
    */
    // Called specifically when the enemy is destroyed via the out-of-bounds gameobject
    public void RemoveFromSpawner(GameObject enemyToRemvoe)
    {
        ParentSpawner.RemoveSpawnedEnemy(enemyToRemvoe);
    }
    #endregion
}
