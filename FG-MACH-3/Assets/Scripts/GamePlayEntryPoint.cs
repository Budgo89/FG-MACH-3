using Controllers;
using UnityEngine;

public class GamePlayEntryPoint : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _placeForUi;

    private MainGamePlayController _gamePlayController;

    public void Awake()
    {
        _gamePlayController = new MainGamePlayController(_camera, _placeForUi);
    }

    public void Update()
    {
        _gamePlayController.Update();
    }
    private void OnDestroy()
    {
        _gamePlayController.Dispose();
    }
}
