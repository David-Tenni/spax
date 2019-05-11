﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private Transform enemyHolder;
	public float speed;

	public GameObject shot;
	public float fireRate = 0.997f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MoveEnemy", 0.1f, 0.3f);
		enemyHolder = GetComponent<Transform> ();
	}

	void MoveEnemy()
	{
		enemyHolder.position += Vector3.right * speed;

		foreach (Transform enemy in enemyHolder) {
			if (enemy.position.x < -4.45 || enemy.position.x > 5.5) {
				speed = -speed;
				enemyHolder.position += Vector3.up * 0.5f;
				return;
			}

			//EnemyBulletController called too?
			if (Random.value > fireRate) {
				Instantiate (shot, enemy.position, enemy.rotation);
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
        }
    }
}
