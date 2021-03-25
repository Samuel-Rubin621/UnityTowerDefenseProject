using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Animator animator;
    private Animation animation;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
