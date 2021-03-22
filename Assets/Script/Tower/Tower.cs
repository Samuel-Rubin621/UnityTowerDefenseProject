using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Tower stats with get and set functions where necessary
    private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    private float projectilePhysicalDamage;
    public float ProjectilePhysicalDamage
    {
        get { return projectilePhysicalDamage; }
        set { projectilePhysicalDamage = value; }
    }

    private float projectileFireDamage;
    public float ProjectileFireDamage
    {
        get { return projectileFireDamage; }
        set { projectileFireDamage = value; }
    }

    private float fireRate;
    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    private float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    private float physicalDamageResistance;
    public float PhysicalDamageResistance
    {
        get { return physicalDamageResistance; }
        set { physicalDamageResistance = value; }
    }

    private float fireDamageResistance;
    public float FireDamageResistance
    {
        get { return fireDamageResistance; }
        set { fireDamageResistance = value; }
    }

    // Module variables
    private GameObject module1;
    public GameObject Module1
    {
        get { return module1; }
        set { module1 = value; }
    }

    private GameObject module2;
    public GameObject Module2
    {
        get { return module2; }
        set { module2 = value; }
    }

    private GameObject module3;
    public GameObject Module3
    {
        get { return module3; }
        set { module3 = value; }
    }

    private GameObject module4;
    public GameObject Module4
    {
        get { return module4; }
        set { module4 = value; }
    }

    private GameObject towerPanel;
    public GameObject TowerPanel
    {
        get { return towerPanel; }
        set { towerPanel = value; }
    }

    // Reference variables
    private GameObject projectileSpawn;
    private RoundSpawning roundSpawning;
    private Overlay overlay;
    

    // Prefab variables set in the editor
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject towerPanelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        roundSpawning = GameObject.Find("Overlay").GetComponent<RoundSpawning>();
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();

        health = 50.0f;
        projectilePhysicalDamage = 1.0f;
        projectileFireDamage = 0.0f;
        fireRate = 1.5f;
        projectileSpeed = 500.0f;

        projectileSpawn = transform.GetChild(0).gameObject;

        if (roundSpawning.bInRound)
        {
            InvokeRepeating("FireProjectile", 1.0f, fireRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!roundSpawning.bInRound)
        {
            CancelInvoke("FireProjectile");
        }
    }

    public void RoundStart()
    {
        InvokeRepeating("FireProjectile", 1.0f, fireRate);
    }

    void OnMouseDown()
    {
        if (!overlay.bBuyingTower && !towerPanel)
        {
            if (GameObject.Find("Overlay/TowerPanel(Clone)"))
            {
                GameObject.Find("Overlay/TowerPanel(Clone)").GetComponent<TowerPanel>().ClosePanel();
            }
            Invoke("CreateTowerPanel", 0.0001f);
        }
    }

    private void CreateTowerPanel()
    {
        towerPanel = Instantiate(towerPanelPrefab, overlay.transform);
        towerPanel.GetComponent<TowerPanel>().TowerReference = gameObject.GetComponent<Tower>();
    }

    void FireProjectile()
    {
        GameObject Projectile = Instantiate(projectilePrefab, projectileSpawn.transform);
        Projectile.GetComponent<Projectile>().projectileSpeed = projectileSpeed;
        Projectile.GetComponent<Projectile>().projectileDamage = projectilePhysicalDamage;
    }

    void TakeDamage(float value)
    {
        health -= value;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
