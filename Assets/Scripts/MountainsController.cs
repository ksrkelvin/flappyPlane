using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MountainsController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {

        gameController = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();

    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * (speed + gameController.level) * Time.deltaTime;

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

}
