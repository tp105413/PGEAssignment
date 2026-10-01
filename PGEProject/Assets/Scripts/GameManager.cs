using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public EnemySpawner enemySpawner;

    public bool isWaveRunning = false;
    public bool isHoldingItem = false;

    public int level = 0;
    public int sunCount = 100;
    public int enemyCount = 3;
    public int enemyRemaining = 0;

    public static event Action<int> OnSunCountChanged;


    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnSunCountChanged?.Invoke(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            StartWave();
        }
    }

    public void AddSun()
    {
        sunCount += 25;
        OnSunCountChanged?.Invoke(sunCount);
    }

    public void SpendSun(int amount)
    {
        sunCount -= amount;
        OnSunCountChanged?.Invoke(sunCount);
    }

    public void GameOver()
    {
        isWaveRunning = false;
        level = 0;
        Time.timeScale = 0f;
        UIManager.Instance.GameOverUI();

        // Reset game here
    }

    void StartWave()
    {
        isWaveRunning = true;

        if(level == 0)
        {
            enemyRemaining = enemyCount;
            UIManager.Instance.UpdateGeneralUI();
        }
        else
        {
            enemyCount = 10 + (level * 5);
            enemyRemaining = enemyCount;

            // Every 2 level -2 secs spawn interval, minimum 2 secs
            enemySpawner.spawnInterval = Mathf.Max(16f - ((level - 1) / 2) * 2f, 2f);

            UIManager.Instance.UpdateGeneralUI();
        }
    }

    public void EnemiesDied()
    {
        enemyRemaining--;

        if(isWaveRunning && enemyCount <=0 && enemyRemaining <= 0)
        {
            WaveCleared();
        }
    }

    void WaveCleared()
    {
        isWaveRunning = false;
        level++;

        // Wave cleared UI add here
    }
}
