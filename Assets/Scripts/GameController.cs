using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int score;
    public float timer;

    private string timerTxt, scoreTxt;
    private float x, y;

    public Slider sliderVida;
    public float vidaJogador;

   
    void Start () {
        timer = 60;
        vidaJogador = 10;
    }

    private void Update () {
        timer -= 1 * Time.deltaTime;
        scoreTxt = "Score: " + score.ToString ();
        timerTxt = "Tempo: " + timer.ToString ("###,##");

        x = Screen.width;
        y = Screen.height;

        if (score >= 100 && timer >= 0) GameWin ();
        if (timer <= 0) GameOver ();

    }

    public void GameWin () {
        Time.timeScale = 0;
        if (Input.GetKeyDown (KeyCode.Escape)) SceneManager.LoadScene ("Game");
    }

    public void GameOver () {
        Time.timeScale = 0;
        if (Input.GetKeyDown (KeyCode.Escape)) SceneManager.LoadScene ("Game");
    }

    public void EntregaLixo (string item, string cont) {

        if ((item == "LixoReciclavel" && cont == "LixeiraReciclavel") ||
            (item == "LixoNaoReciclavel" && cont == "LixeiraNaoReciclavel"))
            score += 10;
        else {
            score -= 5;
        }
    }

    void OnGUI () {
        GUI.Box (new Rect (2 * x / 5, 0, x / 5, y / 10), timerTxt);
        GUI.Box (new Rect (2 * x / 5, y / 10, x / 5, y / 10), scoreTxt);
    }
}