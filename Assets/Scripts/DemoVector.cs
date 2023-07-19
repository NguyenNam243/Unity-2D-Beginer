using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoVector : MonoBehaviour
{
    public Transform target = null;
    public float lerpValue = 0.03f;



    private void Update()
    {
        float angle = Vector2.SignedAngle(transform.up, target.position - transform.position);
        Debug.Log(angle);
    }
}
