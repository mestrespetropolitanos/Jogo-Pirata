using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int vida = 3;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomaDano(int quantidade)
    {
        vida -= quantidade;
        Debug.Log("Inimigo levou dano " + vida);

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Matou Inimigo");
        Destroy(gameObject);
    }
}