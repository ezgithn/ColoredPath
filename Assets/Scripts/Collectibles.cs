using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    private float theScore;

    public float turnSpeed = 30f;
    public float destroyDelay = 0.5f; 
    public GameObject destroyEffect;


    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        theScore += 36;

        if (playerInventory != null)
        {
            playerInventory.CoinCollected();
            gameObject.SetActive(false);
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

    }

    public void Destroy()
    {
        if (destroyEffect != null) 
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject, destroyDelay); 
    }

    private void Update()
    {
        transform.Rotate(0.6f, 0.2f, turnSpeed * Time.deltaTime);
    }

}
