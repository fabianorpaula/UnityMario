using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {

    Rigidbody2D Corpo;
    SpriteRenderer Imagem;
    float velocidade = 0.1f;

	// Use this for initialization
	void Start () {
        Corpo = GetComponent<Rigidbody2D>();
        Imagem = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        Corpo.velocity = new Vector2(velocidade * 2, 0);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Inimigo")
        {
            velocidade = velocidade * -1;
            if (velocidade > 0)
            {
                Imagem.flipX = false;
            }
            else
            {
                Imagem.flipX = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ColisorInimigo")
        {
            velocidade = velocidade * -1;
            if (velocidade > 0)
            {
                Imagem.flipX = false;
            }
            else
            {
                Imagem.flipX = true;
            }
        }
        

    }

}
