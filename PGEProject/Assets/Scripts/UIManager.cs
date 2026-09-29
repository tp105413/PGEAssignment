using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text sunCountText;


    void OnEnable()
    {
        GameManager.OnSunCountChanged += UpdateSunCount;
    }

    void OnDisable()
    {
        GameManager.OnSunCountChanged -= UpdateSunCount;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSunCount(int amount)
    {
        sunCountText.text = amount.ToString();
    }
}
