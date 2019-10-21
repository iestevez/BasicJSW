using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject player;
    public float scaleMoveForward=10f;
    public float scaleTurnAction=10f;
    
    // Start is called before the first frame update
    void Awake(){
        rigidBody =player.GetComponent<Rigidbody>();
        transform = player.GetComponent<Transform>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate( )
    {

        // We are dealing with rigidboyd and forces (update )
        if(rigidBody==null)
            return;
        float moveForward=0.0f;
        float turn =0.0f;
        Vector3 eulerRotation;
        moveForward = scaleMoveForward*Input.GetAxis("Vertical");
        turn = scaleTurnAction*Input.GetAxis("Horizontal");
        //if(turn>0)
         //   rigidBody.velocity=new Vector3(0f,0f,0f);
        
            
        eulerRotation = new Vector3(0f,turn,0f);

        //rigidBody.AddRelativeForce(0f,0f,moveForward);
        //rigidBody.AddRelativeTorque(0f,turn,0f);
        transform.Rotate(eulerRotation);

        transform.position+=moveForward*transform.forward;


    }

    private Rigidbody rigidBody;
    private Transform transform;

}
