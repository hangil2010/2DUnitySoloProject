using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    [Header("References")]
    public Transform startPoint;
    public Transform[] path;
    [SerializeField] private TextMeshProUGUI pauseButtonText;
    [SerializeField] private Image pauseImage;
    [SerializeField] AudioSource BGM;
    [Header("Atteributes")]
    public int currency;
    

    public bool isPaused = false;

    private void Awake() => main = this;

    private void Start() => currency = 100;

    public void IncreaseCurrency(int amount) => currency += amount;

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("돈 없다.");
            return false;
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        string pauseText = isPaused ? "Start" : "Pause";
        float _timeScale = isPaused ? 0f : 1f;
        Time.timeScale = _timeScale;
        pauseButtonText.text = pauseText;
        if (isPaused) BGM.Pause();
        else BGM.UnPause();
        pauseImage.gameObject.SetActive(isPaused);
    }
}
