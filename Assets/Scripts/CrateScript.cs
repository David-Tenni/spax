using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "highScore")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "lowScore")
        {
            Destroy(gameObject);
        }
    }

}
