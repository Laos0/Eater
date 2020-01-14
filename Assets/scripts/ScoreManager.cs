using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public IntReference currentScore;
    public Text playerScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        currentScore.Variable.value = 0;
        playerScoreTxt.text = currentScore.ToString();
    }

	/// <summary>
	/// Adds incoming score onto the current score.
	/// </summary>
    public void add(int value){
		currentScore.Variable.value += value;
    }

}
