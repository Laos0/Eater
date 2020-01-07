using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form
{
    public int speed;
    
    public Form(int speed)
    {
        this.speed = speed;
    }

    public void changeSpeed(int speed)
    {
        this.speed = speed;
    }
}
