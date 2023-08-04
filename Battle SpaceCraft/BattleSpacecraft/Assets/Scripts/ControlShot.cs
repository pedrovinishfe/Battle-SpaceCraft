
using UnityEngine;

public class ControlShot : MonoBehaviour
{
    //----Variáveis Públicas----
    //Variável de aceleração do disparo
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Deslocamento do disparo
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + acceleration, -5.0f);

        if (this.transform.position.y > 5.752f)
        {
            Destroy(this.gameObject);
        }
    }

    //Destroi o disparo ao tocar em um objeto
    public void DestroyShooting(GameObject shot)
    {
        Destroy(shot.gameObject);
    }
}
