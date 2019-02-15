using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testforslice : MonoBehaviour {
    Rigidbody2D rigi;
	// Use this for initialization
	void Start () {
        rigi = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("Add force");
            rigi.AddForce(new Vector2(Random.Range(-10,10),10));
        }
	}
}
