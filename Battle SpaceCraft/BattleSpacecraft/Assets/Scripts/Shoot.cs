
using UnityEngine.UI;
using UnityEngine; 
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Shoot : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //Vari�veis P�blicas ------
    //Vari�vel que receber� as imagens do bot�o de disparo
    public Image imgButton;
    //Vari�vel que receber� a imagem da muni��o em uso
    public Image ammunitionType;
    //Cria uma lista com as vari�veis dos script GunControl
    public GunControl[] aboutArma;
    //Vari�vel que receber� a arma atual em uso;
    public GunControl currentWeapon;
    //Vari�vel que receber� o nome da arma em uso
    public TMP_Text weaponName;
    //Vari�vel que receber� a quantidade de muni��es da arma em uso
    public TMP_Text amountAmmunition;
    //Vari�vel que receber� o som do disparo
    public AudioSource shootingSound;
    //Vari�vel que receber� a posi��o da nave
    public GameObject shipPosition;

    //-----Vari�veis Privadas----
    //Vari�vel que receber� o GameObject de disparo 
    private GameObject firing;
    //Define de qual arma vai sair o tiro(direita ou esquerda)
    private bool rightShot;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializa o m�todo que troca de arma 
        CurrentWeapon(0);

        //Inicializa a vari�vel que define de qual arma sair� o disparo 
        rightShot = false;

        //Inicializa a vari�vel que receber� a imagem do bot�o de disparo 
        imgButton = GameObject.Find("imgFireButton").GetComponent<Image>();
        imgButton.sprite = Resources.Load<Sprite>("Sprits/Buttons/FireButtonUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //M�todo que troca a arma em uso
    void CurrentWeapon( int weapon)
    {
        currentWeapon = aboutArma[weapon];
        firing = currentWeapon.gobjGunShot;
        weaponName.text = currentWeapon.strArmament;
        amountAmmunition.text = "" + currentWeapon.intRemGunShot;
        ammunitionType.sprite = currentWeapon.image;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        imgButton.sprite = Resources.Load<Sprite>("Sprits/Buttons/FireButtonUp");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        imgButton.sprite = Resources.Load<Sprite>("Sprits/Buttons/FireButtonDown");

        if(currentWeapon.intRemGunShot > 0)
        {
            DeflagratingShot(currentWeapon.gobjGunShot.gameObject.tag);
        }
    }
    //M�todo que seleciona a arma a ser usada
    public void ChangeWeapon (int weapon)
    {
        CurrentWeapon(weapon);
    }
    //M�todo que deflagra o disparo 
    private void DeflagratingShot(string tagShot)
    {
        firing = Instantiate(currentWeapon.gobjGunShot);
        if (tagShot == "sptBlueProjectile")
        {
            if (rightShot == false)
            {
                firing.transform.position = new Vector3(shipPosition.transform.position.x - 0.23f, shipPosition.transform.position.y + 0.7f, -5.0f);
                rightShot = true;
            }
            else
            {
                firing.transform.position = new Vector3(shipPosition.transform.position.x + 0.22f, shipPosition.transform.position.y + 0.7f, 5.0f);
                rightShot = false;
            }
        }
        else
        {
            firing.transform.position = new Vector3(shipPosition.transform.position.x, shipPosition.transform.position.y + 0.55f, -5.0f);


            rightShot = false;
        }
        currentWeapon.intRemGunShot--;
        amountAmmunition.text = "" + currentWeapon.intRemGunShot;
        shootingSound.GetComponent<AudioSource>().PlayOneShot(currentWeapon.shootingSound);

    }





    }
    
