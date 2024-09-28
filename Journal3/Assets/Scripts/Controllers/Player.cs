using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float speed;
    public float maxSpeed;
    public float acceTime;
    float acceleration;

    void Update()
    {
        PlayerMovement();

    }

    public void PlayerMovement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.up;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.down;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;

        }

        if (direction == Vector3.zero)
        {
            speed = 0;

        }
        else
        {
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
            else
            {
                speed += acceleration * Time.deltaTime;
            }
        }
        
        transform.position += direction.normalized * speed * Time.deltaTime;

        acceleration = maxSpeed / acceTime;
      
        

        
    }
}
