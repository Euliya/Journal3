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
    public float deceTime;
    float deceleration;
    Vector3 velocity;
    int lastCount = 0;


    void Update()
    {
        PlayerMovement();

    }
    
    public void PlayerMovement()
    {
        Vector3 direction = Vector3.zero;
        int count=0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.up;
            count++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.down;
            count++;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
            count++;    
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
            count++;
        }
        if (count==0)
        {
            if (lastCount > 0)
            {
                deceleration = speed / deceTime;
            }
            direction = velocity;

            if(speed <= 0)
            {
                speed = 0;
            }
            else
            {
                speed -= deceleration * Time.deltaTime;
            }
        
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
        lastCount = count;
        velocity = direction.normalized * speed;
        transform.position += velocity * Time.deltaTime;

        acceleration = maxSpeed / acceTime;

        
    }
}
