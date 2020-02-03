using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeginWorkshop : MonoBehaviour
{
    public Text dayText;
    public GameObject parts;
    public CreateNewButtons buttons;
    private void Start()
    {
        dayText.text = "DIA "+DollsManager.Instance.days.ToString();
    }
    public void ActivateParts()
    {
        parts.SetActive(true);
        buttons.Spawn();
    }
}
