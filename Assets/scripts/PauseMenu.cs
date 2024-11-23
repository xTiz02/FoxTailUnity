using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instancia;
    public GameObject pauseScreen;
    public bool isPaused;
    public string levelSelected, mainMenu;
    private void Awake()
    {
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (isPaused)
        {
             isPaused = false;
            pauseScreen.SetActive(false);
           
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelSelected);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
