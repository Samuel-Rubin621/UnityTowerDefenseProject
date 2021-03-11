using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    //Enemy variation prefabs
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private GameObject Enemy4;

    // Start is called before the first frame update
    void Start()
    {
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
