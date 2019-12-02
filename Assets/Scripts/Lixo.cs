using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour {

	public GameObject controller;
	public GameObject pegaTarget;
	public bool pegaObj = false;
	public bool colidiuComLixo = false;

	void Start () {
		controller = GameObject.Find ("GameController");
		pegaTarget = GameObject.Find ("PegaTarget");
	}

	void Update () {
		if (pegaObj) transform.position = pegaTarget.transform.position;
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			colidiuComLixo = true;
			PegarSoltar ();
		} else {
			colidiuComLixo = false;
		}

		if (!pegaObj) {
			if (other.tag == "reciclavel" || other.tag == "naoReciclavel") {
				controller.GetComponent<GameController> ().
				EntregaLixo (this.tag, other.tag);
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			colidiuComLixo = true;
			PegarSoltar ();
		} else {
			colidiuComLixo = false;
		}
		if (!pegaObj) {
			if (other.tag == "reciclavel" || other.tag == "naoReciclavel") {
				controller.GetComponent<GameController> ().EntregaLixo (this.tag, other.tag);
				Destroy (this.gameObject);
			}
		}
	}

	void PegarSoltar () {
		if (Input.GetKeyDown (KeyCode.Mouse0) && !pegaObj) {
			if (colidiuComLixo) pegaObj = true;

		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) pegaObj = false;

	}
}