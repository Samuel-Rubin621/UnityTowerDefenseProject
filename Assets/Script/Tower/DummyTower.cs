using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : MonoBehaviour
{
    // Private variables that are changable in the editor

    // Private variables only changeable through script
    private Vector3 mousePosition;
    private float moveSpeed = 0.1f;

    // Public variables

    // Reference variables
    private Camera _camera;

    // Prefab variables

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
