using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGameObject : MonoBehaviour
{
    public FloatReference hp;
    public FloatReference hpMax;
    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position.Set(hp.Value, 0, 0);
        //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * hp.Value);
        transform.position = new Vector3(hp.Value, 0, 0);

        // hp bar reaction test
        hpBar.fillAmount = Mathf.Clamp01(hp.Value / hpMax.Value);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            resetPosition();
        }

    }

    private void resetPosition()
    {
        gameObject.GetComponent<Rigidbody>().velocity.Set(0, 0, 0);
        gameObject.transform.position = new Vector3();
    }
}
