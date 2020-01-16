using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void startGame() {
		Application.LoadLevel(1);
	}
}
