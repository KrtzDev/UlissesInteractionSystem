public interface IInteractable<T>
{
    void Interact(T instigator);
    string GetInteractionInfo();
}
