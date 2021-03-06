﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BUGS: collision detection for cDown

TODO:

 */
public class characterController : MonoBehaviour {
	public GameObject bullet;
	public float maxSpeed = 10f;
	public float jumpHeight = 5f;
	private Rigidbody2D rb;
	private trigger cLeft;
	private trigger cRight;
	private trigger cUp;
	private trigger cDown;
	private Vector2 target; 
	private Vector2 targetRecord = Vector2.right;
	private float lastShot = 0.0f;
	public float shotDelay = 0.2f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		cLeft = transform.Find("cLeft").gameObject.GetComponent<trigger>();
		cRight = transform.Find("cRight").gameObject.GetComponent<trigger>();
		cUp = transform.Find("cUp").gameObject.GetComponent<trigger>();
		cDown = transform.Find("cDown").gameObject.GetComponent<trigger>();
	}
	
	// Update is called once per frame
	void Update() {
		//might have to use onCollision instead of onTrigger
		if(cDown.touching) {
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		} else {
			gameObject.GetComponent<Renderer>().material.color = Color.green;
			
		}
		float horizontal = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump"); 
		float vertical = Input.GetAxis("Vertical");
		bool shoot = Input.GetAxis("Fire1") > 0;

		//move/aim left
		if (horizontal < 0 && !cLeft.touching) {
			rb.velocity = new Vector2(horizontal * maxSpeed, rb.velocity.y);
			target = Vector2.left;
			targetRecord = target;
		}
		//move/aim right
		if (horizontal > 0 && !cRight.touching) {
			rb.velocity = new Vector2(horizontal * maxSpeed, rb.velocity.y);
			target = Vector2.right;
			targetRecord = target;
		}
		//aim up
		if (vertical > 0 && horizontal == 0) {
			target = Vector2.up;
		}
		//aim down
		if (vertical < 0 && horizontal == 0) {
			target = Vector2.down;
		}
		//remember horizontal target direction
		if (vertical == 0 && horizontal == 0) {
			target = targetRecord;
		}
		//jump
		if (!cUp.touching && cDown.touching && jump) {
			rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
		}
		//shoot
		if (shoot && canShoot()) {
			if (cDown.touching && target == Vector2.down) {
				Debug.Log("cannot fire");
			} else {
				Fire(target);
			}
		}
	}
	void Fire(Vector2 direction) {
		float tempX = gameObject.transform.position.x;
		float tempY = gameObject.transform.position.y;
		Vector2 shotPos = new Vector2(tempX + direction.x, tempY + direction.y);
		GameObject shot = Instantiate(bullet, shotPos, Quaternion.identity);
		shot.GetComponent<bullet>().source = gameObject;
		shot.GetComponent<bullet>().target = direction;
		lastShot = Time.time;
	}
	bool canShoot() {
		if (Time.time > lastShot + shotDelay) {
			return true;
		}
		return false;
	}
}
