using UnityEngine;

public class Trader : Interactable
{
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
        if(GameManager.Instance.sunCount >= 200)
        {
            // Buy Pawn Tower
            GameManager.Instance.SpendSun(200);
            GameManager.Instance.isHoldingItem = true;
        }
    }

    public override bool CanInteract()
    {
        // Check if player is not holding item
        return !GameManager.Instance.isHoldingItem;
    }
}
