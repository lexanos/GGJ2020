using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip music;
    private void Start()
    {
        if (MusicManager.Instance!=null)
        {
            MusicManager.Instance.StopSounds();
            MusicManager.Instance.PlaySound(music);
        }
    }
}
