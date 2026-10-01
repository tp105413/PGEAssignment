using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isWaveRunning = false;
    public bool isHoldingItem = false;

    public int level = 0;
    public int sunCount = 100;
    public int enemyCount = 3;

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
    }

    void StartWave()
    {
        isWaveRunning |= true;
    }

}
