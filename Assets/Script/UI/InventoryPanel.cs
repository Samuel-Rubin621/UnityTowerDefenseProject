using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private RectTransform position;
    private Vector2 onScreenPosition = new Vector2(0,0f);
    private Vector2 offScreenPosition = new Vector2(0,400f);

    private Tower towerReference;

    public Tower TowerReference { get => towerReference; set => towerReference = value; }

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<RectTransform>();
        MoveOffScreen();
    }

    public void MoveOnScreen()
    {
        position.anchoredPosition = onScreenPosition;
    }

    public void MoveOffScreen()
    {
        position.anchoredPosition = offScreenPosition;
    }



}
