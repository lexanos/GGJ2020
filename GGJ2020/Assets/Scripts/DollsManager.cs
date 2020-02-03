using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollsManager : MonoBehaviour
{
    public List<DollScript> dolls = new List<DollScript>();
    public int dollCounter = 0;
    public int evilCounter = 0;
    public static DollsManager Instance;
    public int rest = 0;
    public int days = 1;
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
    }

    public void AddDollCounter()
    {
        dollCounter++;
    }
    public void AddEvilDoll()
    {
        evilCounter++;
    }
    public void RemoveDollCounter()
    {
        dollCounter--;
        if (dollCounter == 0)
            FindObjectOfType<UI_Timer>().time = 0;
    }
  
}
