using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
    // Text references
    private Text FireRateText;
    private Text DamageText;
    private Text FireDamageText;
    private Text ResistanceText;
    private Text FireResistanceText;

    // Object references
    private Tower towerReference;
    private InventoryPanel inventoryPanel;

    public Tower TowerReference { get => towerReference; set => towerReference = value; }
    public InventoryPanel InventoryPanel { get => inventoryPanel; set => inventoryPanel = value; }


    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel = GameObject.Find("Overlay/InventoryPanel").GetComponent<InventoryPanel>();

        FireRateText = GameObject.Find("Overlay/TowerPanel(Clone)/TowerStatsDisplayer/FireRateText").GetComponent<Text>();
        DamageText = GameObject.Find("Overlay/TowerPanel(Clone)/TowerStatsDisplayer/DamageText").GetComponent<Text>();
        FireDamageText = GameObject.Find("Overlay/TowerPanel(Clone)/TowerStatsDisplayer/FireDamageText").GetComponent<Text>();
        ResistanceText = GameObject.Find("Overlay/TowerPanel(Clone)/TowerStatsDisplayer/ResistanceText").GetComponent<Text>();
        FireResistanceText = GameObject.Find("Overlay/TowerPanel(Clone)/TowerStatsDisplayer/FireResistanceText").GetComponent<Text>();
        SetupText();

    }

    private void SetupText()
    {
        if (TowerReference)
        {
            FireRateText.text = "Fire Rate:           " + TowerReference.FireRate.ToString();
            DamageText.text = "Damage:              " + TowerReference.ProjectilePhysicalDamage.ToString();
            FireDamageText.text = "Fire Damage:         " + TowerReference.ProjectileFireDamage.ToString();
            ResistanceText.text = "Resistance:          " + TowerReference.PhysicalDamageResistance.ToString();
            FireResistanceText.text = "Fire Resistance:     " + TowerReference.FireDamageResistance.ToString();
        }
        else { SetupText(); }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Module1()
    {
        InventoryPanel.MoveOnScreen();
        InventoryPanel.TowerReference = TowerReference;
    }

    public void Module2()
    {
        InventoryPanel.MoveOnScreen();
        InventoryPanel.TowerReference = TowerReference;
    }
    
    public void Module3()
    {
        InventoryPanel.MoveOnScreen();
        InventoryPanel.TowerReference = TowerReference;
    }

    public void Module4()
    {
        InventoryPanel.MoveOnScreen();
        InventoryPanel.TowerReference = TowerReference;
    }

    public void ClosePanel()
    {
        InventoryPanel.MoveOffScreen();
        Destroy(gameObject);
    }
}
