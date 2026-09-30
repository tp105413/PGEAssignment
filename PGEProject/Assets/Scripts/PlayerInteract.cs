using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float distance = 3f;
    public LayerMask mask;
    public GameObject prefabTemp;

    public UIManager uImanager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uImanager.UpdatePromptText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (interactable.CanInteract())
                {
                    // If can interact will prompt message
                    uImanager.UpdatePromptText(interactable.promptMessage);

                    // Left click to interact
                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        interactable.BasicInteract(prefabTemp, hitInfo.point);
                        //Instantiate(prefabTemp, hitInfo.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}
