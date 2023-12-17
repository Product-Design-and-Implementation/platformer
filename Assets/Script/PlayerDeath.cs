using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
       
        if (deathSoundEffect != null)
        {
            deathSoundEffect.Play();
        }

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        // Restart the level after a delay (adjust the delay time as needed)
        StartCoroutine(RestartLevelAfterDelay(2.0f));
    }

    private IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
