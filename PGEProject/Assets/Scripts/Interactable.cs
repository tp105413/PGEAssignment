using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Multiline(3)] public string promptMessage;

    public void BasicInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {

    }

    public virtual bool CanInteract()
    {
        return true;
    }
}
