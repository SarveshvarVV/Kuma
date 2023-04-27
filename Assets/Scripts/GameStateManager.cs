using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [Tooltip("Current coin count")]
    [SerializeField]
    int Coins;

    [Tooltip("current life total")]
    [SerializeField]
    int Lives;

    [SerializeField]
    private string DefaultScene;

    public string GameOverScene = "GameOverScene";

    private static GameStateManager instance;

    

    public static GameStateManager Instance
    {
        get { return instance; }
    }

    public int GetCoins()
    {
        return Coins;   
    }

    public int GetLives()

    {
        return Lives;   
    }



    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    /// <summary>
    /// when the player collects coins, we update the urrent total
    /// </summary>
    /// <param name="deltaCoins"></param>

    public void changeCoins(int deltaCoins)
    {
        Coins += deltaCoins;
    }

   public void changeLives(int deltaLives)
    {
        Lives += deltaLives;
    }

    public void onDeath()
    {
        changeLives(-1);
        
        if (Lives < 0)
        {
            Debug.Log("No More Lives!");
            Coins = 0;
            Lives = 3;
            SceneManager.LoadScene(GameOverScene);
        }
    }

    internal void onGoal(string nextLevel)
    {
        if(nextLevel == "Default")
        {
            SceneManager.LoadScene(DefaultScene);
        }
        else
        {
            SceneManager.LoadScene(nextLevel);  
        }
        
    }
}
