using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienController : MonoBehaviour
{
    private bool goLeft;
    void Start()
    {
    }

    void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        if (!goLeft)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            goLeft = !goLeft;
        }
    }


}
