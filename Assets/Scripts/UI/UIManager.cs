using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Canvas _mainCanvasPrefab;

    private Canvas _currentMainCanvas;

    private void Awake()
    {
        _currentMainCanvas = Instantiate(_mainCanvasPrefab,this.transform);
    }
}
