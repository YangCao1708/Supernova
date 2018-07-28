﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Level2 : MonoBehaviour {

	public FaceDirection dir;
	public float speed = 6.0f;
	public GameObject explosion;
	private GameObject explo;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		switch (dir)
		{
			case FaceDirection.Down:
				transform.Translate(Vector3.down * speed * Time.deltaTime);
				break;

			case FaceDirection.Up:
				transform.Translate(Vector3.up * speed * Time.deltaTime);
				break;

			case FaceDirection.Left:
				transform.Translate(Vector3.left * speed * Time.deltaTime);
				break;

			case FaceDirection.Right:
				transform.Translate(Vector3.right * speed * Time.deltaTime);
				break;

		}
	}
	void OnTriggerEnter2D(Collider2D collision) {
		
		if(collision.gameObject.tag == "Wall")
		{
			Destroy(gameObject);
		}
		
		if(gameObject.CompareTag("Player2Bullet"))
		{
			if(collision.gameObject.tag == "Player1")
			{	
				Player1Status_Level2._instance.Damage(1);
				explo = (GameObject)Instantiate(explosion, collision.transform.position, Quaternion.identity);
				Destroy(explo,0.5f);
				Destroy(gameObject);
			}
			else if(collision.gameObject.CompareTag("Player1Bullet"))
			{
				explo = (GameObject)Instantiate(explosion, collision.transform.position, Quaternion.identity);
				Destroy(explo,0.5f);
				Destroy(gameObject);
			}
		}
		if (gameObject.CompareTag("Player1Bullet"))
		{	
			if(collision.gameObject.tag == "Player2")
			{
				Player2Status_Level2._instance.Damage(1);
				
				explo = (GameObject)Instantiate(explosion, collision.transform.position, Quaternion.identity);
				Destroy(explo,0.5f);
				Destroy(gameObject);
			}
			else if(collision.gameObject.CompareTag("Player2Bullet"))
			{
				explo = (GameObject)Instantiate(explosion, collision.transform.position, Quaternion.identity);
				Destroy(explo,0.5f);
				Destroy(gameObject);
			}
		}
	}

}
