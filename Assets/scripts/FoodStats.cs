using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStats : MonoBehaviour
{

    public enum FoodType {FRUITS, MEAT, ENGERY};

    public FoodType foodType;

    void Update()
    {
        if(gameObject.tag == "fruit"){
            foodType = FoodType.FRUITS;
        }else if(gameObject.tag == "meat"){
            foodType = FoodType.MEAT;
        }else if(gameObject.tag == "energy"){
            foodType = FoodType.ENGERY;
        }
    }
}
