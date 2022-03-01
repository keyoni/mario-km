using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCoin : MonoBehaviour
{
    private Vector3 _startPoint;
    private Vector3 _currentPoint;
    public float changeNum = 0.01f;
    public float maxNum = 0.05f;
    private float _counter = 0f;
    private bool _up;

    private void Start()
    {
        _startPoint = GetComponent<Transform>().position;
        _currentPoint = _startPoint;
    }

    // Update is called once per frame
    void Update()
    {
      
       
        if (_counter < maxNum && _up)
        { 
            _counter += Time.deltaTime/2;
            _currentPoint.y += changeNum;
            
            _up = true;
        }
        else if (_counter > maxNum && _up)
        {
            _counter = 0;
            _up = false;
            _currentPoint.y -= changeNum;
        }
        else if (_currentPoint.y <= _startPoint.y)
        {
            _up = true;
            _currentPoint.y += changeNum;
        }
        else
        {
            _currentPoint.y -= changeNum;
        }
        transform.position = _currentPoint;
    }
}