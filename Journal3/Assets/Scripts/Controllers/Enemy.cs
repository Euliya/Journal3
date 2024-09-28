using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player;
    float speed = 0;

    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        if(Vector3.Distance(transform.position, player.position)<=5)
        {
            speed = 10;
        }
        else if (Vector3.Distance(transform.position, player.position) >= 10)
        {
            speed = 0;
        }
        transform.position += (transform.position - player.position).normalized * speed * Time.deltaTime;
    }

}
