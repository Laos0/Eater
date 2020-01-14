using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Text scoreTxt;
	public Text levelTxt;
	public Text nextLevelAlertTxt;

	public IntReference currentLevel;
	public IntReference overallTotalScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
		if (scoreTxt != null && scoreTxt) {
			scoreTxt.text = overallTotalScore.Value.ToString();
		}
		if(currentLevel != null && levelTxt) {
			levelTxt.text = currentLevel.Value.ToString();
		}
	}

	public void displayNextLevelLabel() {
		if (nextLevelAlertTxt) {
			nextLevelAlertTxt.enabled = true;
		}
	}

	public void hideNextLevelLabel() {
		if (nextLevelAlertTxt) {
			nextLevelAlertTxt.enabled = false;
		}
	}
}
