using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeWeaponAdvance : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //-----Variáveis Públicas----
    //Variável que receberá as imagens do botão de avanço de armamamento
    public Image imgButtonAdvance;
    //Variável que receberá a arma atual em uso
    public Shoot currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializa a variável que receberá a imagem do botão de disparo 
        imgButtonAdvance = GameObject.Find("imgAdvance").GetComponent<Image>();
        imgButtonAdvance.sprite = Resources.Load<Sprite>("Sprits/Buttons/AdvanceUp");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        imgButtonAdvance.sprite = Resources.Load<Sprite>("Sprits/Buttons/AdvanceDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        imgButtonAdvance.sprite = Resources.Load<Sprite>("Sprits/Buttons/AdvanceUp");

        //Mudar de armamento em uso
        if (currentWeapon.weaponName.text == "Tiro Azul")
        {
            currentWeapon.ChangeWeapon(1);
        }else if(currentWeapon.weaponName.text == "Tiro Vermelho")
        {
            currentWeapon.ChangeWeapon(2);
        }
        else if (currentWeapon.weaponName.text == "Míssel")
        {
            currentWeapon.ChangeWeapon(0);
        }
    }
}
