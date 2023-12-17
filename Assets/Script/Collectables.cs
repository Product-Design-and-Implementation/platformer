using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    private int bananas = 0;

    [SerializeField] private Text bananasText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("banana"))
        {
            if (collectionSoundEffect != null)
            {
                collectionSoundEffect.Play();
                collectionSoundEffect.time = 0f; // Reset audio playback position
            }
                
            Destroy(collision.gameObject);
            bananas++;

            if (bananasText != null)
            {
                bananasText.text = "Total Bananas: " + bananas;
            }
        }
    }
}
