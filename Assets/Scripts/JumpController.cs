using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Tooltip("Force of Jump applied")]    
    public float JumpForce = 450f;

    [Tooltip("This checks below the center of the character for the ground")]
    public float GroundCheckDistance = 1f;

    Rigidbody2D RB2D;

    bool grounded;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        if (RB2D == null)
        {
            Debug.LogError("MISSING RIGID BODY!");
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Missing animation controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(
            transform.position,
            transform.position + Vector3.down * GroundCheckDistance,
            1<< LayerMask.NameToLayer("Ground") //bitshift, to ignore everthing but ground
            );

        if (grounded)
        {
            Debug.DrawLine(transform.position, transform.position +
                Vector3.down * GroundCheckDistance, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position +
      Vector3.down * GroundCheckDistance, Color.red);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            RB2D.AddForce(new Vector2(0, JumpForce));

        }

        anim.SetBool("Grounded", grounded);
    }
}
