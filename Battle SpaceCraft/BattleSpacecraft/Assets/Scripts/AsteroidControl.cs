
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    //------Vari�veis P�blicas------
    //Vari�vel que marcar� o ponto de impacto do tiro no asteroide
    public GameObject pointContact;
    //Vari�vel que exibir� a explos�o do aster�ide 
    public GameObject explosionDebris;
    //Vari�vel que exibir� a explos�o do aster�ide
    public GameObject explosionCore;
    //Vari�vel que exibir� o a�dio da explos�o
    public AudioClip asteroidExplosion;
    //Vari�vel que definir� uma rota��o para o asteroide
    public float rotate;
    //Vari�vel que definir� a acelera��o do asteroide
    public float acceleration;
    //Vari�vel que marcar� o ponto de contato do disparo
    public GameObject shootingMark;

    //------Vari�veis Privadas-----
    //Vari�vel que definir� o deslocamento no eixo X
    private float xPosition;
    //Vari�vel que exibir� os detritos da explos�o
    private GameObject createDebris;
    //Vari�vel que exibir� a fuma�a da explos�o
    private GameObject createExplosionCore;
    //Vari�vel que receber� a tag do asteroide criado
    private string createObject;
    //Vari�vel que rotacionar� o asteroide no eixo X
    private Vector3 xRotation;
    //Vari�vel que receber� a quantidade de tiros recebidos pelo asteroide
    private int shotsReceived;
    //Vari�vel que receber� a classe Shoot
    private Shoot shoot;
    //Vari�vel que acessar� o AudioSource da classe Shoot
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializando as vari�veis
        xPosition = Random.Range(0, 180);
        xRotation = new Vector3(0f, 0f, xPosition);
        createObject = this.gameObject.tag;
        shoot = FindObjectOfType(typeof(Shoot)) as Shoot;
        explosionSound = shoot.shootingSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -5.752f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D pedrada)
    {
        if (pedrada.gameObject.tag == "sptBlueProjectile")
        {
            (Instantiate(shootingMark, this.transform.position, this.transform.rotation) as GameObject).transform.parent = this.transform;
            Destroy(pedrada.gameObject);
            shotsReceived++;
        }

        if (pedrada.gameObject.tag == "sptRedProjectile")
        {
            (Instantiate(shootingMark, this.transform.position, this.transform.rotation) as GameObject).transform.parent = this.transform;
            Destroy(pedrada.gameObject);
            shotsReceived += 2 ;
        }

        if (pedrada.gameObject.tag == "sptMissile")
        {
            (Instantiate(shootingMark, this.transform.position, this.transform.rotation) as GameObject).transform.parent = this.transform;
            Destroy(pedrada.gameObject);
            shotsReceived +=5;
        }

        switch (shotsReceived) 
        {
            case 3:
                if (this.gameObject.tag == "sptAsteroid3" || this.gameObject.tag == "sptAsteroid4")
                {
                    CreateDebris(this.transform.position);
                    explosionSound.PlayOneShot(asteroidExplosion);
                    Destroy(this.gameObject);
                }
                break;

            case 4:
                if (this.gameObject.tag == "sptAsteroid3" || this.gameObject.tag == "sptAsteroid4" || this.gameObject.tag == "sptAsteroid5")
                {
                    CreateDebris(this.transform.position);
                    explosionSound.PlayOneShot(asteroidExplosion);
                    Destroy(this.gameObject);
                }
                break;
            default:
                if(shotsReceived >= 5)
                {
                    CreateDebris(this.transform.position);
                    explosionSound.PlayOneShot(asteroidExplosion);
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    void CreateDebris(Vector3 position)
    {
        createDebris = Instantiate(explosionDebris);
        createDebris.transform.position = new Vector3(position.x, position.y, position.z);
        createExplosionCore = Instantiate(explosionCore);
        createExplosionCore.transform.position = new Vector3(position.x, position.y, position.z);
        Destroy(createDebris.gameObject, 1.5f); 
        Destroy(createExplosionCore.gameObject, 2.0f);
    }
}
