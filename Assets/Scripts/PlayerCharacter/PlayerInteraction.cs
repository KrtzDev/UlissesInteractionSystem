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

    private void Start()
    {
        _camera = Camera.main;
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        RaycastHit hit;

        if(Physics.Raycast(_camera.ViewportPointToRay(Vector3.one/2f),out hit, maxInteractionDistance))
        {
            if (hit.transform.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
