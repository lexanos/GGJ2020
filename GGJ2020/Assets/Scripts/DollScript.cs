using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollScript : MonoBehaviour
{
    public List<JointPoint> joints;
    public Sprite[] chest;
    private SpriteRenderer sr;
    public GameObject[] parts;
    public GameObject buttonObject;
    public bool evil = false;
    private int completeValue = 5;
    public AudioClip[] clip;
    private Animator anim;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public void Create()
    {
        DollsManager.Instance.AddDollCounter();
        completeValue = parts.Length;
        int rand = Random.Range(0, chest.Length);
        sr.sprite = chest[rand];
        for (int i = 0; i < parts.Length; i++)
        {
            int random = Random.Range(0, 2);
            if (random > 0)
            {
                if (completeValue < 2)
                    break;
                if (joints[i]!=null)
                {
                    GameObject go = Instantiate(parts[i], joints[i].transform.position, joints[i].transform.rotation);
                    joints[i].SetID(go.GetComponent<BodyPart>().ID);
                    joints[i].PlacePart();
                    go.GetComponent<BodyPart>().Generated();
                    go.transform.SetParent(transform);
                }
            }
        }
    }

    public void Substract()
    {
        completeValue--;
        if (completeValue <= 0)
        {
            print(evil);
            if (evil)
                DollsManager.Instance.AddEvilDoll();
            anim.SetBool("play", true);
        }
    }

    public void Complete()
    {
        if (SystemManager.Instance != null)
            SystemManager.Instance.StopSounds();
        if (evil)
        {
            if (SystemManager.Instance != null)
                SystemManager.Instance.PlaySound(clip[0]);
        }
        else
        {
            if (SystemManager.Instance != null)
                SystemManager.Instance.PlaySound(clip[1]);
        }
    }
    public void EndAnimation()
    {
        DollsManager.Instance.RemoveDollCounter();
        CreateNewButtons cn = FindObjectOfType<CreateNewButtons>();
        cn.RemoveButton(buttonObject.GetComponent<UI_DollButton>());
        Destroy(buttonObject);
        Destroy(this.gameObject);
    }

}
