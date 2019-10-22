using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LimitedFloor : MonoBehaviour {

    public GameObject limitedFloor;
    public GameObject actor;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {

        computeBounds();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(actor==null)
            return;

        Vector3 position = actor.transform.position;
        if(isOutMaxZ())
            position.z = limits.max.z;
        if(isOutMinZ())
            position.z = limits.min.z;
        if(isOutMaxX())
            position.x = limits.max.x;
        if(isOutMinX())
            position.x = limits.min.x;
        
        actor.transform.position = position;

		
	}

   private void computeBounds()
    {
        
        Vector3 min=default(Vector3);
        Vector3 max=default(Vector3);
        Component[] colliders = limitedFloor.GetComponentsInChildren(typeof(MeshCollider));
        if(colliders != null)
        {
            foreach(Collider collider in colliders)
            {
                
                
                if (min.x > collider.bounds.min.x)
                    min.x = collider.bounds.min.x;
                if (min.y > collider.bounds.min.y)
                    min.y = collider.bounds.min.y;
                if (min.z > collider.bounds.min.z)
                    min.z = collider.bounds.min.z;
                if (max.x < collider.bounds.max.x)
                    max.x = collider.bounds.max.x;
                if (max.y < collider.bounds.max.y)
                    max.y = collider.bounds.max.y;
                if (max.z < collider.bounds.max.z)
                    max.z = collider.bounds.max.z;


            }
        }
        limits.SetMinMax(min, max);
       

    }

    private bool isOutMaxZ(){
        if(actor==null)
            return true;
        return actor.transform.position.z>limits.max.z;

    }
        private bool isOutMinZ(){
        if(actor==null)
            return true;
        return actor.transform.position.z<limits.min.z;

    }
    private bool isOutMaxY(){
        if(actor==null)
            return true;
        return actor.transform.position.y>limits.max.y;

    }
        private bool isOutMinY(){
        if(actor==null)
            return true;
        return actor.transform.position.y<limits.min.y;

    }
    private bool isOutMaxX(){
        if(actor==null)
            return true;
        return actor.transform.position.x>limits.max.x;

    }
        private bool isOutMinX(){
        if(actor==null)
            return true;
        return actor.transform.position.x<limits.min.x;

    }

    private Bounds limits;
    

    
     
}