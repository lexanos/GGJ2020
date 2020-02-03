using System.Collections;
using UnityEngine;



public class JointPoint : MonoBehaviour
{
    public BodyParts part = BodyParts.Part;
    public string ID = "";
    private string bodyID = "";
    private DollScript dollScript;
    private void OnEnable()
    {
        dollScript = transform.GetComponentInParent<DollScript>();
    }
    public void PlacePart()
    {
        if (ID != bodyID)
        {
            dollScript.evil = true;
            print("wrong");
        }
        else
        {
            print("good");
        }
        dollScript.Substract();
        Destroy(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Part")
        {
            if (collision.GetComponent<BodyPart>() != null)
                collision.GetComponent<BodyPart>().Place(ID, transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Part")
        {
            if (collision.GetComponent<BodyPart>() != null)
                collision.GetComponent<BodyPart>().Place(ID);
        }
    }
    public void SetID(string id)
    {
        bodyID = id;
    }

}
