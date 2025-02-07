using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreenUIHandler : MonoBehaviour
{
    public void HandleStartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void HandleExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
