using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
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
            GameObject Parent = collision.transform.parent.gameObject;
            EnemyScript parentScript = Parent.GetComponent<EnemyScript>();
            parentScript.TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
