using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerLevel
{
    public int cost;
    public GameObject visualization;
}

public class TowerScript : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private GameObject projectileSpawn;
    private float health;
    private float projectileDamage;
    private float fireRate;
    private float projectileSpeed;
    private float defense;

    // Public variables

    // Reference variables

    // Prefab variables
    [SerializeField] GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        health = 50.0f;
        projectileDamage = 1.0f;
        fireRate = 1.5f;
        projectileSpeed = 500.0f;
        defense = 0.0f;

        projectileSpawn = transform.GetChild(1).gameObject;
        InvokeRepeating("FireProjectile", 1.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Tower selected");
    }

    void FireProjectile()
    {
        GameObject Projectile = Instantiate(projectile, projectileSpawn.transform);
        Projectile.GetComponent<ProjectileScript>().projectileSpeed = projectileSpeed;
        Projectile.GetComponent<ProjectileScript>().projectileDamage = projectileDamage;
    }

    void TakeDamage(float value)
    {
        health -= value;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyScript collidingEnemy = collision.GetComponent<EnemyScript>();
            collidingEnemy.AttackTower();
        }
    }
}
