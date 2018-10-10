using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {


    private Camera Principal;
    private GameObject Jogador;
    public float velcamm = 0.01f;

	// Use this for initialization
	void Start () {
        Principal = GetComponent<Camera>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
        if ((Jogador.transform.position.x < Principal.transform.position.x - 0.5) )
        {
            Vector3 PosJogador = new Vector3(Jogador.transform.position.x-0.5F, Principal.transform.position.y, Principal.transform.position.z);
            Principal.transform.position = Vector3.MoveTowards(Principal.transform.position, PosJogador, velcamm);
        }
        if ((Jogador.transform.position.x < Principal.transform.position.x - 0.5) || (Jogador.transform.position.x > Principal.transform.position.x + 0.5))
        {
            Vector3 PosJogador = new Vector3(Jogador.transform.position.x+0.5F, Principal.transform.position.y, Principal.transform.position.z);
            Principal.transform.position = Vector3.MoveTowards(Principal.transform.position, PosJogador, velcamm);
        }
        /*
        if ( (Jogador.transform.position.x > Principal.transform.position.x + 0.5))
        {
            Vector3 PosJogador = new Vector3(Jogador.transform.position.x, Principal.transform.position.y, Principal.transform.position.z);
            Principal.transform.position = Vector3.MoveTowards(Principal.transform.position, PosJogador, 0.03f);
        }*/
    }
}
