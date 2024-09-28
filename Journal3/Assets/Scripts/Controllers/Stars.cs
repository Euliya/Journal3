using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    Vector3 endpoint;
    int index = 0;

    private void Start()
    {
       endpoint = starTransforms[0].position; 
    }
    
    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        
        endpoint += (starTransforms[index+1].position - starTransforms[index].position)/drawingTime*Time.deltaTime;
        Debug.DrawLine(starTransforms[index].position,endpoint);
        if (Vector3.Distance(endpoint,starTransforms[index+ 1].position)<0.1 ) 
        {
            index=(index+1)%10;
        }

    }
}
