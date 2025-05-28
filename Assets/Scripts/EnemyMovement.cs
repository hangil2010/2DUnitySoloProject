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

    private Transform target;
    private int pathIndex = 0;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= nextPointDistiance)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.OnEnemyDestoryed?.Invoke();
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
}
