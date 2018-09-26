using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {

	public bool touching;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		touching = true;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		touching = true;
	}
	void OnTriggerExit2D(Collider2D other) {
		touching = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
