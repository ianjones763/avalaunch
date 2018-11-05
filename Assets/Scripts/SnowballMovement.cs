using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovement : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;

	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        // Check if rolling backwards, if so you lose
        //if (rb2d.velocity.x < 0) isDead = true

        if (!isDead)
        {
            /* Need to add physics here */
            if (Input.GetMouseButtonDown(0)) /* Click to jump */
            {
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
        else
        {
            endGame();
        }
    }

    void endGame() 
    {
        Debug.Log("GAME OVER");
        GameControl.instance.Died();
    }
}
