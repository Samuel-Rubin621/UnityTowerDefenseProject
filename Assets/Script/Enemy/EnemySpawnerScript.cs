using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Enemy variation prefabs
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private GameObject Enemy4;

    // Variables from the prefabs
    private int enemyStrength1;
    private int enemyStrength2;
    private int enemyStrength3;
    private int enemyStrength4;

    // Reference variables
    private Overlay overlay;

    // Start is called before the first frame update
    void Start()
    {/*
        enemyStrength1 = Enemy1.GetComponent<EnemyScript>().enemyStrength;
        enemyStrength2 = Enemy2.GetComponent<EnemyScript>().enemyStrength;
        enemyStrength3 = Enemy3.GetComponent<EnemyScript>().enemyStrength;
        enemyStrength4 = Enemy4.GetComponent<EnemyScript>().enemyStrength;
        */
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        InvokeRepeating("Spawn", 5.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float randomEnemy = Random.Range(0.0f, 100.0f);

        if (randomEnemy <= 50.0f)
        {
            Instantiate(Enemy1, this.transform);
        }
        else if (randomEnemy > 50.0f && randomEnemy <= 75.0f)
        {
            Instantiate(Enemy2, this.transform);
        }
        else if (randomEnemy > 75.0f && randomEnemy <= 95.0f)
        {
            Instantiate(Enemy3, this.transform);
        }
        else if (randomEnemy > 95.0f)
        {
            Instantiate(Enemy4, this.transform);
        }
    }
}
