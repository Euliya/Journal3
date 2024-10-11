using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float radius;
    public float orbitalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, orbitalSpeed, planetTransform);
    }
    float angle = 0;
    public void OrbitalMotion(float r, float speed, Transform target)
    {
        angle += speed / r * Time.deltaTime;
        transform.position = new Vector3(r*Mathf.Cos(angle),r*Mathf.Sin(angle))+planetTransform.position;
    }
}
