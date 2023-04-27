using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("This is a referance to our projectile prefab")]
    public ProjectileController projectilePrefab;

    //this is our initial spawn location, we save this as a position to respawn from.
    public Vector3 StartPosition;

    //a reference to our players's physics Rigidbody
    Rigidbody2D RB2D;

    [Tooltip("Elapsed time between shots")]
    public float RateOfFire = 1;

    private float fireCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;

        RB2D = GetComponent<Rigidbody2D>(); 

        if (RB2D == null)
        {
            Debug.LogError("No RIGID BODY!!!!");
        }
        
    }
    private void Update()
    {
        fireCooldown += Time.deltaTime;

        if (Input.GetButton("Fire1") && fireCooldown > RateOfFire)
        {
            //Create a new projectilecontroller reference called 'temp'
            //assign to the variable to a new instance of our prefab.
            ProjectileController temp = Instantiate(projectilePrefab);

            temp.transform.SetPositionAndRotation(transform.position + Vector3.right * 0.4f *
                                              Mathf.Sign(transform.localScale.x), Quaternion.identity);

            temp.transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), temp.transform.localScale.y, temp.transform.localScale.z);

            temp.SetDirection(transform.localScale.x);

            fireCooldown = 0;
        }
    }

    public void OnReset()
    {
        Debug.Log("Resetting the player");


        // move our player back to the initial spawn location
        transform.SetPositionAndRotation(StartPosition, Quaternion.identity);

        //reset our velocity
        RB2D.velocity = Vector3.zero;

    }

    public void OnDeath()
    {
        OnReset();
        GameStateManager.Instance.onDeath();
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 20), "Reset Player"))
        {
            OnReset();
        }
        
    }
}
