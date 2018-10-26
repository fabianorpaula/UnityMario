using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour {

    private float velocidade = 0.01f;
    private float altura = 0;
    private float altura_final;


	// Use this for initialization
	void Start () {
        velocidade = Random.Range(0.01f, 0.001f);
        altura = Random.Range(0, 1f);
	}
	// Update is called once per frame
	void Update () {
        //Só permite que as nuvens se movam se o jogo estiver acontecendo
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>().pause == false)
        {
            transform.position = new Vector3(transform.position.x - velocidade, altura, transform.position.z);

            if (transform.position.x < -5)
            {
                velocidade = Random.Range(0.01f, 0.001f);
                altura = Random.Range(0, 1);
                transform.position = new Vector3(40, transform.position.y, transform.position.z);
                
            }
        }
	}
}
