using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour {

	public GameObject controller;
	public GameObject pegaTarget;
	public bool pegaObj = false;

	void Start () {
		controller = GameObject.Find ("GameController");
	}

	void Update () {
		if (pegaObj) transform.position = pegaTarget.transform.position;
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			PegarSoltar ();
		} else {
		}

		if (!pegaObj) {
			if (other.tag == "LixeiraReciclavel" || other.tag == "LixeiraNaoReciclavel") {
				controller.GetComponent<GameController> ().EntregaLixo (this.tag, other.tag);
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			PegarSoltar ();
		} else {
		}
		if (!pegaObj) {
			if (other.tag == "LixeiraReciclavel" || other.tag == "LixeiraNaoReciclavel") {
				controller.GetComponent<GameController> ().EntregaLixo (this.tag, other.tag);
				Destroy (this.gameObject);
			}
		}
	}

bool PegarSoltar () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			pegaObj = true;
			return false;
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			pegaObj = false;
			return true;
		}
		return false;
	}
}