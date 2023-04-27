using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{

    public Text CoinText;

    public List<GameObject> Hearts;

    int currentLivesIndex = 2;

    // Update is called once per frame
    void Update()
    {
        int currLives = GameStateManager.Instance.GetLives();
        CoinText.text = GameStateManager.Instance.GetCoins().ToString("D3");

        if (currLives -1 != currentLivesIndex)
        {
            Hearts[currentLivesIndex].SetActive(false);
            if (currentLivesIndex > 0)
            {
                currentLivesIndex --;
            }
        }
    }
}
