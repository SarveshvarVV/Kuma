using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Tooltip("How much this collectible is worth!")]
    public int CoinValue;

    public GameObject particlePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            GameStateManager.Instance.changeCoins(CoinValue);
            Destroy(this.gameObject);
            
            if(particlePrefab != null)
            {
                GameObject temp = Instantiate(particlePrefab);

                temp.transform.SetPositionAndRotation(transform.position,
                                                      Quaternion.identity); 
            }
        }
    }

}    
