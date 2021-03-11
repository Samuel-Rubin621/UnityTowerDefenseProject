using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private int someForce;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        someForce = 500;
        //GameObject Child = transform.GetChild(0).gameObject;
        //this.GetComponent<Rigidbody2D>().AddForce(someForce * transform.right * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * someForce * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject Parent = collision.transform.parent.gameObject;
            EnemyScript parentScript = Parent.GetComponent<EnemyScript>();
            parentScript.TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Barrier"))
        {
            Debug.Log("Projectile off the screen");
            Destroy(gameObject);
        }
    }

}
