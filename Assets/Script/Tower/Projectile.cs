using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script

    // Public variables
    public float projectileSpeed;
    public float projectileDamage;

    // Reference variables
    public GameObject tower;

    // Prefab variables

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<DefaultEnemy>() is Soldier) { collision.GetComponent<Soldier>().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is Corporal) { collision.GetComponent<Corporal>().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is Sergeant) { collision.GetComponent<Sergeant>().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is Lieutenant) { collision.GetComponent<Lieutenant>().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is Colonel) { collision.GetComponent<Colonel>().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is General) { collision.GetComponent<General>().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is Great_General) { collision.GetComponent<Great_General> ().TakeDamage(projectileDamage); }
            else if (collision.GetComponent<DefaultEnemy>() is Master_General) { collision.GetComponent<Master_General>().TakeDamage(projectileDamage); }

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
