using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DollButton : MonoBehaviour
{
    public delegate void _Destroyed();
    public static _Destroyed Destroyed;
    public static _Destroyed Created;

    public GameObject dollInstance;
    private GameObject dollReference;
    private GameObject miniature;
    private void Start()
    {
        Created?.Invoke();
        dollReference = Instantiate(dollInstance);
        dollReference.GetComponent<DollScript>().Create();
        dollReference.GetComponent<DollScript>().buttonObject = this.gameObject;
        dollReference.transform.position = new Vector3(0,1,0);
        BuildMiniature();
        dollReference.SetActive(false);
    }
    private void OnDestroy()
    {
        Destroyed?.Invoke();
    }
    public void BuildMiniature()
    {
        miniature = Instantiate(dollReference, transform);
        Destroy(miniature.GetComponent<Animator>());
        foreach (Transform t in miniature.transform)
        {
            Destroy(t.GetComponent<Joint>());
            Destroy(t.GetComponent<BoxCollider2D>());
        }
        Destroy(miniature.GetComponent<DollScript>());
        miniature.transform.localPosition = Vector3.zero;
        miniature.transform.localScale = new Vector3(25, 25, 1);
    }
    public void Clicked()
    {
        DollScript[] ds= FindObjectsOfType<DollScript>();
        UI_DollButton[] uiDoll = FindObjectsOfType<UI_DollButton>();
        foreach(UI_DollButton ui in uiDoll)
        {
            if (ui.miniature!=null)
            {
                Destroy(ui.miniature);
                ui.BuildMiniature();
                ui.miniature.SetActive(true);
            }
        }
        foreach (DollScript d in ds)
        {
            d.gameObject.SetActive(false);
        }
        if (dollReference!=null)
        {
            dollReference.transform.position = new Vector3(0, 1, 0);
            dollReference.SetActive(true);
            miniature.SetActive(false);
        }
    }
}
