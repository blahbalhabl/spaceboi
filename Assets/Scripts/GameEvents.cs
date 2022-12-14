using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text timeSurived;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {   
        
         if(gameOver) {
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(1);
            } else if (Input.GetKeyDown(KeyCode.Escape)){
                Application.Quit();
            }
        }
    }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        timeSurived.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
