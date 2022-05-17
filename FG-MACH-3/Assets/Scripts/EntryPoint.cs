using Controllers;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{

    [Header("Scene Objects")]
    [SerializeField] private Transform _placeForUi;

    private MainScreenController _mainScreenController;

    private void Awake()
    {
        _mainScreenController = new MainScreenController(_placeForUi);
    }

    private void OnDestroy()
    {
        _mainScreenController.Dispose();
    }
}
