using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour {

    private float movespeed = 3f;
	
	void Update () {
        transform.Translate(new Vector2(-1, .5f) * movespeed * Time.deltaTime);
	}
}
