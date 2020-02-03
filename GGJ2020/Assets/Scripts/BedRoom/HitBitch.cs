using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBitch : MonoBehaviour
{
    public delegate void _Attack(Sprite sprite);
    public static _Attack Attack;
    public Sprite[] images;
    private SpriteRenderer sr;
    [HideInInspector]
    public bool active = true;
    public float timer = 1;
    private float timerMax;
    private Image timerImg;
    private Animator anim;
    public AudioClip clip;
    public AudioClip aparece;

    private void OnEnable()
    {
        if (SystemManager.Instance != null)
            SystemManager.Instance.PlaySound(aparece);
        anim = GetComponent<Animator>();
        FindObjectOfType<BedRoomManager>().spawnBitch++;
        timerImg = transform.Find("Canvas").GetComponentInChildren<Image>();
        if (SystemManager.Instance != null)
            timer = SystemManager.Instance.scaryTime;
        timerMax = timer;
        int rand = Random.Range(0, images.Length);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite=images[rand];
        HitBitch.Attack += Lose;
    }
    private void OnDisable()
    {
        HitBitch.Attack -= Lose;
    }
    private void OnMouseDown()
    {
        active = false;
        FindObjectOfType<BedRoomManager>().counterHit++;
        if (SystemManager.Instance != null)
            SystemManager.Instance.PlaySound(clip);
        anim.SetBool("play", true);
    }
    private void Lose(Sprite sprite)
    {
        HitBitch[] hb = FindObjectsOfType<HitBitch>();
        foreach (HitBitch h in hb)
            h.active = false;
        print("You Lose");
    }
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        if (active)
        {
            timer -= Time.deltaTime;
            timerImg.fillAmount = timer / timerMax;
            if (timer <= 0)
            {
                timer = 0;
                Attack?.Invoke(sr.sprite);
                gameObject.SetActive(false);
                print("attack");
            }
        }
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
