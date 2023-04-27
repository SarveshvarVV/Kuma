using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("Speed - in Unity units per second")]
    public float speed;
    public bool facingRight = true;

    [Tooltip("From our object, we check if we are on the ground!")]
    public float GroundCheckDistance = 1.1f;

    public float WallCheckDistance = 1.1f;

    public bool CheckWalls;
    public bool CheckGround;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckGround)
        {
            bool rightGround = Physics2D.Linecast(transform.position + Vector3.right * 0.5f,
                                                  transform.position + Vector3.right * 0.5f
                                                  + Vector3.down * GroundCheckDistance,
                                                  1 << LayerMask.NameToLayer("Ground"));

            bool leftGround = Physics2D.Linecast(transform.position + Vector3.left * 0.5f,
                                                  transform.position + Vector3.left * 0.5f
                                                  + Vector3.down * GroundCheckDistance,
                                                  1 << LayerMask.NameToLayer("Ground"));

            Debug.DrawLine(transform.position + Vector3.right * 0.5f,
                                                  transform.position + Vector3.right * 0.5f
                                                  + Vector3.down * GroundCheckDistance,
                                                  rightGround ? Color.green : Color.red);

            Debug.DrawLine(transform.position + Vector3.left * 0.5f,
                                                  transform.position + Vector3.left * 0.5f
                                                  + Vector3.down * GroundCheckDistance,
                                                  leftGround ? Color.green : Color.red);

            if (!(rightGround && leftGround))
            {
                facingRight = !facingRight;
            }

        }

        if (CheckWalls)
        {
            bool leftWall = Physics2D.Linecast(transform.position, transform.position +
                                               Vector3.left * WallCheckDistance,
                                               1 << LayerMask.NameToLayer("Ground"));

            bool rightWall = Physics2D.Linecast(transform.position, transform.position +
                                               Vector3.right * WallCheckDistance,
                                               1 << LayerMask.NameToLayer("Ground"));

            Debug.DrawLine(transform.position, transform.position +
                           Vector3.right * WallCheckDistance,
                           rightWall ? Color.green : Color.red);

            Debug.DrawLine(transform.position, transform.position +
                           Vector3.left * WallCheckDistance,
                           leftWall ? Color.green : Color.red);

            if (rightWall || leftWall)
            {
                facingRight = !facingRight;
            }



            if (facingRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProjectileController temp = collision.gameObject.GetComponent<ProjectileController>();
        
        if (temp != null)
        {
            //this would be a great spot for a particle effect.
            Destroy(this.gameObject);
        }
    }
}
