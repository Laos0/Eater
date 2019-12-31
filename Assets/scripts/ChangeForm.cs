using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    public enum BodyType {SKINNY, NORMAL, FAT};
    public BodyType currBodyType = BodyType.SKINNY;

    public static int walkSpd;

    void Start(){
        currBodyType = BodyType.NORMAL;
        walkSpd = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // when player press space bar, change form
        if(Input.GetKey(KeyCode.Q) ){
            currBodyType = BodyType.SKINNY;
            skinnyForm();
        }else if(Input.GetKey(KeyCode.E)){
            currBodyType = BodyType.NORMAL;
            normalForm();
        }else if(Input.GetKey(KeyCode.R)){
            currBodyType = BodyType.FAT;
            fatForm();
        }
    }

    void skinnyForm(){
        if(currBodyType == BodyType.SKINNY){
            walkSpd = 3;

            // change the scale of the player
            this.gameObject.transform.localScale = new Vector3(.5f, 1.0f, .5f);
        }
    }

    void normalForm(){
        if(currBodyType == BodyType.NORMAL){
            walkSpd = 2;
             // change the scale of the player
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    void fatForm(){
        if(currBodyType == BodyType.FAT){
            walkSpd = 1;
             // change the scale of the player
            this.gameObject.transform.localScale = new Vector3(1.5f, 1.0f, 1.5f);
        }
    }
}
