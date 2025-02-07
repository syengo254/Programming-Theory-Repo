using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameUIHandler : MonoBehaviour
{
    public void HandleMenuButton()
    {
        GameManager.Instance?.ShowMenu();
    }

    public void HandleRestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
