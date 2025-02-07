using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUIHandler : MonoBehaviour
{
    public void HandleMenuButton()
    {
        GameManager.Instance.ShowMenu();
    } 
}
