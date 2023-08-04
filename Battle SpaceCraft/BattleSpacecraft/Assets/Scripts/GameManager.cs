using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //-----Vari�veis P�blicas----
    //Vari�vel que receber� os prefabs dos asteroides
    public GameObject[] asteroids = new GameObject[6];
    //Vari�veis Privadas-----
    //Vari�vel que instaciar� o asteroide selecionado
    private GameObject createAsteroid;
    //Vari�vel que receber� um n�mero aleat�rio do asteroide a ser criado
    private int choice;
    //Vari�veis que definir�o a posi��o em que o aster�ide deve ser criado e o intervalo de tempo entre a cria��o dos asteroides
    private float positionX, wait;
    //Vari�vel que receber� a quantidade m�xima de cada asteroide na cena
    private int[] quantityAsteroid = new int[6] { 1, 1, 3, 3, 1, 1 };
    //Vari�vel que definir� quantos asteroides devem ser criados
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar a vari�vel stop 
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

    //Corrotina que aguardar� um tempo aleatorio para criar o asteroide
    IEnumerator Wait()
    {
        wait = (float)System.Math.Round((float)Random.Range(0, 3), 2);
        yield return CreateAsteroid();
        yield return new WaitForSeconds(wait);
        stop = true;
    }

    //M�todo que cria os asteroides 
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
