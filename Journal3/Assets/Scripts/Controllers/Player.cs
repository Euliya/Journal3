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
    public float radius;
    public int circlePoints;

    void Update()
    {
        PlayerMovement();
        EnemyRadar(radius,circlePoints);
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
    public void EnemyRadar(float r, int cp)
    {
        Vector2 startP = new Vector2(r, 0)+ (Vector2)transform.position;
        for(int i =1;i<=cp;i++)
        {
            float angle = i*360 / cp*Mathf.Deg2Rad;
            Vector2 endP = r*new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)) + (Vector2)transform.position;
            Color color;
            if(Vector2.Distance(transform.position,enemyTransform.position)<r)
            {
                color = Color.red;
            }
            else
            {
                color = Color.green;
            }
            Debug.DrawLine(startP, endP,color);
            startP= endP;
        }
    }

}
