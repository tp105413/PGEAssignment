using UnityEngine;

public class Trader : Interactable
{
    public GameObject towerTypePrefab;
    public int towerCost;
    public string towerType;

    public PlayerInteract playerInteract;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        // Buy tower from trader
        if(GameManager.Instance.sunCount >= towerCost)
        {
            GameManager.Instance.SpendSun(towerCost);
            GameManager.Instance.isHoldingItem = true;
            playerInteract.SetTowerPrefab(towerTypePrefab);
            UIManager.Instance.ChangeHoldingItem(towerType);
        }
    }

    public override bool CanInteract()
    {
        // Check if player is not holding item
        return !GameManager.Instance.isHoldingItem;
    }
}
