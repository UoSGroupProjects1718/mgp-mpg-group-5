using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OnClick : MonoBehaviour
{

    public Animator animator;
    public Button info;
    public Button play;

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
        info.interactable = false;
        play.interactable = false;
    }

    public void StopAnim()
    {
        animator.SetBool("Visible", false);
        info.interactable = true;
        play.interactable = true;
    }
}
