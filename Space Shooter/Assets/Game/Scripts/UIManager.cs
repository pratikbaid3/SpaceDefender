using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] livesImage;
    public Image livesImageDisplay;
    public Text scoreTextDisplay;
    public int score;
    public GameObject mainMenu;
    public bool gameState=false;
      
    public void UpdateLives(int lives)
    {
        livesImageDisplay.sprite = livesImage[lives];
    }

    public void UpdateScore()
    {
        score++;
        scoreTextDisplay.text = "SCORE: " + score;
    }

    public void DisableMainMenu()
    {
        mainMenu.SetActive(false);
        score = 0;
        scoreTextDisplay.text = "SCORE: " + score;
        livesImageDisplay.sprite = livesImage[3];
        gameState = true;
    }
    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        gameState = false;
    }
}
