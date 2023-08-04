using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Background : MonoBehaviour
{
    //Declarando as vari�veis 
    //------Vari�veis P�blicas------
    //Vari�vel que define a velocidade de movimenta��o da imagem de background
    public float moviment_speed = 0.008f;

    //------Vari�veis Privadas------
    //Vari�vel que define a rota��o vertical da imagem
    private float y_scroll;

    //Vari�vel que receber� o MashRenderer do componente
    private MeshRenderer mesh_Renderer;

    //Essa classe � chamada quando um GameObject que cont�m o script � inicializado ou quando uma cena � carregada. Isso acontece mesmo antes do m�todo start ser chamado.
    void Awake()
    {
        //Inicializa��o da vari�vel mesh_Renderer 
        mesh_Renderer = GetComponent<MeshRenderer>();   
    }

    private void FixedUpdate()
    {
        Moviment();
    }
    
    //M�todo que movimenta a imagem do MeshRenderer do objeto
    void Moviment()
    {
        //Velocidade de rolagem da imagem 
        y_scroll = Time.time * moviment_speed;

        //Vetor de movimenta��o da imagem 
        Vector2 offset = new Vector2(y_scroll, 0f);

        //Aplica a movimenta��o � imagem
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
