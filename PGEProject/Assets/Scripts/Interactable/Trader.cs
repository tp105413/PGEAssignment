using UnityEngine;

public class Trader : Interactable
{
    public enum TraderType
    {
        Pawn,
        Rook,
        Bishop
    }

    public GameObject towerTypePrefab;
    public int towerCost;

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
        if(GameManager.Instance.sunCount >= towerCost)
        {
            GameManager.Instance.SpendSun(towerCost);
            GameManager.Instance.isHoldingItem = true;
            playerInteract.SetTowerPrefab(towerTypePrefab);
        }
    }

    public override bool CanInteract()
    {
        // Check if player is not holding item
        return !GameManager.Instance.isHoldingItem;
    }
}
