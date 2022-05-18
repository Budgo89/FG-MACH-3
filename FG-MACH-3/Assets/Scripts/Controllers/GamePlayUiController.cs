using System.Collections.Generic;
using Tool;
using UnityEngine;
using View;

namespace Controllers
{
    internal class GamePlayUiController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("UI/UIGameScreen");
        private List<GameObject> _balloons;
        private GamePlayUiButtonController _gamePlayUiButtonController;
        private GamePlayUiGlassesController _gamePlayUiGlassesController;
        private GamePlayUiMovesController _gamePlayUiMovesController;
        private GamePlaySceneView _view;

        public GamePlayUiController(Transform placeForUi, List<GameObject> balloons)
        {
            _balloons = balloons;
            _view = LoadView(placeForUi);
            _gamePlayUiButtonController = new GamePlayUiButtonController(_view);
        }
        private GamePlaySceneView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<GamePlaySceneView>();
        }

        protected override void OnDispose()
        {
            _gamePlayUiButtonController.Dispose(); 
            _gamePlayUiGlassesController.Dispose();
            _gamePlayUiMovesController.Dispose();
        }
    }
}