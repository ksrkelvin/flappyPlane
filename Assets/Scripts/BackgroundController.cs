using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private Renderer bg;
    [SerializeField] private float speed;
    private float xOffSet;
    // Start is called before the first frame update
    void Start()
    {

        bg = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackground();
    }

    void UpdateBackground()
    {
        bg.material.mainTextureOffset = new Vector2(xOffSet+=speed * Time.deltaTime, 0);
    }
}
