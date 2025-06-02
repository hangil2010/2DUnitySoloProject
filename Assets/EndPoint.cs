using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private string loadSceneName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
