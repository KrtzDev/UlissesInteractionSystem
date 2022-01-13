using UnityEngine;

public class Kick : MonoBehaviour, IInteractable<GameObject>
{
    [Header("Settings")]
    [SerializeField]
    private string _interactionInfo = "Interact";

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Interact(GameObject instigator)
    {
        float kickForce;

        if(instigator.TryGetComponent(out PlayerData playerData))
        {
            kickForce = playerData.KickForce;
        }
        else
        {
            Debug.Log("Instigator can't kick");
            return;
        }

        Vector3 knockbackDirection = (this.transform.position - instigator.transform.position).normalized;

        _rigidbody.AddForce(knockbackDirection * kickForce);
    }

    public string GetInteractionInfo()
    {
        return _interactionInfo;
    }
}
