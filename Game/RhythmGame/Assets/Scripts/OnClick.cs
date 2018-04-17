using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnClick : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        //GameManager.instance.playerTurn = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
