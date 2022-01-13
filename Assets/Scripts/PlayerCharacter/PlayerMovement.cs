using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody _playerRigidbody;

    [Header("Settings")]
    [SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _maxSpeed;

    private Camera _camera;
    private Vector2 _movedirection;
    private Vector3 _cameraForward;
    private Vector3 _cameraRight;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _camera = Camera.main;
    }

    private void Update()
    {
        _cameraForward = _camera.transform.forward;
        _cameraRight = _camera.transform.right;
        _cameraForward.y = 0;
        _cameraRight.y = 0;
    }

    private void FixedUpdate()
    {
        Vector3 direction = _cameraForward * _movedirection.y + _cameraRight * _movedirection.x;

        if(_playerRigidbody.velocity.magnitude < _maxSpeed)
        _playerRigidbody.velocity += (direction) * _acceleration * Time.fixedDeltaTime;

        if(direction != Vector3.zero)
        _playerRigidbody.MoveRotation(Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),0.35f));
    }

    public void OnMove(InputAction.CallbackContext context)
    {    
        _movedirection = context.ReadValue<Vector2>();      
    }
}
