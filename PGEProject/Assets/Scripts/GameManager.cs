using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isWaveRunning = false;
    public bool isHoldingItem = false;

    public int level = 1;
    public int sunCount = 0;

    public static event Action<int> OnSunCountChanged;
    public static event Action OnItemChanged;


    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnSunCountChanged?.Invoke(200);
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
