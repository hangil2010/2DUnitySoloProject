using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform rotatePoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    // Start is called before the first frame update
    [Header("Atteribute")]
    [SerializeField] private float targetRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bulletPerSecond = 1f;

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            rotatePoint.rotation = Quaternion.RotateTowards(rotatePoint.rotation, Quaternion.Euler(new Vector3(0f, 0f, 0f)), rotationSpeed * Time.deltaTime);
            return;
        }

        RotateToTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bulletPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }
    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.SetTarget(target);
    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        rotatePoint.rotation = Quaternion.RotateTowards(rotatePoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool CheckTargetIsInRange() => Vector2.Distance(target.position, transform.position) <= targetRange;

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }

    
}
