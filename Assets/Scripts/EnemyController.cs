using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
    public AudioSource deathsound;
	private Transform enemyHolder;
	public float speed;

	public float fireRate = 0.997f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MoveEnemy", 0.1f, 0.3f);
		enemyHolder = GetComponent<Transform> ();
	}

    private void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.X))
        {
            GoToEndGameScene();
        }
#endif
    }

    void MoveEnemy()
	{
		enemyHolder.position += Vector3.right * speed;

		foreach (Transform enemy in enemyHolder) {
			if (enemy.position.x < -8 || enemy.position.x > 8) {
				speed = -speed;
				enemyHolder.position += Vector3.up * 0.5f;
				return;
			}



			if (enemy.position.y <= -4) {
				Time.timeScale = 0;
			}
		}

		if (enemyHolder.childCount == 1) {
			CancelInvoke ();
			InvokeRepeating ("MoveEnemy", 0.1f, 0.25f);
		}

		if (enemyHolder.childCount == 0) {
		}
	}
    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag == "Crate")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            deathsound.Play();
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            //Time.timeScale = 0;
            Destroy(gameObject);
            GoToEndGameScene();
  
        }
    }

    private void GoToEndGameScene()
    {
        SceneManager.LoadScene("ENDGAME");
    }
}
