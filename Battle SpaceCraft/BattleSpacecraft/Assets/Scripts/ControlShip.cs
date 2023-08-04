using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlShip : MonoBehaviour
{
    //-----Declarando as vari�veis-----
    //-----Vari�veis P�blicas-----
    //Vari�vel que definir� a velocidade de deslocamento
    public float moveSpeed = 5.0f;
    //Vari�vel que receber� o GameObject que det�m o script do JoyStick Virtual
    public VirtualJoyStick joystick;
    //Propriedade declarada como vari�vel que se comporta como m�todo resgatando e/ou gravando dados
    public Vector2 DriveVector { get; set; }
    //Vari�vel que ser� uasada para ativar e desativar o controle da nave espacial
    public bool activeControl;
    //-----Vari�veis Privadas-----
    //Vari�vel que receber� o Rigidbody do Gameobject da espa�onave
    private Rigidbody2D thisRigidbody2D;

    //Vari�veis que definiram os limites de deslocamento da espa�onave na tela
    private float maxHorizontal, minHorizontal, maxVertical, minVertical;

    void Awake() 
    { 
    //Inicializar o thisRigidbody2D
    thisRigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHorizontal = 2.1f;
        minHorizontal = -2.1f;
        maxVertical = 4.0f;
        minVertical = -3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (activeControl)
        {
            DriveVector = DataInput();
            Moviment();
        }
    }

    private void Moviment()
    {
        //Aplica deslocamento ao Rigidbody do GameObject
        thisRigidbody2D.velocity = (DriveVector * moveSpeed);

        //Essa condicional testa se a nave j� atingiu o seu limite de deslocamento para a direita
        if(transform.position.x > maxHorizontal)
        {
            this.transform.position = new Vector3(maxHorizontal, this.transform.position.y, this.transform.position.z);
        }
        //Essa condicional testa se a nave j� atingiu o seu limite de deslocamento para a esquerda
        if (transform.position.x < minHorizontal)
        {
            this.transform.position = new Vector3(minHorizontal, this.transform.position.y, this.transform.position.z);
        }
        //Essa condicional testa se a nave j� atingiu o seu limite de deslocamento para cima
        if (transform.position.y > maxVertical)
        {
            this.transform.position = new Vector3(this.transform.position.x, maxVertical, this.transform.position.z);
        }

        //Essa condicional testa se a nave j� atingiu o seu limite de deslocamento para baixo
        if (transform.position.y < minVertical)  
        {
            this.transform.position = new Vector3(this.transform.position.x, minVertical, this.transform.position.z);
        }
        
    }
    private Vector2 DataInput()
    {

        //Vari�vel que receber� o vetor deslocamento
        Vector2 direcao = Vector2.zero;

        //Recebe o deslocamento horizontal do VirtualJoyStick
        direcao.x = joystick.HorizontalOffset();

        // Recebe o deslocamento vertical do VirtualJoyStick
        direcao.y = joystick.VerticalOffset();

        if (direcao.magnitude > 1.0f) direcao.Normalize();

        return direcao;



    }
}
