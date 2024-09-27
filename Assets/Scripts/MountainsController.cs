using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsController : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        MoveLeft();
        
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
