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

    public GameObject player;
    private  Ray _playerRay;
    private bool _playerHitBlock = false;
    float castDistance;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MousePickingRaycast());
        
        castDistance = player.GetComponent<Collider>().bounds.extents.y + 0.1f;
        
        //StartCoroutine(CharacterBlockFinder());
    }

    private IEnumerator CharacterBlockFinder()
    {
        while (true)
        {
            //Ray ray = new Ray(player.transform.position, Vector3.up);
            if (Physics.Raycast(_playerRay, out RaycastHit hitInfo))
            {
                Debug.Log($"hitInfo {hitInfo.collider.tag}");
                switch (hitInfo.collider.tag)
                {
                    case "Brick":
                        Debug.Log($"hitInfo {hitInfo.collider.tag}");
                        GetComponent<ScoreAndCoins>().ScoreIncrease();
                        Destroy(hitInfo.collider.gameObject);
                        break;
                    case "Question":
                        Debug.Log($"hitInfo {hitInfo.collider.tag}");
                        GetComponent<ScoreAndCoins>().CoinIncrease();

                        break;
                }
            }



        }

    }

    // Update is called once per frame
    void Update()
    {
        _playerRay = new Ray(player.transform.position, Vector3.up);
        
        _playerHitBlock = Physics.Raycast(_playerRay,out RaycastHit hitInfo,castDistance);
        if (_playerHitBlock)
        {
            Debug.Log($"hitInfo {hitInfo.collider.tag}");
            switch (hitInfo.collider.tag)
            {
                case "Brick":
                    Debug.Log($"hitInfo {hitInfo.collider.tag}");
                    GetComponent<ScoreAndCoins>().ScoreIncrease();
                    Destroy(hitInfo.collider.gameObject);
                    break;
                case "Question":
                    Debug.Log($"hitInfo {hitInfo.collider.tag}");
                    GetComponent<ScoreAndCoins>().CoinIncrease();

                    break;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Mario hit {collision.gameObject.name}");
        if (collision.collider.CompareTag("Coin"))
        {
            GetComponent<ScoreAndCoins>().ScoreIncrease();
            GetComponent<ScoreAndCoins>().CoinIncrease();
            Destroy(collision.gameObject);
        }
        
    }

    // private void OnMouseDown()
        // { 
        //     _mouseClick = Input.mousePosition;
        //     Debug.Log($"{_mouseClick}");
        //     
        // }

        /*IEnumerator MousePickingRaycast()
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
    }*/

}
