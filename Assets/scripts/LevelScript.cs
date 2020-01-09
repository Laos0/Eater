using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{

    int currentLvl;
    int itemCount;
    public Text lvlTxt;
    // Start is called before the first frame update
    void Start()
    {
        currentLvl = 0;
        itemCount = 0;
        lvlTxt.text = currentLvl.ToString();

    }

    public void incrementItemCount()
    {
        itemCount++;
    }

    public void updateCurrentLvl()
    {
        currentLvl++;
        lvlTxt.text = currentLvl.ToString();
    }

    public int getCurrentLvl()
    {
        return currentLvl;
    }

    public int getCurrentItemCount()
    {
        return itemCount;
    }
}
