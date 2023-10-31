using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDamage : MonoBehaviour
{
    [SerializeField] private Sprite[] damageSprites; // holds all the variations of the sprites
    SpriteRenderer sprite;
    Health health;

    void Start()
    {
        health = GetComponent<Health>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = damageSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        // if health <= 4 change sprite, if health <= 2 change sprite
        if(health.currentHealth <= 4)
            sprite.sprite = damageSprites[1];
        else if(health.currentHealth <= 2)
            sprite.sprite = damageSprites[2];
    }
}
