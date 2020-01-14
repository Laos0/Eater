using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour
{

    int comboCount;
    Text comboCountTxt;

    // Start is called before the first frame update
    void Start()
    {
        comboCount = 0;
        comboCountTxt.text = comboCount.ToString();
    }

    void increaseComboCount() {

        comboCount++;
        comboCountTxt.text = comboCount.ToString();
    }
}
