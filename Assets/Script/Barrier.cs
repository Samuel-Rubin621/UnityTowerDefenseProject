using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.parentSpawner.RemoveSpawnedEnemy(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Projectile")) Destroy(collision.gameObject);
    }
}
