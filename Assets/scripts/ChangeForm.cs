using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{

    public enum BodyType {SKINNY, NORMAL, FAT};
    public BodyType currBodyType = BodyType.SKINNY;
    public bool canChange;
    public int changeFormCoolDown;
    public GameObject gameManager;

    public GameObject[] characterPrefabs;

    void Start(){
        currBodyType = BodyType.SKINNY;
        canChange = true;
        changeFormCoolDown = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // when player press space bar, change form
        if(Input.GetKey(KeyCode.Q) && canChange){

            currBodyType = BodyType.SKINNY;
            skinnyForm();
            gameManager.GetComponent<TheGameManager>().decrementChangeFormSlider();
            canChange = false;

        }else if(Input.GetKey(KeyCode.E) && canChange){

            currBodyType = BodyType.NORMAL;
            normalForm();
            gameManager.GetComponent<TheGameManager>().decrementChangeFormSlider();
            canChange = false;

        }
        else if(Input.GetKey(KeyCode.R) && canChange){

            currBodyType = BodyType.FAT;
            fatForm();
            gameManager.GetComponent<TheGameManager>().decrementChangeFormSlider();
            canChange = false;
        }

        // to see if the progress bar is fill up so we can change form again
        if (gameManager.GetComponent<TheGameManager>().changeFormSlider.value == 1.0f)
        {
            canChange = true;
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
            characterPrefabs[1].SetActive(false);
            characterPrefabs[2].SetActive(true);
        }
    }

    void fatForm(){
        if(currBodyType == BodyType.FAT){
             // change the scale of the player
            //this.gameObject.transform.localScale = new Vector3(1.5f, 1.0f, 1.5f);
            characterPrefabs[0].SetActive(false);
            characterPrefabs[1].SetActive(true);
            characterPrefabs[2].SetActive(false);
        }
    }
}
