using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed; // speed of the enemy
    [SerializeField] private float damage; // damage of the enemy
    [SerializeField] private float atkCD; // cd for attack
    private float atkCDTimer; // to count the time that has passed
    private Transform player; // reference of player for the enemy to move towards player

    [Header("Gun")]
    [SerializeField] private Transform firePoint; // where the projectile would spawn
    [SerializeField] private GameObject bullet; // actual bullet to spawn/shoot

    // Start is called before the first frame update
    void Start()
    {
        // actually finds transform component of the player so move towards their location
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // move towards player position, at certain speed
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = direction;

        if (Time.time > atkCDTimer) // if enough time has passed for cd to be up
        {
            atkCDTimer = Time.time + atkCD; // increment the time up by the CD to be check with in-game time later
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the enemy touches a player, player take damage
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.tag == "Base")
        {
            // do damage to base and explode
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
