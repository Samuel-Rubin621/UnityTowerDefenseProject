using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, 5.0f);
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
