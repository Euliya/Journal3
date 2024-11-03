using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius;
    public float speed;
    float angle;
    public float ASpeed;
    Vector3 center;

    // Start is called before the first frame update
    void Start()
    {
        center= transform.position;
        angle=90*Mathf.Deg2Rad;
        transform.position += new Vector3(0, radius, 0);
    }

    // Update is called once per frame
    void Update()
    {
        radius += speed*Time.deltaTime;
        angle += ASpeed*Time.deltaTime;
        transform.position = center+radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0);
    }
}
