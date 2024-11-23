using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private Animator anim;
    public float bounceForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerScript.instancia.rigbody2D.velocity = new Vector2(PlayerScript.instancia.rigbody2D.velocity.x, bounceForce);
            anim.SetTrigger("Bounce");
        }
    }
}
