using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void RetryButtonPress()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitButtonPress()
    {
        Application.Quit();
    }
}