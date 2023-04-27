using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LeftRightController : MonoBehaviour
{

    [Tooltip("Max speed a character can move!")]
    public float Speed = 5f;

    //This is a reference to our Animation Controller
    Animator anim;

    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            Debug.LogError("Missing animation controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the input from the Horizontal Axis, raw means no interpolation
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * h * Speed * Time.deltaTime);


        anim.SetFloat("Speed", Mathf.Abs(h));

        if(h < 0 && !facingRight)
        {
            Flip();
        }
        else if (h > 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        //BONUS
        //GetComponent<SpriteRenderer>().flipX = facingRight;

    }
}
