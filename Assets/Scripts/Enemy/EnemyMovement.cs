using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rigid;
    [Header("Attributes")]
    [SerializeField] private float nextPointDistiance = 0.1f;
    [SerializeField] private float moveSpeed = 2f;

    private float baseSpeed;
    private Transform target;
    private int pathIndex = 0;
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
        baseSpeed = moveSpeed;
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= nextPointDistiance)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.path.Length)
            {
                SpawnManager.OnEnemyDestroyed?.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rigid.velocity = direction * moveSpeed;
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
