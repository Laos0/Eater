using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 0){
            Destroy(this.gameObject);
        }
    }
}
