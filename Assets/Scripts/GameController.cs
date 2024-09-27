using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Mountain Gen controller
    [SerializeField] private GameObject mountainPrefab;
    [SerializeField] private float genX = 12f;
    [SerializeField] private float genY = 1f;

    //Time Gen controller 
    [SerializeField] private float timer = 3f;
    private float timerReset;

    //Pontuation controller
    private float pontuation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timerReset = timer;
    }

    // Update is called once per frame
    void Update()
    {
        MountainGenerator();
    }

    public void MountainGenerator()
    {
        if (timer <= 0)
        {
            Instantiate(mountainPrefab, new Vector3(genX, Random.Range(-genY, genY), 0), Quaternion.identity);
            timer = Random.Range(1, timerReset);
        }

        timer -= Time.deltaTime;

    }

    public void AddPontuation()
    {
        pontuation += Time.deltaTime;
    }


}
