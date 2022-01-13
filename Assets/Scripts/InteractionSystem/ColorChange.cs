using UnityEngine;

public class ColorChange : MonoBehaviour, IInteractable<GameObject>
{
    [Header("Settings")]
    [SerializeField]
    private string _interactionInfo = "Interact";

    public string GetInteractionInfo()
    {
        return _interactionInfo;
    }

    public void Interact(GameObject instigator)
    {
        if (TryGetComponent(out MeshRenderer renderer))
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
