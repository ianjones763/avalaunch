using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovement : MonoBehaviour {

    public float upForce = 200f;
    public bool isGrounded;
    public LayerMask groundLayers;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private CircleCollider2D snowballCollider;


	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        snowballCollider = GetComponent<CircleCollider2D>();
	}


    /* Checks:
       1) Only allows jumping when player !isDead and isGrounded.
       2) Size of snowball increases when isGrounded, decreases when !isGrounded.
    */
    void Update()
    {
        float radius = snowballCollider.radius * transform.localScale[0] + 0.1f;
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), radius, groundLayers);
        // Check if rolling backwards, if so you lose
        //if (rb2d.velocity.x < 0) isDead = true

        if (!isDead)
        {
            /* Need to add physics here */
            if (Input.GetMouseButtonDown(0) && isGrounded) /* Click to jump */
            {
                rb2d.AddForce(new Vector2(0, upForce));
            }

            if (isGrounded) {
                SoundManagerScript.PlaySound("snowballRoll");
            }
        }
        else
        {
            endGame();
        }
    }


    /* Ends the game */
    void endGame() 
    {
        Debug.Log("GAME OVER");
        GameControl.instance.Died();
    }
}
