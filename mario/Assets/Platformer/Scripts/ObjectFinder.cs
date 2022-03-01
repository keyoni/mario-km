using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    public GameObject gameSystem;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI ouchText;
    public AudioSource source;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        ouchText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Mario hit {collision.gameObject.name}");
        if (collision.collider.CompareTag("Coin"))
        {
            gameSystem.GetComponent<ScoreAndCoins>().ScoreIncrease();
            gameSystem.GetComponent<ScoreAndCoins>().CoinIncrease();
            source.PlayOneShot(sound);
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Goal"))
        {
            Destroy(collision.gameObject);
            winText.gameObject.SetActive(true);
        }
        if (collision.collider.CompareTag("Spike"))
        {
            Debug.Log($"Mario hit {collision.gameObject.name}");
            StartCoroutine(SpikeTextGo());
        }

        if (collision.collider.CompareTag("Brick"))
        {
            if (collision.collider.transform.position.y > transform.position.y)
            {
                Destroy(collision.gameObject);
                gameSystem.GetComponent<ScoreAndCoins>().ScoreIncrease();
            }
        }
        
    }

    private IEnumerator SpikeTextGo()
    {
        Debug.Log("OUCH");
        gameSystem.GetComponent<ScoreAndCoins>().CoinDecrease();
        ouchText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        ouchText.gameObject.SetActive(false);
    }
}

