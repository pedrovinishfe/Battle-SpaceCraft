using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //-----Variáveis Públicas----
    //Variável que receberá os prefabs dos asteroides
    public GameObject[] asteroids = new GameObject[6];
    //Variáveis Privadas-----
    //Variável que instaciará o asteroide selecionado
    private GameObject createAsteroid;
    //Variável que receberá um número aleatório do asteroide a ser criado
    private int choice;
    //Variáveis que definirão a posição em que o asteróide deve ser criado e o intervalo de tempo entre a criação dos asteroides
    private float positionX, wait;
    //Variável que receberá a quantidade máxima de cada asteroide na cena
    private int[] quantityAsteroid = new int[6] { 1, 1, 3, 3, 1, 1 };
    //Variável que definirá quantos asteroides devem ser criados
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar a variável stop 
        stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            stop = false;
            StartCoroutine("Wait");
        }
    }

    //Corrotina que aguardará um tempo aleatorio para criar o asteroide
    IEnumerator Wait()
    {
        wait = (float)System.Math.Round((float)Random.Range(0, 3), 2);
        yield return CreateAsteroid();
        yield return new WaitForSeconds(wait);
        stop = true;
    }

    //Método que cria os asteroides 
    public bool CreateAsteroid()
    {
        positionX = Random.Range(-2.5f, 2.5f);
        choice = Random.Range(0, 5);

        if (GameObject.FindGameObjectsWithTag(asteroids[choice].gameObject.tag).Length <=quantityAsteroid[choice])
        {
            createAsteroid = Instantiate (asteroids[choice] );
            createAsteroid.transform.position = new Vector3(positionX, 6.0f, -0.5f);
        }

        return true;
    }
}
