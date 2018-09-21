using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	public GameObject source;
	public Vector2 target;
	public float speed = 5.0f;
	public float damage = 5.0f;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().velocity = target * speed;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (source.name == "character" && other.tag == "Env" || other.tag == "Enemy" || other.tag == "Boundary") {
			other.GetComponent<healthHandler>().health -= damage;
			Destroy(gameObject);
		}	
	}
}
