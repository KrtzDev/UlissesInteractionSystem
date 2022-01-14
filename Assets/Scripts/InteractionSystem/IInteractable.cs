public interface IInteractable<T>
{
    /// <summary>
    /// Implement your specific interaction logic here.
    /// </summary>
    /// <param name="instigator">The instigator of the interaction</param>
    void Interact(T instigator);
    /// <summary>
    /// Provide the PLayer with some short information about the interaction
    /// </summary>
    /// <returns>The returned string will be shown in the ingame UI, when the respective object is looked at.</returns>
    string GetInteractionInfo();
}
