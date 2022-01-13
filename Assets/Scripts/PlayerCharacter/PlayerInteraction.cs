using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float maxInteractionDistance;

    private Camera _camera;
    private RaycastHit _interactionHit;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        InteractionRayHit();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_interactionHit.transform.TryGetComponent(out IInteractable<GameObject> interactable))
            {
                interactable.Interact(this.gameObject);
            }
        }
    }

    void InteractionRayHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.ViewportPointToRay(Vector3.one / 2f), out hit, maxInteractionDistance))
        {
            _interactionHit = hit;
            if (_interactionHit.transform.TryGetComponent(out IInteractable<GameObject> interactable))
            {
                Debug.Log(interactable.GetInteractionInfo()); //TODO: send Interaction info to UI-Element
            }
        }
    }
}
