using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshButton : MonoBehaviour
{
    public UI_PartsButtons[] UI_Parts;
    private bool active = true;
    private float timer = 0;
    private float delay = 3;
    public Button button;

    public void Refresh()
    {
        active = false;
        button.interactable = false;
        for (int i = 0; i < UI_Parts.Length; i++)
            UI_Parts[i].Refresh();
    }

    private void Update()
    {
        if (!active)
        {
            timer += Time.deltaTime;
            if (timer>=delay)
            {
                active = true;
                button.interactable = true;
                timer = 0;
            }
        }
    }
}
