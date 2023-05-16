using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FogController : MonoBehaviour
{
    public static FogController Instance { get; private set; }

    [SerializeField] private float StartFogValue = 0.03f;
    [SerializeField] private float MaxFogValue = 0.07f;
    [SerializeField] private float MinFogValue = 0.005f;
    [SerializeField] private float fogDensityMultiplier = 0.00001f;
    [SerializeField] private int MaxPollutionValue = 5000;
    [SerializeField] private int MinPollutionValue = -5000;

    private void Awake()
    {
        if (Instance != null && Instance != this)      
            Destroy(this);
        else
            Instance = this;
    }
    void Start()
    {
        RenderSettings.fogDensity = StartFogValue;
    }

    public void ChangeFogDensity()
    {
        RenderSettings.fogDensity += PlayerPrefs.GetInt("Pollution") * fogDensityMultiplier * 0.01f;

        if (PlayerPrefs.GetInt("Pollution") >= MaxPollutionValue)
        {
            StartCoroutine(GameOver());
        }
        if (PlayerPrefs.GetInt("Pollution") <= MinPollutionValue)
        {
            StartCoroutine(GameOver());
        }
    }
    private IEnumerator GameOver()
    {
        Time.timeScale = 0.0f;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
