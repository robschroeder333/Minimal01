using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldController : MonoBehaviour {
public GameObject prefab;
public float gridX = 10f;
public float gridY = 20f;
public float spacing = 1f;
public float levelLimit = 100f;


void Start() {
    for (float y = 0; y < gridY; y++) {
        Color layerColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        for (float x = 0; x < gridX; x++) {
            if (Random.value * levelLimit > y % levelLimit) {
                float offsetX = x - Mathf.Floor(gridX / 2);
                Vector2 pos = new Vector2(offsetX, -y) * spacing;
                GameObject block = Instantiate(prefab, pos, Quaternion.identity);
                block.GetComponent<Renderer>().material.color = layerColor;
            } 
        }
    }
} 
	
	// Update is called once per frame
	void Update () {
		
	}
}
