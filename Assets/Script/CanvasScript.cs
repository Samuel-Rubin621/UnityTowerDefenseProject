using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        UIExists = false;
    }

    public void CreateMenu(GameObject Prefab, PurchaseMenuScript Script, string refName)
    {
        if (!UIExists)
        {
            UIExists = true;

            GameObject Menu = Instantiate(Prefab, this.transform);
            Script = Menu.GetComponent<PurchaseMenuScript>();
            Script.refName = refName;
        }
    }
    
    public void CreateMenu(GameObject Prefab, TowerMenuScript Script, string refName)
    {
        Debug.Log("Making tower menu!");
        /*
        if (!UIExists)
        {
            UIExists = true;

            GameObject Menu = Instantiate(Prefab, this.transform);
            Script = Menu.GetComponent<TowerMenuScript>();
            Script.refName = refName;
        }*/
    }
    
}
