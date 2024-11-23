using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitBox : MonoBehaviour
{

    public BossTankController boosCont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerScript.instancia.transform.position.y > transform.position.y)
        {
            boosCont.TakeHit();
            PlayerScript.instancia.Bounce();
            gameObject.SetActive(false);
        }
    }
}
