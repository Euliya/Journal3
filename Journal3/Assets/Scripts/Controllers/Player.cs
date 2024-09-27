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

        transform.position += direction.normalized * speed * Time.deltaTime;

    }
}
