using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.5f;

    void Start()
    {

    }


    void Update()
    {
        if(GameManager.Instance != null && GameManager.Instance.GameOver) return;

        // ABSTRACTION
        MovePlayer();
    }

    // ABSTRACTION
    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(GameManager.Instance != null && GameManager.Instance.GameOver) return;

        if (other.gameObject.CompareTag("Obstacle"))
        {   
            GameManager.Instance?.SetGameOver();
        }
    }
}
