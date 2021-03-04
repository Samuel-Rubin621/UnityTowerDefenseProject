using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int Health;
    private int someForce;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        someForce = 50;
        //GameObject Child = transform.GetChild(0).gameObject;
        //Child.GetComponent<Rigidbody2D>().AddForce(someForce * transform.right * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * someForce * Time.deltaTime);
    }

    public void TakeDamage(int Damage)
    {
        Debug.Log("Enemy taking damage!");
        Health = Health - Damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
