using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instancia;
    public float waitToRespawn;
    public int gemsCollected;
    public string levelToLoad;
    public float timeInLevel;
    private void Awake()
    {
        instancia = this;

    }

    void Start()
    {
        timeInLevel = 0f;
    }


    void Update()
    {
        timeInLevel += Time.deltaTime;
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        PlayerScript.instancia.gameObject.SetActive(false); 
        yield return new WaitForSeconds(waitToRespawn - (1f/UIController.instacia.fadeSpeed));
        UIController.instacia.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instacia.fadeSpeed) + .2f);
        UIController.instacia.FadeFromBlack();

        PlayerScript.instancia.gameObject.SetActive(true);
        PlayerScript.instancia.transform.position = CheckPointController.instancia.spawnPoint;
        
        PlayerVidaController.instancia.vidaActual = PlayerVidaController.instancia.vidaMax;
        UIController.instacia.ActualizarVida();

    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        AudioManager.instancia.PlayLevelVictory();
        PlayerScript.instancia.stopInput = true;
        CamaraController.instancia.stopFollow = true;
        UIController.instacia.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instacia.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instacia.fadeSpeed) + .25f);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if (gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems",gemsCollected))
            {   
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
      
        SceneManager.LoadScene(levelToLoad);

    }
}
