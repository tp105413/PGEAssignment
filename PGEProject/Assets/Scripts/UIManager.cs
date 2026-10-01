using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text sunCountText;
    public TMP_Text promptText;
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
}
