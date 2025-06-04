using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private string loadSceneName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(LoadScene(loadSceneName));
    }

    private IEnumerator LoadScene(string _sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(_sceneName);
    }
}
