using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
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
    private Tower tower;
    private Modules modules;
    private InventoryPanel inventoryPanel;

    public Tower Tower { get => tower; set => tower = value; }
    public Modules Modules { get => modules; set => modules = value; }
    public InventoryPanel InventoryPanel { get => inventoryPanel; set => inventoryPanel = value; }


    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel = GameObject.Find("Overlay/InventoryPanel").GetComponent<InventoryPanel>();
        FireRateText = transform.Find("TowerStatsDisplayer/FireRateText").GetComponent<Text>();
        DamageText = transform.Find("TowerStatsDisplayer/DamageText").GetComponent<Text>();
        FireDamageText = transform.Find("TowerStatsDisplayer/FireDamageText").GetComponent<Text>();
        ResistanceText = transform.Find("TowerStatsDisplayer/ResistanceText").GetComponent<Text>();
        FireResistanceText = transform.Find("TowerStatsDisplayer/FireResistanceText").GetComponent<Text>();
        module1 = transform.Find("Module1").GetComponent<Image>();
        module2 = transform.Find("Module2").GetComponent<Image>();
        module3 = transform.Find("Module3").GetComponent<Image>();
        module4 = transform.Find("Module4").GetComponent<Image>();
        position = GetComponent<RectTransform>();
        Invoke("MoveOffScreen", 0.0001f) ;
    }

    public void SetupText()
    {
        if (Tower)
        {
            FireRateText.text = "Fire Rate:           " + Tower.FireRate.ToString();
            DamageText.text = "Damage:              " + Tower.ProjectilePhysicalDamage.ToString();
            FireDamageText.text = "Fire Damage:         " + Tower.ProjectileFireDamage.ToString();
            ResistanceText.text = "Resistance:          " + Tower.PhysicalDamageResistance.ToString();
            FireResistanceText.text = "Fire Resistance:     " + Tower.FireDamageResistance.ToString();
        }
        else { SetupText(); }
    }

    public void SetupSlots()
    {
        module1.sprite = Modules.slots[0].GetComponent<Image>().sprite;
        module2.sprite = Modules.slots[1].GetComponent<Image>().sprite;
        module3.sprite = Modules.slots[2].GetComponent<Image>().sprite;
        module4.sprite = Modules.slots[3].GetComponent<Image>().sprite;

        module1.useSpriteMesh = true;
        module2.useSpriteMesh = true;
        module3.useSpriteMesh = true;
        module4.useSpriteMesh = true;
    }

    public void MoveOnScreen(Tower towerReference)
    {
        Tower = towerReference;
        Modules = Tower.gameObject.GetComponent<Modules>();
        SetupText();
        SetupSlots();
        position.anchoredPosition = onScreenPosition;
    }

    public void MoveOffScreen()
    {
        InventoryPanel.MoveOffScreen();
        position.anchoredPosition = offScreenPosition;
    }

    public void Module1()
    {
        InventoryPanel.MoveOnScreen(1);
        InventoryPanel.Tower = Tower.gameObject;
    }

    public void Module2()
    {
        InventoryPanel.MoveOnScreen(2);
        InventoryPanel.Tower = Tower.gameObject;
    }
    
    public void Module3()
    {
        InventoryPanel.MoveOnScreen(3);
        InventoryPanel.Tower = Tower.gameObject;
    }

    public void Module4()
    {
        InventoryPanel.MoveOnScreen(4);
        InventoryPanel.Tower = Tower.gameObject;
    }
}
