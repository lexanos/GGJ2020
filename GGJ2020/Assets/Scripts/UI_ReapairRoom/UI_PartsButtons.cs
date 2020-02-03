using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PartsButtons : MonoBehaviour
{
    public GameObject[] parts;
    private void Start()
    {
        BuildPart();
    }
    public void BuildPart()
    {
        int index = Random.Range(0, parts.Length);
        GameObject go= Instantiate(parts[index], transform.position,Quaternion.identity);
        go.transform.SetParent(transform);
    }
    public void Refresh()
    {
        BodyPart bp = GetComponentInChildren<BodyPart>();
        Destroy(bp.gameObject);
        BuildPart();
    }

}
