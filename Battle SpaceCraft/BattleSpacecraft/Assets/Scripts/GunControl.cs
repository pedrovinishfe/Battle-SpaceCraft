
using Unity.VisualScripting;
using UnityEngine;

//Essa declara��o permitir� decidir as vari�veis p�blicas no Inspector do Unity 3D
[System.Serializable]
public class GunControl 
{
    //Vari�vel GameObject do Tiro
    public GameObject gobjGunShot;
    //Vari�vel que receber� o nome do armamento
    public string strArmament;
    //Vari�vel que receber� a quantidade de disparos restantes
    public int intRemGunShot;
    //Vari�vel que receber� a quantidade m�xima de disparos
    public int intMaxGunShot;
    //Vari�vel que receber� o Sprite do disparo
    public Sprite image;
    //Vari�vel que receber� o som do disparo
    public AudioClip shootingSound;
}
