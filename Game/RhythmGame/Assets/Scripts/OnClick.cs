using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnClick : MonoBehaviour
{

    public Animator animator;

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        //GameManager.instance.playerTurn = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAnim()
    {
        animator.SetBool("Visible", true);
    }

    public void StopAnim()
    {
        animator.SetBool("Visible", false);
    }
}
