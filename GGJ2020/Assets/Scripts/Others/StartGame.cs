using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static bool playLetter = false;
    void Start()
    {
        if (FindObjectOfType<DollsManager>() != null)
            Destroy(FindObjectOfType<DollsManager>().gameObject);
    }

    public void PlayGame()
    {
        if (!playLetter)
        {
            SceneManager.LoadScene("Opening", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Workshop", LoadSceneMode.Single);
        }
    }
    public void Ending()
    {
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
