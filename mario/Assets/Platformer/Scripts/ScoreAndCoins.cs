using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAndCoins : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI coinText;

    private int _scoreCount = 0;
    private int _coinCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = _scoreCount.ToString("000000");
        coinText.text = $"x{_coinCount:00}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreIncrease()
    {
        _scoreCount += 100;
        scoreText.text = _scoreCount.ToString("000000");
    }

    public void CoinIncrease()
    {
        _coinCount += 1;
        coinText.text = $"x{_coinCount:00}";
    }
    public void CoinDecrease()
    {
        if(_coinCount > 0)
             _coinCount -= 1;
        coinText.text = $"x{_coinCount:00}";
    }
}
