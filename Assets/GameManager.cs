using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float gameVelocity;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if(gameVelocity < 10)
        {
            gameVelocity += Time.deltaTime / 2;
            VelocityManager.ChangeVelocity(gameVelocity);
        }
	}
}
