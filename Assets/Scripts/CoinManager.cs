using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayCoinCollectSound();
            Destroy(gameObject);
            DataManager.Instance.CoinCollected++;
        }
    }
    private void PlayCoinCollectSound()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }
}