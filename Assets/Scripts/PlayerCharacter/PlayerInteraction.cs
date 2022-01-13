using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField]
    private float _maxInteractionDistance;

    private Camera _camera;
    private TMP_Text _interactioninfoTextField;

    private void Start()
    {
        _camera = Camera.main;
        _interactioninfoTextField = FindObjectOfType<UIData>().InteractionInfoTextField;
    }

    private void Update()
    {
        InteractionRayHit();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(_camera.ViewportPointToRay(Vector3.one / 2f), out hit, _maxInteractionDistance))
            {
                if (hit.transform.TryGetComponent(out IInteractable<GameObject> interactable))
                {
                    interactable.Interact(this.gameObject);
                }
            }
        }
    }

    private void InteractionRayHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.ViewportPointToRay(Vector3.one / 2f), out hit, _maxInteractionDistance))
        {
            if (hit.transform.TryGetComponent(out IInteractable<GameObject> interactable))
            {
                _interactioninfoTextField.text = "LMB - " + interactable.GetInteractionInfo();
                _interactioninfoTextField.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                _interactioninfoTextField.transform.parent.gameObject.SetActive(false);
                _interactioninfoTextField.text = string.Empty;
            }
        }
        else
        {
            _interactioninfoTextField.transform.parent.gameObject.SetActive(false);
            _interactioninfoTextField.text = string.Empty;
        }
    }
}
