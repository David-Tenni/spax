using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Crate;
    public float speed;
    public float score;
    public int ammo;
    public Text scoreText;
    public Text ammoText;
    private Rigidbody2D rb2d;
    void Start()
    {
        ammo = 20;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1")&& ammo > 0)
        {
            Fire();
        }
    }
    public void updateScore(float points) {
        score = score + points;
        Debug.Log(score);
        scoreText.text = "Score: " + score;

    }
    void Fire()
    {
        Instantiate(Crate, transform.position, transform.rotation);
        ammo--;
        ammoText.text = "Crates: " + ammo;

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector2 movement = new Vector2(moveHorizontal, 0f);

        rb2d.AddForce(movement * speed);
    }

}
