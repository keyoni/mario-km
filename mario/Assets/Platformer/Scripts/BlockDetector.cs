using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDetector : MonoBehaviour
{
    private Vector3 _mouseClick;

    public Camera raycastCamera;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MousePickingRaycast());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseClick = Input.mousePosition;
        }
    }

    // private void OnMouseDown()
    // { 
    //     _mouseClick = Input.mousePosition;
    //     Debug.Log($"{_mouseClick}");
    //     
    // }

    IEnumerator MousePickingRaycast()
    {
        while (true)
        {
            
            
            Ray ray = raycastCamera.ScreenPointToRay(_mouseClick);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
               
                
                switch (hitInfo.collider.tag)
                {
                    case "Brick":
                        Debug.Log($"hitInfo {hitInfo.collider.tag}");
                        GetComponent<ScoreAndCoins>().ScoreIncrease();
                        Destroy(hitInfo.collider.gameObject);
                        break;
                    case "Question":
                        GetComponent<ScoreAndCoins>().CoinIncrease();
                        
                        break;
                }

                _mouseClick = Vector3.one;
                //float l = 50f;
                // Debug.DrawLine(hitInfo.point+Vector3.left * l, hitInfo.point + Vector3.right* l, Color.magenta);
                // Debug.DrawLine(hitInfo.point+Vector3.up* l, hitInfo.point + Vector3.down* l, Color.magenta);
            }
            yield return null;
        }
    }
}
