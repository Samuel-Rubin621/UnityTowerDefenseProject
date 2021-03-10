using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private Camera _camera;

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
