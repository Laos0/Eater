using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
	/*
    public GameObject gameManager;

    void OnCollisionEnter(Collision col){

        if (col.gameObject.CompareTag("fruit"))
        {
            eatFruit(col);
        }else if (col.gameObject.CompareTag("meat"))
        {
            eatMeat(col);
        }else if (col.gameObject.CompareTag("energy"))
        {
            eatEnergy(col);
        }


    }

    void eatFruit(Collision col)
    {
        if (this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.NORMAL)
        {
            Debug.Log("can move, gained 1 coin.");
            gameManager.GetComponent<TheGameManager>().increasePlayerScore();
            // also increase the progress bar by a little
            Debug.Log("THE CURRENT PROGRESS BAR VALUE: " + gameManager.GetComponent<TheGameManager>().changeFormSlider.value);
            gameManager.GetComponent<TheGameManager>().changeFormSlider.value += .2f;
            Debug.Log("THE CURRENT PROGRESS BAR VALUE AFTER ADDING .2f to it: " + gameManager.GetComponent<TheGameManager>().changeFormSlider.value);

        }
        else if (col.gameObject.name == "floor")
        {
            // the first thing the player comes in contact is the floor, so we have to make sure to state that logic here
            // nothign should happen
            Debug.Log("this is a floor.");
        }
        else // if the player eat anything else besides a fruit in normal form, it'll get stun
        {
            Debug.Log("STUNNED");
            //this.gameObject.GetComponent<PlayerController>().canMove = false;
            StartCoroutine(StunPlayer());
            
        }
    }

    void eatEnergy(Collision col)
    {
        if (this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.SKINNY)
        {
            Debug.Log("can move, gained 1 coin.");
            gameManager.GetComponent<TheGameManager>().increasePlayerScore();
            // also increase the progress bar by a little
            Debug.Log("THE CURRENT PROGRESS BAR VALUE: " + gameManager.GetComponent<TheGameManager>().changeFormSlider.value);
            gameManager.GetComponent<TheGameManager>().changeFormSlider.value += .2f;
            Debug.Log("THE CURRENT PROGRESS BAR VALUE AFTER ADDING .2f to it: " + gameManager.GetComponent<TheGameManager>().changeFormSlider.value);
        }
        else if (col.gameObject.name == "floor")
        {
            // the first thing the player comes in contact is the floor, so we have to make sure to state that logic here
            // nothign should happen
            Debug.Log("this is a floor.");
        }
        else // if the player eat anything else besides a fruit in skinny form, it'll get stun
        {
            Debug.Log("STUNNED");
            //this.gameObject.GetComponent<PlayerController>().canMove = false;
            StartCoroutine(StunPlayer());

        }
    }

    void eatMeat(Collision col)
    {
        if (this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.FAT)
        {
            Debug.Log("can move, gained 1 coin.");
            gameManager.GetComponent<TheGameManager>().increasePlayerScore();
            // also increase the progress bar by a little
            Debug.Log("THE CURRENT PROGRESS BAR VALUE: " + gameManager.GetComponent<TheGameManager>().changeFormSlider.value);
            gameManager.GetComponent<TheGameManager>().changeFormSlider.value += .2f;
            Debug.Log("THE CURRENT PROGRESS BAR VALUE AFTER ADDING .2f to it: " + gameManager.GetComponent<TheGameManager>().changeFormSlider.value);
        }
        else if (col.gameObject.name == "floor")
        {
            // the first thing the player comes in contact is the floor, so we have to make sure to state that logic here
            // nothign should happen
            Debug.Log("this is a floor.");
        }
        else // if the player eat anything else besides a meat in fat form, it'll get stun
        {
            Debug.Log("STUNNED");
            //this.gameObject.GetComponent<PlayerController>().canMove = false;
            StartCoroutine(StunPlayer());

        }
    }

    public IEnumerator StunPlayer()
    {
        this.gameObject.GetComponent<PlayerController>().canMove = false;
        this.gameObject.GetComponent<ChangeForm>().canChange = false; // stop the player from changing form when stunned


        if (this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.SKINNY)
        {
            yield return new WaitForSeconds(3f); // stops player's movement for 3 seconds
        }else if(this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.NORMAL)
        {
            yield return new WaitForSeconds(2f);
        }else if(this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.FAT)
        {
            yield return new WaitForSeconds(1f);
        }

        this.gameObject.GetComponent<PlayerController>().canMove = true; // Let the player move again after 3 seconds
        this.gameObject.GetComponent<ChangeForm>().canChange = true; // let the player change form after being stunned
    }
    */
}
