﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: 

public class characterController : MonoBehaviour {
	public gameObject bullet;
	public float maxSpeed = 10f;
	public float jumpHeight = 5f;
	private Rigidbody2D rb;
	private trigger cLeft;
	private trigger cRight;
	private trigger cUp;
	private trigger cDown;
	private Vector2 target; 
	private Vector2 targetRecord = Vector2.right;

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
		Debug.Log(target);
		float horizontal = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump"); 
		float vertical = Input.GetAxis("Vertical");
		bool shoot = Input.GetAxis("Fire1") > 0;
		bool canShoot = true;
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
		if (shoot) {
			Instantiate(bullet, gameObject.transform.position + target, Quaternion.identity);
			//canShoot = false;? give bullet direction for it to move in
		}
	}
}
