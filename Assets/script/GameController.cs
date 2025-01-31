
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject pauseButton;
    public GameObject gameOver;
    public GameObject startmenu;
    public CoinCount coinCount;
    public TMP_Text yourScore;

    public GameObject tryagainButton;
    // Start is called before the first frame update
    void Start()
    {
       Time.timeScale = 0f;
        startmenu.SetActive(true);
        gameOver.SetActive(false);
        PauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOver.SetActive(false);
        
    }


    public void StartMenue()
    {
        startmenu.SetActive(false);  
        Time.timeScale = 1f;
    }
    public void PauseMenue()
    {
        PauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        
        PauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void reload()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void updateHighScore(int score)
    {
        yourScore.text=score.ToString();
    }
    
    public void GameOver()
    {
      gameOver.SetActive(true);
      pauseButton.SetActive(false);
      
    }
  
    public  void QuitGame()
    {
        Application.Quit();
        
    }
}
