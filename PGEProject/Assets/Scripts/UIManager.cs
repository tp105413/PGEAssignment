using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text sunCountText;
    public TMP_Text enemyCountText;
    public TMP_Text levelText;
    public TMP_Text promptText;
    public TMP_Text gameOverText;
    public TMP_Text winText;
    public Button mainMenuButton;

    // Wave cleared UI
    public CanvasGroup waveClearedText;

    public GameObject itemHolded;
    public Material PawnMaterial;
    public Material RookMaterial;
    public Material BishopMaterial;


    void OnEnable()
    {
        GameManager.OnSunCountChanged += UpdateSunCount;
    }

    void OnDisable()
    {
        GameManager.OnSunCountChanged -= UpdateSunCount;
    }

    void Awake()
    {
        Instance = this;
    }

    void UpdateSunCount(int amount)
    {
        sunCountText.text = amount.ToString();
    }

    public void UpdatePromptText(string message)
    {
        promptText.text = message;
    }

    public void ChangeHoldingItem(string item)
    {
        if(item == "Pawn")
        {
            itemHolded.GetComponent<Renderer>().material = PawnMaterial;
            itemHolded.SetActive(true);
        }
        else if(item == "Rook")
        {
            itemHolded.GetComponent<Renderer>().material = RookMaterial;
            itemHolded.SetActive(true);
        }
        else if(item == "Bishop")
        {
            itemHolded.GetComponent<Renderer>().material = BishopMaterial;
            itemHolded.SetActive(true);
        }
    }

    public void GameOverUI()
    {
        gameOverText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public void WinUI()
    {
        winText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public void UpdateLevelText()
    {
        if(GameManager.Instance.level == 0)
        {
            // Show tutorial if start the game first time
            Tutorial();
        }
        else
        {
            levelText.text = "Lv." + GameManager.Instance.level;
        }
    }

    public void UpdateEnemyRemaining()
    {
        if (GameManager.Instance.level == 0)
        {
            enemyCountText.text = GameManager.Instance.enemyRemaining.ToString();
        }
        else
        {
            enemyCountText.text = GameManager.Instance.enemyRemaining.ToString();
        }
    }

    void Tutorial()
    {
        // Show tutorial
    }

    // Show wave cleared text with fade in and out
    public void waveClearedFade()
    {
        StartCoroutine(StartFade());
    }

    private IEnumerator StartFade()
    {
        yield return StartCoroutine(Fade(0f, 1f));
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float start, float end)
    {
        float timer = 0f;

        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            waveClearedText.alpha = Mathf.Lerp(start, end, timer / 0.5f);
            yield return null;
        }
        waveClearedText.alpha = end;
    }
}
