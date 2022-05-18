using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    internal class MainGamePlayController : BaseController
    {
        private Camera _camera;
        private Transform _placeForUi;
        private List<GameObject> _balloons;

        private readonly GamePlayController _gamePlayController;
        private readonly GamePlayUiController _gamePlayUiController;

        public MainGamePlayController(Camera camera, Transform placeForUi)
        {
            _camera = camera;
            _placeForUi = placeForUi;
            _balloons = new List<GameObject>();

            _gamePlayController = new GamePlayController(_camera, _balloons);
            _gamePlayUiController = new GamePlayUiController(_placeForUi, _balloons);
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
