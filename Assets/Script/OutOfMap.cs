using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<DefaultEnemy>() is Soldier) { collision.GetComponent<Soldier>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is Corporal) { collision.GetComponent<Corporal>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is Sergeant) { collision.GetComponent<Sergeant>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is Lieutenant) { collision.GetComponent<Lieutenant>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is Colonel) { collision.GetComponent<Colonel>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is General) { collision.GetComponent<General>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is Great_General) { collision.GetComponent<Great_General>().RemoveFromSpawner(collision.gameObject); }
            else if (collision.GetComponent<DefaultEnemy>() is Master_General) { collision.GetComponent<Master_General>().RemoveFromSpawner(collision.gameObject); }

            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Projectile")) Destroy(collision.gameObject);
    }
}
