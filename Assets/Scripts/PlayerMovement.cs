using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimentação e Pulo")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Dano")]
    public int damageToEnemy = 1;
    public int damageFromEnemy = 10;

    private Rigidbody2D rb;
    private Animator animator;
    private HealthManager healthManager;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (healthManager != null)
            {
                healthManager.TakeDamage(damageFromEnemy);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TomaDano(damageToEnemy);
            }
        }
    }
}