using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDing : MonoBehaviour
{
    public AudioSource source;


    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Coin"))
        source.PlayOneShot(sound);
    
    }
}
