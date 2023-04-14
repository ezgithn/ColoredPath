using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public float breakForce = 10f;
    public KeyCode breakKey = KeyCode.LeftShift;


    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(breakKey) && collision.gameObject.CompareTag("Wall"))
        {
            if (collision.relativeVelocity.magnitude >= breakForce)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void Update()
    {
        
    }
}
