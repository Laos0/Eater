using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    int itemCount;
    public Text lvlTxt;

	/// <summary>
	/// The main level value. This is a scriptable instance of Int for sharability across different classes.
	/// </summary>
	public IntReference currentLevel;

    // Start is called before the first frame update

    void Start()
    {
		currentLevel.Variable.value = 10;
        itemCount = 0;
        lvlTxt.text = currentLevel.Value.ToString();

    }

    public void incrementItemCount()
    {
        itemCount++;
    }

	/// <summary>
	/// Goes to the next level upon calling
	/// </summary>
	public void nextLevel() {
		if (currentLevel != null) {
			currentLevel.Variable.value++;
		} else {
			Debug.LogError("Failed to increment to next level, currentLevel is null");
		}
	}

	public void updateCurrentLvl()
    {
		currentLevel.ConstantValue++;
        lvlTxt.text = currentLevel.Value.ToString();
    }

    public int getCurrentLvl()
    {
        return currentLevel.Value;
    }

    public int getCurrentItemCount()
    {
        return itemCount;
    }
}
