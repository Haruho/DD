using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testchasing : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(target.position,transform.position) > 0.1f)
        {
            transform.Translate((target.position - transform.position) *Time.deltaTime * 0.5f);
        }
	}
}
