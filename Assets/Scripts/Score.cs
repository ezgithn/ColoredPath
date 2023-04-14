using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text ScoreText;
    private int ScoreNum;


    void Start()
    {
        ScoreNum = 0;
        ScoreText.text = "MyCoin " + ScoreNum;

    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Coin)
    {
        if(Coin.tag == "CollectCoin")
        {
            ScoreNum += 1;
            Destroy(Coin.gameObject);
            ScoreText.text = "MyCoin" + ScoreNum;
        }
    }

}
