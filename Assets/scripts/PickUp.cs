using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isGem,isHeart;
    private bool isCollected;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instancia.gemsCollected++;
                UIController.instacia.UpdateGemCount();
                Instantiate(pickupEffect, transform.position, transform.rotation);
                AudioManager.instancia.PlaySFX(6);
                isCollected = true;
                Destroy(gameObject);
            }

            if (isHeart)
            {
                if(PlayerVidaController.instancia.vidaActual != PlayerVidaController.instancia.vidaMax)
                {
                    PlayerVidaController.instancia.HealPlayer();
                    AudioManager.instancia.PlaySFX(7);
                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }

}
