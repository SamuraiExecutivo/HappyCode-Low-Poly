using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public Slider sliderVida;
    public float vidaJogador;
    GameObject canvas;
    private bool isPaused;
    public bool win, loose;

    public int reciclavel;
    public int naoReciclavel;

    int naoRecColetada;
    int recColetada;

    public Text reciclavelTxt;
    public Text notRecTxt;

    public Text recColetTxt;
    public Text notRecColetTxt;

    public Button continuar;
    public Button voltarAoMenu;
    public Text pauseText;

    public void DesabilitarUIVitoriaDerrota () {
        canvas = GameObject.Find ("Canvas");
        // Lose
        canvas.transform.GetChild (1).gameObject.SetActive (false);
        canvas.transform.GetChild (2).gameObject.SetActive (false);
        canvas.transform.GetChild (4).gameObject.SetActive (false);
        // Win
        canvas.transform.GetChild (2).gameObject.SetActive (false);
        canvas.transform.GetChild (5).gameObject.SetActive (false);
    }

    public void HabilitarUIVitoriaDerrota (bool win, bool lose) {
        if (win) {
            lose = false;
        } else if (lose) {
            win = false;
        }
        canvas = GameObject.Find ("Canvas");
        // Lose
        canvas.transform.GetChild (1).gameObject.SetActive (lose);
        canvas.transform.GetChild (2).gameObject.SetActive (lose);
        canvas.transform.GetChild (4).gameObject.SetActive (lose);
        // Win
        canvas.transform.GetChild (2).gameObject.SetActive (win);
        canvas.transform.GetChild (5).gameObject.SetActive (win);
    }

    public void LooseGame () {
        if (vidaJogador <= 0) {
            StartCoroutine (PauseGameLoose ());
        }
    }

    public void WinGame () {
        if (reciclavel >= 20) {
            HabilitarUIVitoriaDerrota (true, false);
            Time.timeScale = 0;
        }
    }

    public void GamePause () {
        if (!isPaused) {
            if (Input.GetKeyDown (KeyCode.Escape)) {
                isPaused = true;
                continuar.gameObject.SetActive (true);
                voltarAoMenu.gameObject.SetActive (true);
                pauseText.enabled = true;
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator PauseGameLoose () {
        Debug.Log ("gameOver");
        yield return new WaitForSeconds (1.5f);
        HabilitarUIVitoriaDerrota (false, true);
        Time.timeScale = 0;
    }

    IEnumerator ColetaComidaWarning () {
        recColetTxt.enabled = true;
        yield return new WaitForSeconds (3.0f);
        recColetTxt.enabled = false;
    }
    IEnumerator ColetaAguaWarning () {
        notRecColetTxt.enabled = true;
        yield return new WaitForSeconds (3.0f);
        notRecColetTxt.enabled = false;
    }

    public void ColetarComida () {
        reciclavel++;
        StartCoroutine (ColetaComidaWarning ());
    }
    public void ColetarAgua () {
        naoReciclavel++;
        StartCoroutine (ColetaAguaWarning ());
    }

    public void ZerarComida () {
        reciclavel = 0;
    }

    void Awake () {
        DesabilitarUIVitoriaDerrota ();
        canvas = GameObject.Find ("Canvas");

        recColetTxt.enabled = false;
        isPaused = false;
        continuar.gameObject.SetActive (false);
        voltarAoMenu.gameObject.SetActive (false);
        pauseText.enabled = false;
    }

    void Start () {
        vidaJogador = 100;
        reciclavelTxt.text = "0/10";
        notRecTxt.text = "0/10";
    }

    void Update () {
        LooseGame ();
        WinGame ();
        sliderVida.value = vidaJogador;
        GamePause ();
    }
}