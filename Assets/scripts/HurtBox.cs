using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible;
    [Range(0,100)]public float chanceToDrop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
           
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerScript.instancia.Bounce();

            float dropSelect = Random.Range(0, 100f );
            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
            AudioManager.instancia.PlaySFX(3);
        }
    }
}
