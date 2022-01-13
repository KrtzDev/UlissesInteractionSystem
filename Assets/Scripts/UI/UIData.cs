using UnityEngine;
using TMPro;

public class UIData : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TMP_Text _interactionInfoTextField;

    public TMP_Text InteractionInfoTextField { get => _interactionInfoTextField; set => _interactionInfoTextField = value; }
}
