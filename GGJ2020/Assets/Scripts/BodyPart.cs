using System.Collections;
using UnityEngine;

public enum BodyParts
{
    Part,
    Eye
}

public class BodyPart : MonoBehaviour
{
    public AudioClip clip;
    private Vector3 initialPosition;
    private BoxCollider2D boxCollider2D;
    private bool selected = false;
    public BodyParts part = BodyParts.Part;
    public string ID = "";
    private Vector2 collisionFix;
    public Vector3[] rotations;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        initialPosition = transform.position;
        if (ID != "Head")
            collisionFix = Vector2.one;//new Vector2(6, 1.2f);
        else
            collisionFix = Vector2.one;
        Invoke("SetCollider", 0.5f);
    }
   private void SetCollider()
    {
        boxCollider2D.size = collisionFix;
        CancelInvoke("SetCollider");
    }
    private void Update()
    {
        if (selected)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = newPos;
            boxCollider2D.size = Vector2.one;
        }
        if (Input.GetMouseButtonUp(0) && selected)
        {
            selected = false;
            boxCollider2D.size = collisionFix;
            Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.3f,1<<8);
            if (collider!=null)
            {
                JointPoint jp= collider.GetComponent<JointPoint>();
                if (jp!=null)
                {
                    if (jp.part == part)
                    {
                        if (SystemManager.Instance!=null)
                            SystemManager.Instance.PlaySound(clip);
                        transform.position = collider.transform.position;
                        SwitchRotation(jp.ID, collider.transform);
                        jp.SetID(ID);
                        jp.PlacePart();
                        Destroy(jp);
                        transform.GetComponentInParent<UI_PartsButtons>().BuildPart();
                        transform.SetParent(collider.transform);
                        Destroy(this);
                    }
                    else
                    {
                        transform.position = initialPosition;
                    }
                }
                else
                {
                    transform.position = initialPosition;
                }
            }
            else
            {
                transform.position = initialPosition;
            }
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    public void Place(string _id,Transform _transform = null)
    {
        if (_transform == null)
        {
            transform.eulerAngles = Vector3.zero;
            return;
        }
        else
        {
            transform.position = _transform.position;
            SwitchRotation(ID,transform);
        }
    }
    private void SwitchRotation(string _id, Transform _transform)
    {
        switch(ID)
        {
            case "LA":
                switch (_id)
                {
                    case "LA":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                    case "RA":
                        transform.eulerAngles = new Vector3(0, 0, -180);
                        break;
                    case "LL":
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                    case "RL":
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                    case "Head":
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                }
                break;
            case "RA":
                switch (_id)
                {
                    case "LA":
                        transform.eulerAngles = new Vector3(0, 0, -180);
                        break;
                    case "RA":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                    case "LL":
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                    case "RL":
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                    case "Head":
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                }
                break;
            case "LL":
                switch (_id)
                {
                    case "LA":
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                    case "RA":
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                    case "LL":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                    case "RL":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                    case "Head":
                        transform.eulerAngles = new Vector3(0, 0, 180);
                        break;
                }
                break;
            case "RL":
                switch (_id)
                {
                    case "LA":
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                    case "RA":
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                    case "LL":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                    case "RL":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                    case "Head":
                        transform.eulerAngles = new Vector3(0, 0, 180);
                        break;
                }
                break;
            case "Head":
                switch (_id)
                {
                    case "LA":
                        transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                    case "RA":
                        transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                    case "LL":
                        transform.eulerAngles = new Vector3(0, 0, 170);
                        break;
                    case "RL":
                        transform.eulerAngles = new Vector3(0, 0, 190);
                        break;
                    case "Head":
                        transform.eulerAngles = _transform.eulerAngles;
                        break;
                }
                break;
           
        }
    }
    public void Generated()
    {
        Destroy(this);
        CancelInvoke("SetCollider");
    }

}