using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] 
    private Text ScoreText;
    private int _scoreNum;

    private void Awake()
    {
        SetText();
    }

    private void SetText()
    {
        ScoreText.text = "MyCoin " + _scoreNum;
    }

    private void OnTriggerEnter(Collider Coin)
    {
        if(Coin.CompareTag("CollectCoin"))
        {
            _scoreNum += 1;
            Destroy(Coin.gameObject);
            SetText();
        }
    }
}
