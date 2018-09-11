using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
	public float maxSpeed = 10;
	private Rigidbody2D rb;
	private trigger cLeft;
	private trigger cRight;
	private trigger cUp;
	private trigger cDown;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		cLeft = transform.Find("cLeft").gameObject.GetComponent<trigger>();
		cRight = transform.Find("cRight").gameObject.GetComponent<trigger>();
		cUp = transform.Find("cUp").gameObject.GetComponent<trigger>();
		cDown = transform.Find("cDown").gameObject.GetComponent<trigger>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal"); 
		// float vertical = Input.GetAxis("Vertical");
		if (horizontal < 0 && !cLeft.touching) {
			rb.velocity = new Vector2(horizontal * 10, rb.velocity.y);
		}
		if (horizontal > 0 && !cRight.touching) {
			rb.velocity = new Vector2(horizontal * 10, rb.velocity.y);
		}
	}
}
