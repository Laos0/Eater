using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFromProgressBar : MonoBehaviour
{

    private Slider slider;
    public float fillSpd = 1f;
    private float targetProgress = 0;
    public bool didChangeForm = false;

    public void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        didChangeForm = false;
        targetProgress = 0;
        //decrementProgressBar(1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        // decrease the progress bar until it reaches 0
        if (didChangeForm)
        {
            if(slider.value != 0.0f)
            {
                decrementProgressBar(1f);
            }
            else if(slider.value == 0)
            {
                didChangeForm = false;
            }
            
        }

        // increase progress bar until it reaches 1
        if(!didChangeForm)
        {
            if (slider.value < 1.0f)
            {
                incrementProgressBar(1f);
            }
            else if (slider.value == 1.0f)
            {
                didChangeForm = false;
            }
        }

    }

    public void incrementProgressBar(float newProgress)
    {
        targetProgress = slider.value + newProgress;

        if (slider.value < targetProgress)
        {
            slider.value += fillSpd * Time.deltaTime;
        }
    }

    public void decrementProgressBar(float newProgress)
    {
        targetProgress = slider.value - newProgress;

        if (slider.value > targetProgress)
        {
            slider.value -= fillSpd * Time.deltaTime;
        }
    }

    public void setDidChangeForm(bool didChange)
    {
        didChangeForm = didChange;
    }

}
