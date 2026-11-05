using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar; 

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        Debug.Log("Sua Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Pirata Morreu!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}