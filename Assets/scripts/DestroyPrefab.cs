using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{

    private bool isEaten = false;

    // Destroys this game object has it reaches below 0 on y-axis
    void Update()
    {
        destroyObject();
    }

    void destroyObject(){

        // two condition: the food is ither eaten or not
        if(isEaten){
            Destroy(this.gameObject);
        }
        else if(this.gameObject.transform.position.y <= .89f){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "floor")
        {
            Destroy(this.gameObject);
        }
    }
}
