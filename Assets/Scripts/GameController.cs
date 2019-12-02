using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int score;
    public string scoreTxt;
    public float timer;
    public string timerTxt;

    public Slider sliderVida;
    public float vidaJogador;

    void Start () {
        timer = 15;
        vidaJogador = 10;
    }

    private void Update () {
        timer -= 1 * Time.deltaTime;
        scoreTxt = score.ToString ();
        timerTxt = timer.ToString ("###,##");
        print (timerTxt);

    }

    public void EntregaLixo (string item, string cont) {

        if ((item == "reciclavel" && cont == "lixeiraReciclavel") || (item == "naoReciclavel" && cont == "LixeiraNaoReciclavel"))
            score += 10;
        else {
            score -= 5;
        }
    }
}