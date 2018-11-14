using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    //private Animator myAnimator;

    // Movement stuff
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    // Grounding stuff
    [SerializeField] private Transform[] groundPoints;
    [SerializeField] private float groundRadius;
    [SerializeField] LayerMask whatIsGround;
    private bool isGrounded;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        isGrounded = IsGrounded();

        //if (isGrounded) 
        //{
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            GameControl.instance.norm = hit.normal;
        //}
    }


    private bool IsGrounded()
    {
        foreach (Transform point in groundPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position,
                                                                groundRadius,
                                                                whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    //myAnimator.SetBool("isJumping", false);
                    //myAnimator.SetBool("isLanding", false);
                    return true;
                }
            }
        }
        return false;
    }
}
