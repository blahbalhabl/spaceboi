using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public event System.Action OnPlayerDeath;
    public float speed = 10;
    float screenHalfWidth, screenHalfHeight;

    // Start is called before the first frame update
    void Start()
    {   
        float halfPlayerWidth = transform.localScale.x / 2f;
        float halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        screenHalfHeight = Camera.main.orthographicSize - halfPlayerHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting Player 2D Movement
        Vector2 userInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(userInput * speed * Time.deltaTime);

        // Overcoded Dynamic Box Collider
        if (transform.position.x < -screenHalfWidth) {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        } else if (transform.position.x > screenHalfWidth) {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        } else if (transform.position.y < -screenHalfHeight) {
            transform.position = new Vector2(transform.position.x, -screenHalfHeight);
        } else if (transform.position.y > screenHalfHeight) {
            transform.position = new Vector2(transform.position.x, screenHalfHeight);
        }
    }

    void OnTriggerEnter2D(Collider2D trigerCollider) 
    {
        if (trigerCollider.tag == "Enemy") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
                Destroy(gameObject);
            }
            
        }
    }
}
