using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	float vida = 100;
	bool isAlive = true;

	void Start () {
		
	}
	
	void Update () {
		
		ChecarSeEstaVivo();
		Debug.Log("Esta Vivo: " + ChecarSeEstaVivo());
	}

	public bool ChecarSeEstaVivo () {

		// isAlive = (vida <= 0) ? false : true;
		// if (vida <= 0) isAlive = false;

		if (vida <= 0) {
			isAlive = false;
		} else {
			isAlive = true;
		}
		return isAlive;
	}
}
