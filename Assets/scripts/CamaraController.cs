using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public static CamaraController instancia;
    public Transform target;
    public Transform farBackground, middleBackground;
    private Vector2 ultimaPos;
    public float alturaMin, alturaMax;
    public bool stopFollow;


    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        ultimaPos = transform.position;
    }

    
    void Update()
    {
        if (!stopFollow)
        {
            //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.y);
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, alturaMin, alturaMax), transform.position.z);

            //Se calcula la cantidad de movimiento de la camara y se aplica a los fondos lejanos y medios para dar la sensacion de paralaje
            Vector2 numParaMover = new Vector2(transform.position.x - ultimaPos.x, transform.position.y - ultimaPos.y);
            farBackground.position = farBackground.position + new Vector3(numParaMover.x, numParaMover.y, 0f);
            middleBackground.position += new Vector3(numParaMover.x, numParaMover.y, 0f) * .5f;
            ultimaPos = transform.position;
        }
       
    }
}
