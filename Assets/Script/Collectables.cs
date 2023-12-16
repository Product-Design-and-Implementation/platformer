using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    private int bananas = 0;

    [SerializeField] private Text bananaText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("banana"))
        {
            if (collectionSoundEffect != null)
            {
                collectionSoundEffect.Play();
            }

            Destroy(collision.gameObject);
            bananas++;

            if (bananaText != null)
            {
                bananaText.text = "Total Bananas: " + bananas;
            }
        }
    }
}
