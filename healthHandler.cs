using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHandler : MonoBehaviour {
	public float health;
	// Use this for initialization
	void Start () {
		if (gameObject.tag == "Player") {
			health = 100.0f;
		}
		if (gameObject.tag == "Env") {
			health = 5.0f;
		}
		if (gameObject.tag == "Enemy") {
			health = 50.0f;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
