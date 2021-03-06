using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Scripts
{
    public class Timer : MonoBehaviour
    {
        private TextMeshProUGUI _time;
        public TextMeshProUGUI gameOverText;
        public int maxTime = 400;
        private float _currentTime;
        // Start is called before the first frame update
        void Start()
        {
            _time = GetComponent<TextMeshProUGUI>();
            _time.text = maxTime.ToString();
            _currentTime = maxTime;
            gameOverText.gameObject.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {
            
                _currentTime -= Time.deltaTime;
                if (_currentTime < 0)
                {
                    _time.text = "000";
                    gameOverText.gameObject.SetActive(true);
                }
                else
                {
                    _time.text = _currentTime.ToString("000");

                    // if (_currentTime is < 100 and >= 10)
                    // {
                    //     _time.text = _currentTime.ToString("000");
                    // }
                    // else if (_currentTime <=9.99 )
                    // {
                    //     _time.text = $"00{_currentTime:0}";
                    // }
                    // else
                    // {
                    //     _time.text = $"{_currentTime:0}";
                    // }

                }

        }

   
    }
}
