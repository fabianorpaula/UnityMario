using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {


    //Variavel De Fisica
    private Rigidbody2D Corpo;
    private Animator Animar;
    private SpriteRenderer Spritemario;
    private float velocidade=0;
    public float acel = -1;
    public float forcapulo=0;
    private bool nochao = false;

    public GameObject Casco;
	
	void Start () {
        //Recebe o componete de Fisica
        Corpo = GetComponent<Rigidbody2D>();
        Animar = GetComponent<Animator>();
        Spritemario = GetComponent<SpriteRenderer>();
    
	}
	
	
	void Update () {
        //Chama a função de andar
        Andar();
        Pular();
        Chao();

    }
    void Pular()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if (nochao == false)
            {
                
                forcapulo = 9;
                nochao = true;
               
                Animar.SetBool("Pulo", true);
               
            }
        }
        if(nochao == true )
        {
            if (forcapulo < 0)
            {
                forcapulo = forcapulo + (acel / 2);
                
                
            }
            else
            {
                forcapulo = forcapulo + acel;

            }
        }
    }
    //Função de Andar
    void Andar()
    {


        velocidade = Input.GetAxis("Horizontal");
        Corpo.velocity = new Vector2(velocidade * 4, forcapulo);

        if (velocidade != 0)
        {
            Animar.SetFloat("Mover", 2);
            if(velocidade > 0)
            {
                Spritemario.flipX = false;
            }else
            {
                Spritemario.flipX = true;
            }
        }else
        {
            Animar.SetFloat("Mover", 0);
        }

        
        

    }






    void Chao()
    {

        int layerMask = 1 << 12; // Layers utilizadas
        ///O Ponto de Saida
        float rodax = -0.08f; //essa variavel ajuda a rodar os pontos do pé
        float px = 0; //ponto de origem X
        float py = this.transform.position.y - 0.2f; // ponto de origem Y

        while (rodax < 0.081f)
        {
            //lança raios no chão
            RaycastHit2D hit = new RaycastHit2D();
            //vai mudando a posição
            px = this.transform.position.x + rodax;
            //receber colisão
            //recebe colisão - ponto inicial - direcção - distancia - camada
            hit = Physics2D.Raycast(new Vector2(px + rodax, py), Vector3.down, 0.17f, layerMask);
            Debug.DrawLine(new Vector3(px + rodax, py, 0), new Vector3(px + rodax, py - 0.17f, 0), Color.red);
            //incrementa
            rodax = rodax + 0.01f;
            //Retorna se encontrou algo
            if (hit == true)
            {
                if(hit.collider.tag == "Inimigo")
                {
                    //Criar antes Public GameObject Casco no inicio do Codigo
                    //Cria um Casco no Momento da morte do inimigo
                    Instantiate(Casco, hit.collider.gameObject.transform.position, Quaternion.identity);
                    //Destroi o Inimigo
                    Destroy(hit.collider.gameObject);
                    //Adicionar uma força de pulo
                    forcapulo = 1;
                }
                if (hit.collider.tag == "Chao")
                {
                    
                   
                    
                    nochao = false;
                    //Animar.SetBool("Pulo", false);
                    
                }
                if (hit.collider.tag == "Casco")
                {
                    

                    nochao = false;
                    
                }
                //sai do loop se já tiver encontrado o chão
                break;
            }
            else
            {
                Debug.Log("voando");
                nochao = true;
                Animar.SetBool("Pulo", false);
                //enautno não encontra chão fica como false
                //nochao = false;
            }
        }
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            if (nochao == true)
            {
                nochao = false;
                forcapulo = 0;
            }
        }

        if (col.gameObject.tag == "Inimigo")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>().GameOver();
            

        }
        if (col.gameObject.tag == "Moeda")
        {

            Destroy(col.gameObject);
           // Debug.Log("MOEDASSS");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>().Pontuar(1);

        }

    }
}
