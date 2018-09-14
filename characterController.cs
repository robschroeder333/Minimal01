using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: not changing target's position (is it necessary to have as child object?)

public class characterController : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpHeight = 5f;
	private Rigidbody2D rb;
	private trigger cLeft;
	private trigger cRight;
	private trigger cUp;
	private trigger cDown;
	private Vector3 target; 
	private Vector3 targetRecord = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		cLeft = transform.Find("cLeft").gameObject.GetComponent<trigger>();
		cRight = transform.Find("cRight").gameObject.GetComponent<trigger>();
		cUp = transform.Find("cUp").gameObject.GetComponent<trigger>();
		cDown = transform.Find("cDown").gameObject.GetComponent<trigger>();
		target = transform.Find("target").position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump"); 
		float vertical = Input.GetAxis("Vertical");
		if (horizontal < 0 && !cLeft.touching) {
			rb.velocity = new Vector2(horizontal * maxSpeed, rb.velocity.y);
			target = new Vector3(-1, 0, 0);
			targetRecord = target;
		}
		if (horizontal > 0 && !cRight.touching) {
			rb.velocity = new Vector2(horizontal * maxSpeed, rb.velocity.y);
			target = new Vector3(1, 0, 0);
			targetRecord = target;
		}
		if (vertical > 0 && horizontal == 0) {
			target = new Vector3(0, 1, 0);
		}
		if (vertical < 0 && horizontal == 0) {
			target = new Vector3(0, -1, 0);
		}
		if (vertical == 0 && horizontal == 0) {
			target = targetRecord;
		}
		if (!cUp.touching && cDown.touching && jump) {
			rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
		}
		
	}
}
