using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomScript : MonoBehaviour
{
    public float speedRotation = 0.2f;
    private float yRotate = 0;
    private float minAngle = -15f;
    private float maxAngle = 15f;
    private void Update()
    {
        yRotate += Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime;
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(0, yRotate, 0);
    }
}
