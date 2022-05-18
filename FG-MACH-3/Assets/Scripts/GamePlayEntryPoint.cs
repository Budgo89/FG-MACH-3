using Controllers;
using UnityEngine;

public class GamePlayEntryPoint : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private MainGamePlayController _gamePlayController;

    public void Awake()
    {
        _gamePlayController = new MainGamePlayController(_camera);
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
