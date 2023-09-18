using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;


    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debug
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
            level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {if (tag == "Breakable")
        {
            HandleHit();

        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
            DestroyBlock();
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit-1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("BLock sprite is missing from array" + gameObject.name);
    }

    private void DestroyBlock()
    {
        PlayingBreakSound();
        Destroy(gameObject);
        level.BlockDestroyed();
        triggerSparklesVFX();
    }

    private void PlayingBreakSound()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void triggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
