using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Background : MonoBehaviour
{
    //Declarando as variáveis 
    //------Variáveis Públicas------
    //Variável que define a velocidade de movimentação da imagem de background
    public float moviment_speed = 0.008f;

    //------Variáveis Privadas------
    //Variável que define a rotação vertical da imagem
    private float y_scroll;

    //Variável que receberá o MashRenderer do componente
    private MeshRenderer mesh_Renderer;

    //Essa classe é chamada quando um GameObject que contém o script é inicializado ou quando uma cena é carregada. Isso acontece mesmo antes do método start ser chamado.
    void Awake()
    {
        //Inicialização da variável mesh_Renderer 
        mesh_Renderer = GetComponent<MeshRenderer>();   
    }

    private void FixedUpdate()
    {
        Moviment();
    }
    
    //Método que movimenta a imagem do MeshRenderer do objeto
    void Moviment()
    {
        //Velocidade de rolagem da imagem 
        y_scroll = Time.time * moviment_speed;

        //Vetor de movimentação da imagem 
        Vector2 offset = new Vector2(y_scroll, 0f);

        //Aplica a movimentação á imagem
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
