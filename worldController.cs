using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldController : MonoBehaviour {
public GameObject prefab;
public float gridX = 5f;
public float gridY = 5f;
public float spacing = 1.5f;

void Start() {
    for (float y = 0; y < gridY; y++) {
        for (float x = 0; x < gridX; x++) {
            float offsetX = x - Mathf.Floor(gridX / 2);
			Vector2 pos = new Vector2(offsetX, -y) * spacing;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
} 
	
	// Update is called once per frame
	void Update () {
		
	}
}
