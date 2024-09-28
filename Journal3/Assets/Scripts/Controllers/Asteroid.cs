using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 direction;
    Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        if (Vector2.Distance(transform.position,point)<=arrivalDistance)
        {
            direction = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            point = transform.position + direction * maxFloatDistance;
        }

    }
}
