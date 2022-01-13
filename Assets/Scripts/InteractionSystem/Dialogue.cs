using UnityEngine;

public class Dialogue : MonoBehaviour,IInteractable<GameObject>
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
        string _instigatorName;

        if (instigator.TryGetComponent(out PlayerData playerData))
        {
            _instigatorName = playerData.Name;
        }
        else
        {
            Debug.Log("Instigator has no Name");
            return;
        }
        Debug.Log("Start Dialogue with " + instigator.GetComponent<PlayerData>().Name); //TODO: DialogueSystem
    }
}
