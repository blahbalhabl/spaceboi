using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed, isVisible;
    [SerializeField] private AudioSource hitSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficulty());
        isVisible = -Camera.main.orthographicSize - transform.localScale.y; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < isVisible) {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D trigerCollider) 
    {
        if (trigerCollider.tag == "Player") {
            hitSoundEffect.Play();
        }
    }

}
