using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This Script controls our projectile, it allows the projectile
/// to fly for a certain amount of time, then deletes it. 
/// It also set up to delete itself when it collides with an object
/// </summary>
public class ProjectileController : MonoBehaviour
{
    [Tooltip("rate of change of position in Unity Units/second")]
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
        
    }

    public void SetDirection(float direction)
    {
        direction = Mathf.Sign(direction);

        Speed *= direction; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This would be a good spot to create a particle effect!
        Destroy(this.gameObject);
        
    }
}
