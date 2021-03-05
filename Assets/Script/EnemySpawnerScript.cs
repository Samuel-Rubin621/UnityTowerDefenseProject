using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject EnemyPrefab;

    void Spawn()
    {
        Instantiate(EnemyPrefab, this.transform);
    }



}
