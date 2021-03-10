using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    private int speed = 50;
    public int damage;

    ControlText TextHolder;

    // Start is called before the first frame update
    void Start()
    {
        TextHolder = GameObject.Find("Overlay/OverlayHolder/TextHolder").GetComponent<ControlText>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log("Enemy taking damage!");
        health = health - damage;

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        float itemRarityNumber = Random.Range(0.0f, 100.0f);
        TextHolder.ChangeValues(itemRarityNumber);
        

        Destroy(gameObject);
    }

}
