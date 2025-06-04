using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AreaTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject AreaEffectPrefab;
    
    [Header("Attribute")]
    [SerializeField] private float targetRange = 5f;
    [SerializeField] private float bulletPerSecond = 1f;
    [SerializeField] private int damage = 1;

    private float timeUntilFire;
    private List<Transform> targetsInRange = new();

    private void Update()
    {
        FindTargets();

        if (targetsInRange.Count == 0) return;

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / bulletPerSecond)
        {
            AttackTargets();
            timeUntilFire = 0f;
        }
    }

    private void FindTargets()
    {
        targetsInRange.Clear();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);
        foreach (RaycastHit2D hit in hits)
        {
            targetsInRange.Add(hit.transform);
        }
    }

    private void AttackTargets()
    {
        Instantiate(AreaEffectPrefab, transform.position, Quaternion.identity);
        foreach (Transform target in targetsInRange)
        {
            Health health = target.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Handles.color = Color.cyan;
        //Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }
}
