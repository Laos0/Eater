using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        // as the player press Q, E, or R, the walk speed fof the player changes
        speed = ChangeForm.walkSpd;
        
        moveCharacterLeft();
        moveCharacterRight();
    }

    void moveCharacterLeft(){
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self); //LEFT
        }
    }

    void moveCharacterRight(){
        if (Input.GetKey (KeyCode.D)) {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self); //RIGHT
        }
    }
}
