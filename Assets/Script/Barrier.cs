using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit barrier");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Projectile"))
        {
            Debug.Log("Projectile hit barrier");
            Destroy(collision);
        }
    }
}
