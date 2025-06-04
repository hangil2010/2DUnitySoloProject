using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class FreezeTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject freezeEffectPrefab;
    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float attacksPerSecond = 0.25f;
    [SerializeField] private float slowSpeed = 0.25f;
    [SerializeField] private float freezeTime = 1f;
    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / attacksPerSecond)
        {
            Freeze();
            timeUntilFire = 0f;
        }
    }

    private void Freeze()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            Instantiate(freezeEffectPrefab, transform.position, Quaternion.identity);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                EnemyMovement movement = hit.transform.GetComponent<EnemyMovement>();
                movement.SetSpeed(slowSpeed);
                StartCoroutine(ResetEnemySpeed(movement));
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement movement)
    {
        yield return new WaitForSeconds(freezeTime);
        movement.ResetSpeed();
    }

    private void OnDrawGizmosSelected()
    {
        //Handles.color = Color.cyan;
        //Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
