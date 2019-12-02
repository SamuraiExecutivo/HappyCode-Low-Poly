using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float h, v;
	Animator animator;
	public float divisorDeForca;
	private GameObject gc;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		gc = GameObject.Find ("GameController");
	}

	void Update () {
		AddForce ();
		Animator ();

		if (gc.GetComponent<GameController> ().vidaJogador <= 0) {
			animator.SetInteger("estado", 3);
		}
	}

	public void Animator () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		if (v > 0 && gc.GetComponent<GameController> ().vidaJogador > 0) {
			animator.SetInteger ("estado", 1);
		} else if (v <= 0 && gc.GetComponent<GameController> ().vidaJogador > 0) {
			animator.SetInteger ("estado", 0);
		}
	}

	public void AddForce () {
		h = Input.GetAxis ("Horizontal") * 2;
		v = Input.GetAxis ("Vertical");

		if (v > 0) {
			transform.Translate (new Vector3 (0, 0, v / divisorDeForca));
		}

		if (h > 0) {
			transform.Rotate (0, h, 0);
		}
		if (h < 0) {
			transform.Rotate (0, h, 0);
		}
	}
}