using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interactable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Implement the interaction logic for the specific object
        Debug.Log("Interacting with the object: " + gameObject.name);
    }
}