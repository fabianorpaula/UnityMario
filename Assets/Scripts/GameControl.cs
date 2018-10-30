using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {


    public GameObject Gameover;
    
    public bool pause = false;
    private int pontos = 0;
    private int vidas = 3;
    public Text Score;
    public Text Life;


    
    public void Pontuar(int ponto)
    {
        pontos = pontos + ponto;
        PlayerPrefs.SetInt("moedas", pontos);
        Score.text = "SCORE: " + pontos.ToString();
    }


	// Use this for initialization
	void Start () {

        vidas = PlayerPrefs.GetInt("vidas");

        if (vidas > 0)
        {
            pontos = PlayerPrefs.GetInt("moedas");
            Score.text = "SCORE: " + pontos.ToString();

            if (PlayerPrefs.GetString("checkpoint") == "checkpoint1")
            {
                Debug.Log("checkpoint1");
                GameObject Mario = GameObject.FindGameObjectWithTag("Player");
                GameObject Chekp = GameObject.FindGameObjectWithTag("checkpoint1");
                Mario.transform.position = Chekp.transform.position;
            }
        }else
        {
            vidas = 3;
            PlayerPrefs.SetInt("vidas", 3);
            PlayerPrefs.SetString("checkpoint", "não");
            PlayerPrefs.SetInt("moedas", 0);

        }

        Life.text = vidas.ToString();
        Time.timeScale = 1;
        pause = true;
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
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        vidas -= 1;
        PlayerPrefs.SetInt("vidas",vidas);
        Time.timeScale = 0;
        Gameover.SetActive(true);
    }

    public void NovaFase()
    {
        SceneManager.LoadScene(0);
    }

    public void Salvar()
    {
        
    }

}
