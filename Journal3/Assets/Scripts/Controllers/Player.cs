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
    public int numberOfPowerups;
    public GameObject powerupPrefab;
    public float addSpeed;
    Coroutine speeding;
    List<float> ChangeRadius;
    List<float> radiusSpeed;

    private void Start()
    {
        ChangeRadius = new List<float>();
        radiusSpeed = new List<float>();
        StartCoroutine(Rbgn());
    }

    void Update()
    {
        PlayerMovement();
        EnemyRadar(radius,circlePoints);
        SpawnPowerups(radius, numberOfPowerups);
        Shoot();
        Rbg();
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

        if (Input.GetKeyDown(KeyCode.X) && speeding == null)
        {
                speeding=StartCoroutine(AddSpeed());
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
            if(Vector2.Distance(transform.position,enemyTransform.position)<radius)
            {
                color = Color.red;
            }
            else
            {
                color = Color.green;
            }
            color = Color.Lerp(Color.blue, color, r / radius);
            Debug.DrawLine(startP, endP,color);
            startP= endP;
        }


    }
    List<GameObject> pups = new List<GameObject>();

    public void SpawnPowerups(float r, int np)
    {
        foreach(GameObject pup in pups)
        {
            Destroy(pup);
        }
        for (int i = 1; i <= np; i++)
        {
            float angle = i * 360 / np * Mathf.Deg2Rad;
            Vector2 point = r * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) + (Vector2)transform.position;
            GameObject pup = Instantiate(powerupPrefab);
            pup.transform.position = point;
            pups.Add(pup);
        }
        
    }
    IEnumerator AddSpeed()
    {
        speed += addSpeed;
        maxSpeed += addSpeed;
        yield return new WaitForSeconds(0.5f);
        speed-=addSpeed;
        maxSpeed-=addSpeed;
        yield return new WaitForSeconds(3f);
        speeding = null;
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            GameObject bp=Instantiate(bombPrefab);
            bp.transform.position = transform.position;
        }
        
    }


    public void Rbg()
    {
        for(int i=0;i<ChangeRadius.Count;i++)
        {
            ChangeRadius[i] -= radiusSpeed[i] * Time.deltaTime;
            radiusSpeed[i] += 5f * Time.deltaTime;

            if(ChangeRadius[i] <= 0)
            {
                ChangeRadius.RemoveAt(i);
                radiusSpeed.RemoveAt(i);
            }
            else
            {
                EnemyRadar(ChangeRadius[i], circlePoints);
            }
        }
    }

    IEnumerator Rbgn()
    {
        while(true)
        {
            ChangeRadius.Add(radius);
            radiusSpeed.Add(2f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
