using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {


    public GameObject Gameover;
    public Text Score;
    public bool pause = false;
    private int pontos = 0;




    public void Pontuar(int ponto)
    {
        pontos = pontos + ponto;
        Score.text = "SCORE: " + pontos.ToString();
    }


	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        //pause = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Iniciar()
    {
        Time.timeScale = 1;
        pause = false;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Gameover.SetActive(true);
    }
}
