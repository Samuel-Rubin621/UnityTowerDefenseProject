using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script

    // Public variables
    private float projectileSpeed;
    private float projectilePhysicalDamage;
    private float projectileFireDamage;

    // Reference variables
    public Tower tower;

    // Prefab variables

    // Start is called before the first frame update
    void Start()
    {
        tower = this.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Tower>();
        projectileSpeed = tower.ProjectileSpeed;
        projectilePhysicalDamage = tower.ProjectilePhysicalDamage;
        projectileFireDamage = tower.ProjectileFireDamage;
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
            collision.GetComponent<Enemy>().TakeDamage(projectilePhysicalDamage, projectileFireDamage);

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
