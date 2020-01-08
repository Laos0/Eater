using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{

    public enum BodyType {SKINNY, NORMAL, FAT};
    public BodyType currBodyType = BodyType.SKINNY;

    public GameObject[] characterPrefabs;

    void Start(){
        currBodyType = BodyType.NORMAL;
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

            // change the scale of the player
            //this.gameObject.transform.localScale = new Vector3(.5f, 1.0f, .5f);
            characterPrefabs[0].SetActive(true);
            characterPrefabs[1].SetActive(false);
            characterPrefabs[2].SetActive(false);
        }
    }

    void normalForm(){
        if(currBodyType == BodyType.NORMAL){
             // change the scale of the player
            //this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            characterPrefabs[0].SetActive(false);
            characterPrefabs[1].SetActive(true);
            characterPrefabs[2].SetActive(false);
        }
    }

    void fatForm(){
        if(currBodyType == BodyType.FAT){
             // change the scale of the player
            //this.gameObject.transform.localScale = new Vector3(1.5f, 1.0f, 1.5f);
            characterPrefabs[0].SetActive(false);
            characterPrefabs[1].SetActive(false);
            characterPrefabs[2].SetActive(true);
        }
    }
}
