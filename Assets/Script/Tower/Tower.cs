using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    #region Variables
    // Tower base stats used for module modifiers
    [SerializeField] private float baseHealth;
    [SerializeField] private float baseFireRate;
    [SerializeField] private float baseProjectileSpeed;
    [SerializeField] private float basePhysicalDamage;
    [SerializeField] private float baseFireDamage;
    [SerializeField] private float basePhysicalResistance;
    [SerializeField] private float baseFireResistance;

    // Tower stat variables
    private float health;
    private float fireRate;
    private float projectileSpeed;
    private float projectilePhysicalDamage;
    private float projectileFireDamage;
    private float physicalDamageResistance;
    private float fireDamageResistance;

    // Tower stat Get and Set functions
    public float Health { get => health; set => health = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public float ProjectilePhysicalDamage { get => projectilePhysicalDamage; set => projectilePhysicalDamage = value; }
    public float ProjectileFireDamage { get => projectileFireDamage; set => projectileFireDamage = value; }
    public float PhysicalDamageResistance { get => physicalDamageResistance; set => physicalDamageResistance = value; }
    public float FireDamageResistance { get => fireDamageResistance; set => fireDamageResistance = value; }

    // Reference variables
    private GameObject projectileSpawn;
    private RoundSpawning roundSpawning;
    private TowerPanel towerPanel;
    private Overlay overlay;

    // Prefab variables set in the Investigator
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject towerPanelPrefab;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        towerPanel = GameObject.Find("TowerPanel").GetComponent<TowerPanel>();

        // Setup stat values
        Health = baseHealth;
        ProjectilePhysicalDamage = basePhysicalDamage;
        ProjectileFireDamage = baseFireDamage;
        FireRate = baseFireRate;
        ProjectileSpeed = baseProjectileSpeed;
        PhysicalDamageResistance = basePhysicalResistance;
        FireDamageResistance = baseFireResistance;

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
        if (!overlay.bBuyingTower && !towerPanel.bMovingTower)
        {
            towerPanel.MoveOnScreen(this);
        }
    }

    void FireProjectile()
    {
        GameObject Projectile = Instantiate(projectilePrefab, projectileSpawn.transform);
    }

    public void TakeDamage(float incomingPhysicalDamage, float incomingFireDamage)
    {
        Debug.Log("Taking damage" + incomingPhysicalDamage.ToString() + " and " + incomingFireDamage.ToString());
        Health -= ((incomingPhysicalDamage - (incomingPhysicalDamage * PhysicalDamageResistance)) + (incomingFireDamage - (incomingFireDamage * FireDamageResistance)));

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
