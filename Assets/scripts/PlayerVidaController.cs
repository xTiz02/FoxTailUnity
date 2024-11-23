using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVidaController : MonoBehaviour
{
    public static PlayerVidaController instancia;
    public  int vidaMax, vidaActual;
    public float invencibilidadDuracion;
    private float invencibilidadContador;
    private SpriteRenderer theSR;
    public SpriteRenderer deathEffect;
    // Start is called before the first frame update

    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        vidaActual = vidaMax;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(invencibilidadContador > 0)
        {
            invencibilidadContador -= Time.deltaTime;
            if(invencibilidadContador<= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void RecibirDano()
    {
        if (invencibilidadContador <= 0) {
            vidaActual--;
            PlayerScript.instancia.anim.SetTrigger("Golpeado");
            AudioManager.instancia.PlaySFX(9);
            if (vidaActual <= 0)
            {
                vidaActual = 0;
                Instantiate(deathEffect, PlayerScript.instancia.transform.position, PlayerScript.instancia.transform.rotation);
                AudioManager.instancia.PlaySFX(8);
                LevelManager.instancia.RespawnPlayer();
            }
            else
            {
                invencibilidadContador = invencibilidadDuracion;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                PlayerScript.instancia.Knockback();
            }

            UIController.instacia.ActualizarVida();
        }
       
    }

    public void HealPlayer()
    {
        vidaActual++;
        if (vidaActual > vidaMax)
        {
            vidaActual = vidaMax;
          
        }
        UIController.instacia.ActualizarVida();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
            if (other.gameObject.tag == "Platform")
            {
                transform.parent = other.transform;
            }
        
       
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
