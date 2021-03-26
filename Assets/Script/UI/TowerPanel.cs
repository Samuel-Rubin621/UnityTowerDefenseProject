using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
    #region Variables
    // Variables for moving the panel on/off screen
    private RectTransform position;
    private Vector2 onScreenPosition = new Vector2(0, 0f);
    private Vector2 offScreenPosition = new Vector2(0, 400f);

    // Text references
    private Text FireRateText;
    private Text DamageText;
    private Text FireDamageText;
    private Text ResistanceText;
    private Text FireResistanceText;

    // Module variables
    private Image module1;
    private Image module2;
    private Image module3;
    private Image module4;

    // Object references
    private Overlay overlay;
    public Tower tower;
    public Modules modules;
    private InventoryPanel inventoryPanel;
    private Camera camera;

    // Other script variables
    public bool bMovingTower;
    private GameObject followTower;
    [SerializeField] private GameObject dummyTower;
    #endregion

    #region Setup
    // Start is called before the first frame update
    void Start()
    {
        // Get all reference object info
        overlay = GameObject.Find("Overlay").GetComponent<Overlay>();
        inventoryPanel = GameObject.Find("Overlay/InventoryPanel").GetComponent<InventoryPanel>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        // Get all text info
        FireRateText = transform.Find("TowerStatsDisplayer/FireRateText").GetComponent<Text>();
        DamageText = transform.Find("TowerStatsDisplayer/DamageText").GetComponent<Text>();
        FireDamageText = transform.Find("TowerStatsDisplayer/FireDamageText").GetComponent<Text>();
        ResistanceText = transform.Find("TowerStatsDisplayer/ResistanceText").GetComponent<Text>();
        FireResistanceText = transform.Find("TowerStatsDisplayer/FireResistanceText").GetComponent<Text>();

        // Get all module info
        module1 = transform.Find("Module1").GetComponent<Image>();
        module2 = transform.Find("Module2").GetComponent<Image>();
        module3 = transform.Find("Module3").GetComponent<Image>();
        module4 = transform.Find("Module4").GetComponent<Image>();

        position = GetComponent<RectTransform>();
        Invoke("MoveOffScreen", 0.0001f) ;
    }
    
    // Setup the text to display the information of the selected tower
    public void SetupText()
    {
        if (tower)
        {
            FireRateText.text = "Fire Rate:           " + tower.FireRate.ToString();
            DamageText.text = "Damage:              " + tower.ProjectilePhysicalDamage.ToString();
            FireDamageText.text = "Fire Damage:         " + tower.ProjectileFireDamage.ToString();
            ResistanceText.text = "Resistance:          " + tower.PhysicalDamageResistance.ToString();
            FireResistanceText.text = "Fire Resistance:     " + tower.FireDamageResistance.ToString();
        }
        else { SetupText(); } // Keep repeating if the reference to tower was not created fast enough
    }

    // Setup the images in each of the slots on the panel according to the modules on the tower
    public void SetupSlots()
    {
        module1.sprite = modules.slots[0].GetComponent<Image>().sprite;
        module2.sprite = modules.slots[1].GetComponent<Image>().sprite;
        module3.sprite = modules.slots[2].GetComponent<Image>().sprite;
        module4.sprite = modules.slots[3].GetComponent<Image>().sprite;

        module1.useSpriteMesh = true;
        module2.useSpriteMesh = true;
        module3.useSpriteMesh = true;
        module4.useSpriteMesh = true;
    }
    #endregion

    #region Move Tower
    public void MoveTower()
    {
        if (!bMovingTower && !overlay.bBuyingTower)
        {
            MoveOffScreen();
            bMovingTower = true;
            overlay.ToggleButtons();

            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            followTower = Instantiate(dummyTower, mousePosition, Quaternion.identity);
        }
    }

    public void CancelMove()
    {
        bMovingTower = false;
        overlay.ToggleButtons();
        Destroy(followTower);
    }
    #endregion

    #region Screen Movement
    public void MoveOnScreen(Tower towerReference)
    {
        tower = towerReference;
        modules = tower.gameObject.GetComponent<Modules>();
        SetupText();
        SetupSlots();
        position.anchoredPosition = onScreenPosition;
    }

    public void MoveOffScreen()
    {
        inventoryPanel.MoveOffScreen();
        position.anchoredPosition = offScreenPosition;
    }

    public void Module1()
    {
        inventoryPanel.MoveOnScreen(1);
        inventoryPanel.Tower = tower.gameObject;
    }

    public void Module2()
    {
        inventoryPanel.MoveOnScreen(2);
        inventoryPanel.Tower = tower.gameObject;
    }
    
    public void Module3()
    {
        inventoryPanel.MoveOnScreen(3);
        inventoryPanel.Tower = tower.gameObject;
    }

    public void Module4()
    {
        inventoryPanel.MoveOnScreen(4);
        inventoryPanel.Tower = tower.gameObject;
    }
    #endregion
}
