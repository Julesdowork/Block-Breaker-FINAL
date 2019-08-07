using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached ref
    Level level;

    // State variables
    [SerializeField] int timesHit;      // only serialized for debugging
    int maxHits;

    void Start()
    {
        maxHits = hitSprites.Length + 1;
        level = FindObjectOfType<Level>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<ScoreDisplay>().AddToScore();
        PlayDestroyFX();
        Destroy(gameObject);
        level.DestroyBlock();
    }

    private void PlayDestroyFX()
    {
        GameObject effect = Instantiate(sparklesVFX, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite " + gameObject.name + " is missing from array.");
        }
    }
}
