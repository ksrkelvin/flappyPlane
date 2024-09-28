
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private TextMeshProUGUI canvasPontuation;

    //Level controller
    private int _level = 1;
    public int level
    {
        get { return _level; }
        set { _level = value; }
    }

    [SerializeField] private int nextLevel = 10;
    [SerializeField] private TextMeshProUGUI canvasLevel;
    [SerializeField] AudioClip levelUpSound;
    [SerializeField] Transform camPos;


    // Start is called before the first frame update
    void Start()
    {
        timerReset = timer;
    }

    // Update is called once per frame
    void Update()
    {
        MountainGenerator();
        SetPontuation();
        LevelUp();
        
    }

    public void MountainGenerator()
    {
        if (timer <= 0)
        {
            Instantiate(mountainPrefab, new Vector3(genX, Random.Range(-genY, genY), 0), Quaternion.identity);
            timer = Random.Range(1/level, timerReset);
        }

        timer -= Time.deltaTime;

    }

    public void SetPontuation()
    {
        pontuation += Time.deltaTime;
        canvasPontuation.text = Mathf.Round(pontuation).ToString();
    }

    public void LevelUp()
    {

        if (pontuation >= nextLevel)
        {
            level++;
            PlayLevelUpSound();
            nextLevel*=2;
        }

        canvasLevel.text = level.ToString();
        
    }

    public void PlayLevelUpSound()
    {
        AudioSource.PlayClipAtPoint(levelUpSound, camPos.position);

    }

    


}
