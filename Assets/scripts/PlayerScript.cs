using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instancia;
    public float velocidad;
    public float salto;
    public float bounceForce;
    public Rigidbody2D rigbody2D;
    public Transform pisoCheckPoint;
    public LayerMask capaSuelo;
    private bool enSuelo;
    private bool saltoDoble;
    public Animator anim;
    public bool stopInput;

    public float knockbackLargo, knockbackFuerza;
    private float knockbackContador;

    private void Awake()
    {
        instancia = this;
    }

    //private SpriteRenderer spriteRenderer;
    void Start()
    {
        anim = GetComponent<Animator>(); //Se asigna el componente Animator del Player
        rigbody2D = GetComponent<Rigidbody2D>();//Se asigna el componente Rigidbody2D del Player
        //spriteRenderer = GetComponent<SpriteRenderer>();Se asigna el componente SpriteRenderer del Player
    }

    //Actualiza la posicion del personaje
    void Update()
    {
        if (!PauseMenu.instancia.isPaused && !stopInput)
        {
            if (knockbackContador < 0)
            {
                //Mira si el personaje esta tocando el suelo o no con un circulo en la posicion del pisoCheckPoint
                enSuelo = Physics2D.OverlapCircle(pisoCheckPoint.position, 0.8f, capaSuelo);
                MoverHz();

                //Si el personaje esta en el suelo, se le permite hacer un salto doble
                if (enSuelo)
                {
                    saltoDoble = true;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (enSuelo)
                    {
                        Salto();
                    }
                    else
                    {
                        if (saltoDoble)
                        {
                            Salto();
                            AudioManager.instancia.PlaySFX(10);
                            saltoDoble = false;
                        }

                    }
                }

            }
            else
            {
                knockbackContador -= Time.deltaTime;
                //Empujar hacia atras al personaje cuando recibe daño
                if (transform.localScale.x == 1)
                {
                    rigbody2D.velocity = new Vector2(-knockbackFuerza, rigbody2D.velocity.y);
                }
                else
                {
                    rigbody2D.velocity = new Vector2(knockbackFuerza, rigbody2D.velocity.y);
                }
            }
        }
        
        anim.SetFloat("velocidad", Mathf.Abs(rigbody2D.velocity.x)); //Se asigna la velocidad del personaje al parametro velocidad del Animator
        anim.SetBool("enPiso", enSuelo); //Se asigna el estado del personaje al parametro enSuelo del Animator

    }
    private void MoverHz()
    {
        float hz = Input.GetAxisRaw("Horizontal");

        rigbody2D.velocity = new Vector2(hz * velocidad, rigbody2D.velocity.y);

        if (hz < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (hz > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void Salto()
    {
        rigbody2D.velocity = new Vector2(rigbody2D.velocity.x, salto);
        AudioManager.instancia.PlaySFX(10);
    }

    public void Knockback()
    {
        knockbackContador = knockbackLargo;
        rigbody2D.velocity = new Vector2(0f, knockbackFuerza);

    }

    public void Bounce()
    {
        rigbody2D.velocity = new Vector2(rigbody2D.velocity.x, bounceForce);
    }
}
