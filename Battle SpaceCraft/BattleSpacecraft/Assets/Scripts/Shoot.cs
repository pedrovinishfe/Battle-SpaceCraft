
using UnityEngine.UI;
using UnityEngine; 
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Shoot : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //Variáveis Públicas ------
    //Variável que receberá as imagens do botão de disparo
    public Image imgButton;
    //Variável que receberá a imagem da munição em uso
    public Image ammunitionType;
    //Cria uma lista com as variáveis dos script GunControl
    public GunControl[] aboutArma;
    //Variável que receberá a arma atual em uso;
    public GunControl currentWeapon;
    //Variável que receberá o nome da arma em uso
    public TMP_Text weaponName;
    //Variável que receberá a quantidade de munições da arma em uso
    public TMP_Text amountAmmunition;
    //Variável que receberá o som do disparo
    public AudioSource shootingSound;
    //Variável que receberá a posição da nave
    public GameObject shipPosition;

    //-----Variáveis Privadas----
    //Variável que receberá o GameObject de disparo 
    private GameObject firing;
    //Define de qual arma vai sair o tiro(direita ou esquerda)
    private bool rightShot;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializa o método que troca de arma 
        CurrentWeapon(0);

        //Inicializa a variável que define de qual arma sairá o disparo 
        rightShot = false;

        //Inicializa a variável que receberá a imagem do botão de disparo 
        imgButton = GameObject.Find("imgFireButton").GetComponent<Image>();
        imgButton.sprite = Resources.Load<Sprite>("Sprits/Buttons/FireButtonUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Método que troca a arma em uso
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
    //Método que seleciona a arma a ser usada
    public void ChangeWeapon (int weapon)
    {
        CurrentWeapon(weapon);
    }
    //Método que deflagra o disparo 
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
    
