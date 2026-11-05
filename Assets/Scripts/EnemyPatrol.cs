using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform wayPointA;
    public Transform wayPointB;
    
    private Transform currentTarget;
    private bool isDead = false;

    void Start()
    {
        currentTarget = wayPointA;
    }

    void Update()
    {
        if (isDead) return;
        if (wayPointA == null || wayPointB == null) return;

        Vector2 posicaoAtual2D = new Vector2(transform.position.x, transform.position.y);
        Vector2 posicaoAlvo2D = new Vector2(currentTarget.position.x, currentTarget.position.y);

        transform.position = Vector2.MoveTowards(posicaoAtual2D, posicaoAlvo2D, speed * Time.deltaTime);

        float distancia = Vector2.Distance(posicaoAtual2D, posicaoAlvo2D);

        if (distancia < 0.2f)
        {
            if (currentTarget == wayPointA)
            {
                currentTarget = wayPointB;
            }
            else
            {
                currentTarget = wayPointA;
            }
        }
    }

    public void Die()
    {
        isDead = true;
    }
}