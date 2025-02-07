using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 5.0f;
    private float zBound = -9.0f;

    void Update()
    {
        if (GameManager.Instance && GameManager.Instance.GameOver)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

        // ABSTARCTION
        CheckBoundsAndDestroy();
    }

    private void CheckBoundsAndDestroy()
    {
        if(transform.position.z < zBound)
        {
            Destroy(gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddPlayerScore();
            }
        }
    }
}
