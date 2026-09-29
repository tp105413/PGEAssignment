using UnityEngine;

public class BuildZone : Interactable
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
        // Interact actions
        GameManager.Instance.AddSun();
    }

    public override bool CanInteract()
    {
        // Check if player is holding item
        return GameManager.Instance.isHoldingItem;
    }
}
