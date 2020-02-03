using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewButtons : MonoBehaviour
{
    public GameObject buttonObject;
    public List<UI_DollButton> dollButtons = new List<UI_DollButton>();

    private void Start()
    {
        if (DollsManager.Instance!=null)
        {
            for (int i=0;i<DollsManager.Instance.rest;i++)
            {
                Instantiate(buttonObject, transform);
            }
        }
        AdjustList();
    }
    private void AdjustList()
    {
        UI_DollButton[] dolls = FindObjectsOfType<UI_DollButton>();
        for (int i = 0; i < dolls.Length; i++)
        {
            dollButtons.Add(dolls[i]);
        }
    }
    public void Spawn()
    {
        dollButtons[0].Clicked();
    }
    public void RemoveButton(UI_DollButton btn)
    {
        dollButtons.Remove(btn);
        AdjustList();
        Spawn();

    }
}
