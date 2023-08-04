
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    //------Variáveis Públicas------
    //Variável que marcará o ponto de impacto do tiro no asteroide
    public GameObject pointContact;
    //Variável que exibirá a explosão do asteróide 
    public GameObject explosionDebris;
    //Variável que exibirá a explosão do asteróide
    public GameObject explosionCore;
    //Variável que exibirá o aúdio da explosão
    public AudioClip asteroidExplosion;
    //Variável que definirá uma rotação para o asteroide
    public float rotate;
    //Variável que definirá a aceleração do asteroide
    public float acceleration;
    //Variável que marcará o ponto de contato do disparo
    public GameObject shootingMark;

    //------Variáveis Privadas-----
    //Variável que definirá o deslocamento no eixo X
    private float xPosition;
    //Variável que exibirá os detritos da explosão
    private GameObject createDebris;
    //Variável que exibirá a fumaça da explosão
    private GameObject createExplosionCore;
    //Variável que receberá a tag do asteroide criado
    private string createObject;
    //Variável que rotacionará o asteroide no eixo X
    private Vector3 xRotation;
    //Variável que receberá a quantidade de tiros recebidos pelo asteroide
    private int shotsReceived;
    //Variável que receberá a classe Shoot
    private Shoot shoot;
    //Variável que acessará o AudioSource da classe Shoot
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializando as variáveis
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
