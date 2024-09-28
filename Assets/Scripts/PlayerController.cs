using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float limitArea;
    [SerializeField] private GameObject puff;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        SpeedLimit();
        Actions();
        AreaLimiter();

    }

    public void AreaLimiter(){
        if (transform.position.y > limitArea || transform.position.y < -limitArea)
        {
            SceneManager.LoadScene("menu");
        }
        
    }

    public void SpeedLimit()
    {
        //Falling speed limit
        if (rb.velocity.y < -speed)
        {
            rb.velocity = Vector2.down * speed;
        }
    }

    public void Actions()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {

        rb.velocity = Vector2.up * speed;

        GameObject newPuff = Instantiate(puff, transform.position, Quaternion.identity);

        Destroy(newPuff, 1f);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // SceneManager.LoadScene(0);
        SceneManager.LoadScene("menu");

       
    }
}

   
