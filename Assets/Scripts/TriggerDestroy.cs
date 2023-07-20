using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    public Collectibles objectToDestroy;
    int coins = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToDestroy.Destroy();
            coins++;

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
