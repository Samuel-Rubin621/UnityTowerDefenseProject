﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Private variables that are changable in the editor
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyDamage;
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyValue;
    [SerializeField] private int enemyStrength;

    // Private variables only changeable through script
    private bool bAttacking;

    // Public variables
    public EnemySpawnerScript parentSpawner;

    // Reference variables
    private ControlText TextHolder;
    private Overlay overlay;

    // Prefab variables

    // Start is called before the first frame update
    void Start()
    {
        parentSpawner = this.transform.parent.gameObject.GetComponent<EnemySpawnerScript>();
        bAttacking = false;

        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();

        // Debugging
        TextHolder = GameObject.Find("Overlay/OverlayHolder/TextHolder").GetComponent<ControlText>();
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
        parentSpawner.RemoveSpawnedEnemy(gameObject);

        float itemRarityNumber = Random.Range(0.0f, 100.0f);
        TextHolder.ChangeValues(itemRarityNumber);

        Destroy(gameObject);
    }

    public void AttackTower()
    {
        Debug.Log("Attacking tower");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Debug.Log("Colliding with tower");
            AttackTower();
        }
    }

    public int GetStrength()
    {
        return enemyStrength;
    }




}
