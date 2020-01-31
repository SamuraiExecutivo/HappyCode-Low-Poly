using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public Slider sliderVida;
	public float vidaJogador;
	GameObject canvas;
	private bool  isPaused;
	public bool win, loose;

	public int comida;
	public int agua;

	int aguacoletada;
	int comidaColetada;

	public Text comidaTxt;
	public Text aguaTxt;

	public Text comidaColetTxt;
	public Text aguaColetTxt;

	public Button continuar;
	public Button voltarAoMenu;
	public Text pauseText; 


	public void DesabilitarUIVitoriaDerrota () {
		canvas = GameObject.Find("Canvas");
		// Lose
		canvas.transform.GetChild(1).gameObject.SetActive(false);
		canvas.transform.GetChild(2).gameObject.SetActive(false);
		canvas.transform.GetChild(4).gameObject.SetActive(false);
		// Win
		canvas.transform.GetChild(2).gameObject.SetActive(false);
		canvas.transform.GetChild(5).gameObject.SetActive(false);
	}

	public void HabilitarUIVitoriaDerrota (bool win, bool lose) {
		if (win) {
			lose = false;
		} else if (lose) {
			win = false;
		}
		canvas = GameObject.Find("Canvas");
		// Lose
		canvas.transform.GetChild(1).gameObject.SetActive(lose);
		canvas.transform.GetChild(2).gameObject.SetActive(lose);
		canvas.transform.GetChild(4).gameObject.SetActive(lose);
		// Win
		canvas.transform.GetChild(2).gameObject.SetActive(win);
		canvas.transform.GetChild(5).gameObject.SetActive(win);
	}

	public void LooseGame () {
		if (vidaJogador <= 0) {
			StartCoroutine (PauseGameLoose());
		}
	}

	public void WinGame () {
		if (comida >= 20) {
			HabilitarUIVitoriaDerrota (true, false);
			Time.timeScale = 0;
		}
	}

	public void GamePause () {
		if (!isPaused) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				isPaused = true;
				continuar.gameObject.SetActive(true);
				voltarAoMenu.gameObject.SetActive(true);
				pauseText.enabled = true;
				Time.timeScale = 0;
			}
		}
	}

	IEnumerator PauseGameLoose () {
		Debug.Log("gameOver");
		yield return new WaitForSeconds(1.5f);
		HabilitarUIVitoriaDerrota (false, true);
		Time.timeScale = 0;
	}

	IEnumerator ColetaComidaWarning () {
		comidaColetTxt.enabled = true;
		yield return new WaitForSeconds(3.0f);
		comidaColetTxt.enabled = false;
	}
	IEnumerator ColetaAguaWarning () {
		aguaColetTxt.enabled = true;
		yield return new WaitForSeconds(3.0f);
		aguaColetTxt.enabled = false;
	}

	public void ColetarComida () {
		comida++;
		StartCoroutine(ColetaComidaWarning());
	}
	public void ColetarAgua () {
		agua++;
		StartCoroutine(ColetaAguaWarning());
	}

	public void ZerarComida () {
		comida = 0;
	}

	void Awake () {
		DesabilitarUIVitoriaDerrota ();
		canvas = GameObject.Find ("Canvas");

		comidaColetTxt.enabled = false;
		isPaused = false;
		continuar.gameObject.SetActive(false);
		pauseText.enabled = false;
	}
	
	void Start () {
		vidaJogador = 100;
		comidaTxt.text = "0/10";
		aguaTxt.text = "0/10";
	}

	void Update () {
		LooseGame ();
		WinGame ();
		sliderVida.value = vidaJogador;
		GamePause ();
	}
}
