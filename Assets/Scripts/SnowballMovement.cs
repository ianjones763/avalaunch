using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovement : MonoBehaviour {

    public float upForce = 200f;
    public float growthRate = 0.01f;

    public float threshholdSpeed = 5f;
    public bool isGrounded;
    public LayerMask groundLayers;

    private Rigidbody2D rb2d;
    private CircleCollider2D snowballCollider;

    void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        snowballCollider = GetComponent<CircleCollider2D>();
    }


    /* Checks:
       1) Only allows jumping when player !GameControllinstance.gameOver and isGrounded.
       2) Size of snowball increases when isGrounded, decreases when !isGrounded, with min & max sizes.
    */
    void Update()
    {

        /* End game when dead */
        if (GameControl.instance.gameOver) {
            endGame();
            return;
        }

        float radius = snowballCollider.radius * transform.localScale[0] + 0.1f;
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), radius, groundLayers);

        /* Size change mechanic */
        if (isGrounded && transform.localScale[0] < GameControl.instance.maxSize) {
            // Grow if maxSize hasn't been reached
            transform.localScale += new Vector3(growthRate, growthRate, 0);
        } else if (!isGrounded && transform.localScale[0] > GameControl.instance.minSize && rb2d.velocity[1] < threshholdSpeed)
        {
            // Shrink if minSize hasn't been reached
            transform.localScale -= new Vector3(growthRate, growthRate, 0);
        }

        updateSpeed(transform.localScale);      // Update speed based on size

        /* Movement */
        if (!GameControl.instance.gameOver)
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
    }

    void updateSpeed(Vector3 sizeVec)
    {
        GameControl.instance.size = sizeVec.x;
        float exp = 5.0f / 3.0f;
        GameControl.instance.foregroundXScrollSpeed = -Mathf.Pow(GameControl.instance.size, exp);
        GameControl.instance.background1ScrollSpeed = -Mathf.Pow(GameControl.instance.size, exp) * 2f/3f;
        GameControl.instance.background2ScrollSpeed = -Mathf.Pow(GameControl.instance.size, exp) * 1f/6f;
        GameControl.instance.background3ScrollSpeed = -Mathf.Pow(GameControl.instance.size, exp) * 1f/12f;
        GameControl.instance.background4ScrollSpeed = -Mathf.Pow(GameControl.instance.size, exp) * 1f/24f;
        GameControl.instance.skyScrollSpeed         = -Mathf.Pow(GameControl.instance.size, exp) * 1f/48f;
    }


    /* Ends the game */
    void endGame() 
    {
        GameControl.instance.Died();
    }
}
