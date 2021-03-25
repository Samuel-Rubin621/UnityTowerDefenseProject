using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    // Tower stats with get and set functions where necessary
    private float health;
    private float projectilePhysicalDamage;
    private float projectileFireDamage;
    private float fireRate;
    private float projectileSpeed;
    private float physicalDamageResistance;
    private float fireDamageResistance;

    // Module variables
    private TowerPanel towerPanel;
    public TowerPanel TowerPanel { get => towerPanel; set => towerPanel = value; }

    // Reference variables
    private GameObject projectileSpawn;
    private RoundSpawning roundSpawning;
    private Overlay overlay;

    // Prefab variables set in the editor
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject towerPanelPrefab;

    public float Health { get => health; set => health = value; }
    public float ProjectilePhysicalDamage { get => projectilePhysicalDamage; set => projectilePhysicalDamage = value; }
    public float ProjectileFireDamage { get => projectileFireDamage; set => projectileFireDamage = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public float PhysicalDamageResistance { get => physicalDamageResistance; set => physicalDamageResistance = value; }
    public float FireDamageResistance { get => fireDamageResistance; set => fireDamageResistance = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        TowerPanel = GameObject.Find("TowerPanel").GetComponent<TowerPanel>();

        Health = 50.0f;
        ProjectilePhysicalDamage = 1.0f;
        ProjectileFireDamage = 0.0f;
        FireRate = 2.5f;
        ProjectileSpeed = 500.0f;

        projectileSpawn = transform.GetChild(0).gameObject;

        if (roundSpawning.bInRound)
        {
            InvokeRepeating("FireProjectile", 1.0f, FireRate);
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
        InvokeRepeating("FireProjectile", 1.0f, FireRate);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!overlay.bBuyingTower)
        {
            TowerPanel.MoveOnScreen(this);
        }
    }

    void FireProjectile()
    {
        GameObject Projectile = Instantiate(projectilePrefab, projectileSpawn.transform);
        Projectile.GetComponent<Projectile>().projectileSpeed = ProjectileSpeed;
        Projectile.GetComponent<Projectile>().projectileDamage = ProjectilePhysicalDamage;
    }

    void TakeDamage(float value)
    {
        Health -= value;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
