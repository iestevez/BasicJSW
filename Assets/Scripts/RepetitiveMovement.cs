using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetitiveMovement : MonoBehaviour
{
    public Vector3 direction;
    public float distance;
    public float speed;
    public bool bActivate=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float delta = 0.0f;
        float newcovered = 0.0f;
        if (!bActivate)
            return;
        delta = speed * Time.deltaTime;
        newcovered = covered + delta;

        if (distance == covered)
        {
            newcovered = delta;
            going = -going;
            

        }
        

        if (distance < newcovered)
        {
            delta = distance - covered;
            covered = distance;
        }
        else
            covered =newcovered;

       
        transform.position += transform.TransformDirection(Vector3.Normalize(direction)) * delta*going;



        

    }

    private float covered = 0.0f;
    private int going = 1;

    
   
}
