using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Timer : MonoBehaviour
{
    private Text timerText;
    public float time = 60;
    private bool pepito = false;
    private int count = 0;
    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Start()
    {
        if (SystemManager.Instance != null)
            time = SystemManager.Instance.workshopTime;
    }
    private void OnEnable()
    {
        UI_DollButton.Destroyed += Destroyed;
        UI_DollButton.Created += Created;
    }
    private void OnDisable()
    {
        UI_DollButton.Destroyed -= Destroyed;
        UI_DollButton.Created -= Created;
    }
    private void Destroyed()
    {
        count--;
    }
    private void Created()
    {
        count++;
        pepito = true;
    }
    private void Update()
    {
        if (pepito)
        {
            if (count <= 0)
                time = 0;
            time -= Time.deltaTime;
            timerText.text = time.ToString("##");
            if (time <= 0)
            {
                time = 0;
                pepito = false;
                SceneManager.LoadScene("Bedroom", LoadSceneMode.Single);
            }
        }
    }

    public void SetPepito(bool value)
    {
        pepito = value;
    }
}
