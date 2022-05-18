using UnityEngine;

namespace Controllers
{
    internal class MainGamePlayController : BaseController
    {
        private Camera _camera;
        private GamePlayController _gamePlayController;

        public MainGamePlayController(Camera camera)
        {
            _camera = camera;
            _gamePlayController = new GamePlayController(_camera);
        }

        public void Update()
        {
            _gamePlayController.Update();
        }

        protected override void OnDispose()
        {
            _gamePlayController.Dispose();
        }
    }
}
