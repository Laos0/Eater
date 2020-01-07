using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;

    // the forms the players can be which will affect the player's movement
    public Form currentForm = null;
    public Form skinnyForm = new Form(10);
    public Form normalForm = new Form(5);
    public Form fatForm = new Form(0);

    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        // checking which form speed to use
        updateForm();

        if (canMove)
        {
            // as the player press Q, E, or R, the walk speed fof the player changes
            speed = currentForm.speed;
            moveCharacterLeft();
            moveCharacterRight();
        }
        
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

    void updateForm()
    {
        if(this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.SKINNY)
        {
            currentForm = skinnyForm;
        }else if(this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.NORMAL)
        {
            currentForm = normalForm;
        }else if(this.gameObject.GetComponent<ChangeForm>().currBodyType == ChangeForm.BodyType.FAT)
        {
            currentForm = fatForm;
        }
    }

}
