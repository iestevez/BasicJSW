using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    enum State { Live, Death };

    // Start is called before the first frame update
    public float energy = 100.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (energy <= 0)
            state = State.Death;
    }

    void OnCollisionEnter(Collision c)
    {
        GameObject obstacle = c.collider.gameObject;
        if (obstacle.tag == "Damager")
        {
            DamagerDefinition cs = obstacle.GetComponent<DamagerDefinition>();
            energy -= cs.damageAmount;
            print("Hit! " + energy);
        }
            
    }

    

    private State state = State.Live;

}
