using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public int playerScore;
    public Text playerScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerScoreTxt.text = playerScore.ToString();
    }

    public void increasePlayerScore()
    {
        playerScore++;
        playerScoreTxt.text = playerScore.ToString();
    }

}
