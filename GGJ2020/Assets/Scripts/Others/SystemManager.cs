using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [Header("El tiempo antes de que ataque la bitch")]
    public float scaryTime = 2f;
    [Header("El tiempo del Taller")]
    public float workshopTime = 60f;
    [Header("El tiempo que dura la noche")]
    public float bedroomTime = 100f;
    [Header("El tiempo minimo de spawn")]
    public float minSpawnTime = 0.5f;
    [Header("El tiempo maximo de spawn")]
    public float maxSpawnTime = 3f;
    private AudioSource source;
    public static SystemManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Screen.fullScreen = true;
    }
    public void StopSounds()
    {
        source.Stop();
    }
    public void PlaySound(AudioClip clip)
    {
        if (!source.isPlaying)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
