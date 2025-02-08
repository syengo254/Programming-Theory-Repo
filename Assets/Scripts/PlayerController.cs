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
        if (GameManager.Instance && !GameManager.Instance.GameOver)
        {
            MovePlayer();
        }
    }

    // ABSTRACTION
    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Invoke(nameof(EndGame), 0.1f);
        }
    }

    private void EndGame()
    {
        GameManager.Instance.SetGameOver();
    }
}
