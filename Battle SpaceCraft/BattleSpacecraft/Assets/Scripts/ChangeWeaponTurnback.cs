using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeWeaponTurnback : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //-----Vari�veis P�blicas----
    //Vari�vel que receber� as imagens do bot�o de avan�o de armamamento
    public Image imgButtonTurnback;
    //Vari�vel que receber� a arma atual em uso
    public Shoot currentWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
       // Inicializa a vari�vel que receber� a imagem do bot�o de disparo
       imgButtonTurnback = GameObject.Find("imgTurnback").GetComponent<Image>();
       imgButtonTurnback.sprite = Resources.Load<Sprite>("Sprits/Buttons/TurnBackUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        imgButtonTurnback.sprite = Resources.Load<Sprite>("Sprits/Buttons/TurnBackDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        imgButtonTurnback.sprite = Resources.Load<Sprite>("Sprits/Buttons/TurnBackUp");

        //Mudar de armamento em uso
        if (currentWeapon.weaponName.text == "Tiro Azul")
        {
            currentWeapon.ChangeWeapon(1);
        }
        else if (currentWeapon.weaponName.text == "Tiro Vermelho")
        {
            currentWeapon.ChangeWeapon(2);
        }
        else if(currentWeapon.weaponName.text == "M�ssel")
        {
            currentWeapon.ChangeWeapon(0);
        }
    }

}
