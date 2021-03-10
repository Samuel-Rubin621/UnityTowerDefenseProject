using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    //Variables local variables for the script
    //private bool bHasTower;

    //Reference variables
    private Overlay canvasScript;
    public GameObject TowerInPosition;

    // Start is called before the first frame update
    void Start()
    {
        canvasScript = GameObject.Find("Overlay").GetComponent<Overlay>();
        //bHasTower = false;
    }

    public void BuildTower(GameObject TowerToBuild)
    {
        TowerInPosition = Instantiate(TowerToBuild, this.transform);
        //bHasTower = true;
    }
}
