
using Unity.VisualScripting;
using UnityEngine;

//Essa declaração permitirá decidir as variáveis públicas no Inspector do Unity 3D
[System.Serializable]
public class GunControl 
{
    //Variável GameObject do Tiro
    public GameObject gobjGunShot;
    //Variável que receberá o nome do armamento
    public string strArmament;
    //Variável que receberá a quantidade de disparos restantes
    public int intRemGunShot;
    //Variável que receberá a quantidade máxima de disparos
    public int intMaxGunShot;
    //Variável que receberá o Sprite do disparo
    public Sprite image;
    //Variável que receberá o som do disparo
    public AudioClip shootingSound;
}
