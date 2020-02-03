using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BedRoomManager : MonoBehaviour
{
    private Animator anim;
    public Image image;
    public GameObject[] spawnPoints;
    public GameObject doll;
    private AudioSource source;

    private float timer = 0;
    private float delay = 0;
    public float timerNight;
    private int counterEnemies = 0;
    private int spawnBitches = 0;
    public int counterHit;
    public int spawnBitch;
    [HideInInspector]
    public bool play = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        counterEnemies = DollsManager.Instance.dollCounter + DollsManager.Instance.evilCounter;
        print(counterEnemies);
        spawnBitches = counterEnemies;
        if (SystemManager.Instance != null)
            timerNight = SystemManager.Instance.bedroomTime;
        SetDelay();
    }
    private void OnEnable()
    {
        HitBitch.Attack += Lose;
    }
    private void OnDisable()
    {
        HitBitch.Attack -= Lose;
    }
    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    public void PlaySecondSound(AudioClip clip)
    {
        if (SystemManager.Instance != null)
            SystemManager.Instance.PlaySound(clip);
    }
    private void Lose(Sprite sprite)
    {
        play = false;
        image.sprite = sprite;
        anim.SetBool("play", true);
    }
    public void EndAnimation()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    private void Update()
    {
        if (play)
        {
            timerNight -= Time.deltaTime;
            if (timerNight > 0)
            {
                timer += Time.deltaTime;
                if (counterHit == counterEnemies)
                    timerNight = 0;
                if (timer >= delay)
                {
                    if (DollsManager.Instance != null)
                    {
                        if (spawnBitch < spawnBitches)
                        {
                            int spawnPointSelection = Random.Range(0, spawnPoints.Length);
                            Instantiate(doll, spawnPoints[spawnPointSelection].transform.position, spawnPoints[spawnPointSelection].transform.rotation);
                        }
                    }
                    else
                    {
                        print("Spawn Bitch");
                    }
                    SetDelay();
                    timer = 0;
                }
            }
            else
            {
                anim.SetBool("win", true);
            }
        }
     
    }

    public void LevelComplete()
    {
        print("night End, you survive");
        DollsManager.Instance.rest = DollsManager.Instance.dollCounter;
        DollsManager.Instance.days++;
        if (DollsManager.Instance.days > 5)
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("Workshop", LoadSceneMode.Single);
    }

    private void SetDelay()
    {
        if (SystemManager.Instance != null)
            delay = Random.Range(SystemManager.Instance.minSpawnTime, SystemManager.Instance.maxSpawnTime);
        else
            delay = Random.Range(1, 3);
    }
}
