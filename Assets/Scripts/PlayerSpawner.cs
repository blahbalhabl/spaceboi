using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerObject;
    public void EnableCanvas()
        {
            CanvasObject.SetActive(true);
        }
    

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();  
        if(scene.name == "MainScene") {
            GameObject newPlayer = (GameObject)Instantiate(playerObject);
            newPlayer.transform.localScale = Vector2.one;
        }  
    }
}
