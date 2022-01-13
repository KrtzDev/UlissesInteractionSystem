using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Start Dialogue with " + instigator.GetComponent<PlayerData>().Name); 
                                        //TODO: Deactivate Movement
                                        //TODO: Simple Dialogue
    }
}
