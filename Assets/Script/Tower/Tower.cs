using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    #region Variables
    // Tower base stats used for module modifiers
    private float baseProjectilePhysicalDamage;
    private float baseProjectileFireDamage;
    private float baseFireRate;
    private float baseProjectileSpeed;
    private float baseHealth;
    private float basePhysicalDamageResistance;
    private float baseFireDamageResistance;

    // Base value Get and Set functions
    public float BaseProjectilePhysicalDamage { get => baseProjectilePhysicalDamage; set => baseProjectilePhysicalDamage = value; }
    public float BaseProjectileFireDamage { get => baseProjectileFireDamage; set => baseProjectileFireDamage = value; }
    public float BaseFireRate { get => baseFireRate; set => baseFireRate = value; }
    public float BaseProjectileSpeed { get => baseProjectileSpeed; set => baseProjectileSpeed = value; }
    public float BaseHealth { get => baseHealth; set => baseHealth = value; }
    public float BasePhysicalDamageResistance { get => basePhysicalDamageResistance; set => basePhysicalDamageResistance = value; }
    public float BaseFireDamageResistance { get => baseFireDamageResistance; set => baseFireDamageResistance = value; }

    // Tower stat variables
    public float projectilePhysicalDamage;
    private float projectileFireDamage;
    private float fireRate;
    private float projectileSpeed;
    private float health;
    public float physicalDamageResistance;
    private float fireDamageResistance;

    // Tower stat Get and Set functions
    public float ProjectilePhysicalDamage { get => projectilePhysicalDamage; set => projectilePhysicalDamage = value; }
    public float ProjectileFireDamage { get => projectileFireDamage; set => projectileFireDamage = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public float Health { get => health; set => health = value; }
    public float PhysicalDamageResistance { get => physicalDamageResistance; set => physicalDamageResistance = value; }
    public float FireDamageResistance { get => fireDamageResistance; set => fireDamageResistance = value; }

    // Module variables
    private TowerPanel towerPanel;

    // Reference variables
    private GameObject projectileSpawn;
    private RoundSpawning roundSpawning;
    private Overlay overlay;

    // Prefab variables set in the editor
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject towerPanelPrefab;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        roundSpawning = GameObject.Find("GameManager").GetComponent<RoundSpawning>();
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        towerPanel = GameObject.Find("TowerPanel").GetComponent<TowerPanel>();

        // Setup base stat values for module modifiers
        BaseHealth = 50.0f;
        BaseProjectilePhysicalDamage = 100.0f;
        BaseProjectileFireDamage = 10.0f;
        BaseFireRate = 2.0f;
        BaseProjectileSpeed = 500.0f;
        BasePhysicalDamageResistance = 10.0f;
        BaseFireDamageResistance = 10.0f;

        // Setup stat values
        Health = BaseHealth;
        ProjectilePhysicalDamage = BaseProjectilePhysicalDamage;
        ProjectileFireDamage = BaseProjectileFireDamage;
        FireRate = BaseFireRate;
        ProjectileSpeed = BaseProjectileSpeed;
        PhysicalDamageResistance = BasePhysicalDamageResistance;
        FireDamageResistance = BaseFireDamageResistance;

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

    public IEnumerator ResetTower()
    {
        Health = BaseHealth;
        ProjectilePhysicalDamage = BaseProjectilePhysicalDamage;
        ProjectileFireDamage = BaseProjectileFireDamage;
        FireRate = BaseFireRate;
        ProjectileSpeed = BaseProjectileSpeed;
        PhysicalDamageResistance = BasePhysicalDamageResistance;
        FireDamageResistance = BaseFireDamageResistance;
        yield return null;
    }

    public IEnumerator MovedTower(Tower movedTower)
    {
        yield return new WaitForSeconds(1);
        Health = movedTower.Health;
        ProjectilePhysicalDamage = movedTower.ProjectilePhysicalDamage;
        ProjectileFireDamage = movedTower.ProjectileFireDamage;
        FireRate = movedTower.FireRate;
        ProjectileSpeed = movedTower.ProjectileSpeed;
        PhysicalDamageResistance = movedTower.PhysicalDamageResistance;
        FireDamageResistance = movedTower.FireDamageResistance;
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
