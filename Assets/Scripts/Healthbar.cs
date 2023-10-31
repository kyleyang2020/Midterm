using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    void Start()
    {
        // set total health to current health
        // able to get currentHealth because of currentHealth { get; private set; } in health script
        totalHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    void Update()
    {
        // refreshing current health every frame
        currentHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }
}
