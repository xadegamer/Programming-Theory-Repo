using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
