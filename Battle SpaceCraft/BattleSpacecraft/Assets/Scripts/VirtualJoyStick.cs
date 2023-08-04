using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //Declarando as vari�veis
    //------Vari�veis Privadas------
    //Vari�vel que receber� a imagem do anel externo do JoyStick
    private Image imgRing;
    //Vari�vel que receber� a imagem do bot�o interno do JoyStick
    private Image imgKnob;
    //Vari�vel que receber� o vetor posi��o do JoyStick
    private Vector2 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Inicializa a vari�vel imgRing
        imgRing = GetComponent<Image>();
        //Inicializa a vari�vel imgKnob com seu transform position
        imgKnob = transform.GetChild(0).GetComponent<Image>();
    }

    //Devolve o deslocamento do arrastar do dedo na tela do Device
    public void OnDrag(PointerEventData drag)
    {
        //Vari�vel que receber� o vetor posi��o de sa�da
        Vector2 position;

        //Devolve o vetor posi��o do ponto tocado na tela no espa�o retangular onde est� a imagem do bot�o do JoyStick
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgRing.rectTransform, 
            drag.position,
            drag.pressEventCamera,
            out position))
        {
            //Definindo o vetor posi��o com base no tamanho do RecTransform tomando por base os pontos de ancoragem do gameobject image
            position.x =(position.x / imgRing.rectTransform.sizeDelta.x);
            position.y = (position.y / imgRing.rectTransform.sizeDelta.y);

            //Ajuste a posi��o do toque no joystick
            inputVector = new Vector2(position.x * 2f + 1f, position.y * 2f-1f);

            //Retorna a norma do vetor quando a magnitude de deslocamento for maior que 1
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            imgKnob.rectTransform.anchoredPosition =
                new Vector2((inputVector.x * imgRing.rectTransform.sizeDelta.x / 6f),
                           (inputVector.y * imgRing.rectTransform.sizeDelta.y / 6f));
            Debug.Log("Position [x, y]: " + inputVector);
        }
    }

    public void OnPointerDown(PointerEventData pointDW)
    {
        OnDrag(pointDW);
    }

    public void OnPointerUp(PointerEventData pointerUP)
    {
        inputVector = Vector2.zero;
        imgKnob.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float HorizontalOffset()
    {
        if(inputVector.x != 0f)
        {
            return inputVector.x;
        }
       
        else
        {
            return Input.GetAxis("Horizontal");
        }
        
    }

    public float VerticalOffset()
    {
        if (inputVector.y != 0f)
        {
            return inputVector.y;
        }

        else
        {
            return Input.GetAxis("Vertical");
        }


    }

}

