using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _kickForce;

    public string Name { get => _name; set => _name = value; }
    public float KickForce { get => _kickForce; set => _kickForce = value; }
}
