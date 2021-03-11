using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Private variables that are changable in the editor
    [SerializeField] private int enemyStrength;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyDamage;
    [SerializeField] private int enemySpeed;

    // Private variables only changeable through script


    // Reference variables
    private ControlText TextHolder;

    // Start is called before the first frame update
    void Start()
    {
        TextHolder = GameObject.Find("Overlay/OverlayHolder/TextHolder").GetComponent<ControlText>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
    }

    public void TakeDamage(int incomingDamage)
    {
        enemyHealth = enemyHealth - incomingDamage;

        if (enemyHealth <= 0)
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
