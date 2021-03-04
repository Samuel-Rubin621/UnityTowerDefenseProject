using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerLevel
{
    public int cost;
    public GameObject visualization;
}

public class TowerScript : MonoBehaviour
{
    public List<TowerLevel> levels;
    private GameObject ProjectileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        ProjectileSpawn = transform.GetChild(1).gameObject;
        InvokeRepeating("Attack", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Tower selected");
    }

    public GameObject ProjectilePrefab;

    void Attack()
    {
        GameObject Projectile = Instantiate(ProjectilePrefab, ProjectileSpawn.transform);
    }
}
