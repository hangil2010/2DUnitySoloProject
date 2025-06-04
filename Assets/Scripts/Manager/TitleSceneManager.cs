using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator transition;
    [SerializeField] private AudioSource backgroundSound;
    [Header("Atteributes")]
    [SerializeField] private float transitionTime = 1f;

    private void Awake() => backgroundSound.Play();
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    IEnumerator LoadLevel(string _sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        backgroundSound.Stop();
        SceneManager.LoadScene(_sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
