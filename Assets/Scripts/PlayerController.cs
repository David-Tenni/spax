using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Crate;
    public float speed;             
    private Rigidbody2D rb2d;  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Crate, transform.position, transform.rotation);
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector2 movement = new Vector2(moveHorizontal, 0f);

        rb2d.AddForce(movement * speed);
    }
}
