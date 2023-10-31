using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // variables for starting and current health
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // allows other scripts to access the currentHealth script
    [SerializeField] private bool isPlayer; // conitional for player

    private void Awake()
    {
        // assigning variables, setting current health
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        // remove health equal to damage
        currentHealth -= _damage;

        // if player is dead
        if(isPlayer & currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        // if enemy is dead
        else if(currentHealth <= 0)
        {
            ScoreScript.scoreCount++;
            Destroy(gameObject);
        }
    }
}