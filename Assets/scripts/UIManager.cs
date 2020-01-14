using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Text scoreTxt;
	public Text levelTxt;
	public Text nextLevelAlertTxt;
	public Text levelObjectScoreTxt;

	public IntReference currentLevel;
	public IntReference currentLevelScore;
	public IntReference overallTotalScore;
	public IntReference currentLevelScoreObjective;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
		if(levelTxt && currentLevel != null) {
			levelTxt.text = currentLevel.Value.ToString();
		}
		if (scoreTxt && currentLevelScore != null) {
			scoreTxt.text = currentLevelScore.Value.ToString();
		}
		if (levelObjectScoreTxt && currentLevelScoreObjective != null) {
			levelObjectScoreTxt.text = currentLevelScoreObjective.Value.ToString();
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
