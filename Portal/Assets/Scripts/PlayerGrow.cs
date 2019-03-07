using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour {

    public float speed = 0.1f;
    Vector3 temp;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        temp = transform.localScale;

        temp.x += 0.001f;
        temp.y += 0.001f;
        temp.z += 0.001f;

        transform.localScale = temp;
	}
}
