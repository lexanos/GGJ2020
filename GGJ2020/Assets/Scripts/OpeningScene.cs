using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningScene : MonoBehaviour
{
    void Start()
    {
        StartGame.playLetter = true;
        if (MusicManager.Instance != null)
            MusicManager.Instance.ChangeVolume(0.4f);
            
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EndLevel();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (SystemManager.Instance != null)
        {
            SystemManager.Instance.StopSounds();
            SystemManager.Instance.PlaySound(clip);
        }
    }
    public void EndLevel()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.StopSounds();
            MusicManager.Instance.ChangeVolume(1f);
        }
        SceneManager.LoadScene("Workshop", LoadSceneMode.Single);
    }
}
