using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [Header("Stats for Bullet (Player)")]
    [SerializeField] private float speed; // speed of projectile
    [SerializeField] public int damage; // damage of projectile

    // Update is called once per frame
    void Update()
    {
        // moves the bullet fowards depending on speed
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the projectile hit is an enemy they take damage
        // grab health component of enemy collision and do take damage function on it
        // then remove the bullet that hit
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
