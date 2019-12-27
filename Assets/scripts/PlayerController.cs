using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self); //LEFT
        }

        if (Input.GetKey (KeyCode.D)) {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self); //RIGHT
        }
    }
}
