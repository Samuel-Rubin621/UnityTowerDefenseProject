using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private float spawnRate;

    // Public variables

    // Reference variables

    // Prefab variables

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
    {
        spawnRate = 1.5f;
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        InvokeRepeating("Spawn", 5.0f, spawnRate);
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
