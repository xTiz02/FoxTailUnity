using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instacia;
    public Image vida1, vida2, vida3;
    public Sprite vidaFull, vidaVacia, vidaMedia;
    public Text gemTex;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelCompleteText;

    private void Awake()
    {
        instacia = this;
    }

    void Start()
    {
        UpdateGemCount();
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void ActualizarVida()
    {
        switch (PlayerVidaController.instancia.vidaActual)
        {
           case 6:
                vida1.sprite = vidaFull;
                vida2.sprite = vidaFull;
                vida3.sprite = vidaFull;
                break;
            case 5:
                vida1.sprite = vidaFull;
                vida2.sprite = vidaFull;
                vida3.sprite = vidaMedia;
                break;
            case 4:
                vida1.sprite = vidaFull;
                vida2.sprite = vidaFull;
                vida3.sprite = vidaVacia;
                break;
            case 3:
                vida1.sprite = vidaFull;
                vida2.sprite = vidaMedia;
                vida3.sprite = vidaVacia;
                break;
            case 2:
                vida1.sprite = vidaFull;
                vida2.sprite = vidaVacia;
                vida3.sprite = vidaVacia;
                break;
            case 1:
                vida1.sprite = vidaMedia;
                vida2.sprite = vidaVacia;
                vida3.sprite = vidaVacia;
                break;
            case 0:
                vida1.sprite = vidaVacia;
                vida2.sprite = vidaVacia;
                vida3.sprite = vidaVacia;
                break;
            default:
                vida1.sprite = vidaVacia;
                vida2.sprite = vidaVacia;
                vida3.sprite = vidaVacia;
                break;
        }
    }

    public void UpdateGemCount()
    {
        gemTex.text = LevelManager.instancia.gemsCollected.ToString();
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
