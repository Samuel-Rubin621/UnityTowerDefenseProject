using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private GameObject projectileSpawn;
    private float health;
    private float projectileDamage;
    private float fireRate;
    private float projectileSpeed;
    private float normalResistance;
    private float fireResistance;

    // Public variables

    // Reference variables
    private RoundSpawning roundSpawning;

    // Prefab variables
    [SerializeField] GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        roundSpawning = GameObject.Find("Overlay").GetComponent<RoundSpawning>();

        health = 50.0f;
        projectileDamage = 1.0f;
        fireRate = 1.5f;
        projectileSpeed = 500.0f;

        projectileSpawn = transform.GetChild(1).gameObject;

        if (roundSpawning.bInRound)
        {
            InvokeRepeating("FireProjectile", 1.0f, fireRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!roundSpawning.bInRound)
        {
            CancelInvoke("FireProjectile");
        }
    }

    public void RoundStart()
    {
        InvokeRepeating("FireProjectile", 1.0f, fireRate);
    }

    void OnMouseDown()
    {
        Debug.Log("Tower selected");
    }

    void FireProjectile()
    {
        GameObject Projectile = Instantiate(projectile, projectileSpawn.transform);
        Projectile.GetComponent<Projectile>().projectileSpeed = projectileSpeed;
        Projectile.GetComponent<Projectile>().projectileDamage = projectileDamage;
    }

    void TakeDamage(float value)
    {
        health -= value;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
