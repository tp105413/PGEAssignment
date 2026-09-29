using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isWaveRunning = false;

    public int level = 1;
    public int sunCount = 0;

    public static event Action<int> OnSunCountChanged;


    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
