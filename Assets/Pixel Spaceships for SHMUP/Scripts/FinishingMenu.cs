using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        Score.scoreValue = 0;
        SceneManager.LoadScene("Menu");
    }
    public void PlayGameAgain()
    {
        Score.scoreValue = 0;
        SceneManager.LoadScene("SampleScene");
    }
}

