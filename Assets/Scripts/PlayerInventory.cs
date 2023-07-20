using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }
 
    void Start()
    {
        
    }

   
    public void CoinCollected()
    {
        NumberOfCoins++;
    }
}
