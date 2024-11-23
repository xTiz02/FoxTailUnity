using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer theSp;
    public Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))
        {
            CheckPointController.instancia.DesactivarCheckPoints();
            theSp.sprite = cpOn;

            CheckPointController.instancia.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        theSp.sprite = cpOff;
    }
}
