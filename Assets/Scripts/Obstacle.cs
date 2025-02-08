using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] ObstacleType obstacleType;

    private float zBound = -8.5f;

    void Update()
    {
        if (GameManager.Instance && !GameManager.Instance.GameOver)
        {
            transform.Translate(new Vector3(0, 0, - obstacleType.Speed * Time.deltaTime));
        }

        // ABSTRACTION
        CheckBoundsAndDestroy();
    }

    private void CheckBoundsAndDestroy()
    {
        if (transform.position.z < zBound)
        {
            Destroy(gameObject);

            GameManager.Instance?.AddPlayerScore(obstacleType.Points);
            MainManager.Current.EvadedCount ++;
        }
    }
}
