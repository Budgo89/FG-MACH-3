using System.Collections.Generic;
using Profile;
using Tool;
using UnityEngine;
using View;

namespace Controllers
{
    internal class GamePlayUiController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("UI/UIGameScreen");
        private List<GameObject> _balloons;
        private InitialProfilePlayer _initialProfilePlayer;
        private List<GameObject> _countBolls;

        private MenuDetected _menuDetected;
        private StoragePoints _storagePoints;

        private GamePlayUiButtonController _gamePlayUiButtonController;
        private GamePlayUiPointsController _gamePlayUiPointsController;
        private GamePlayUiMovesController _gamePlayUiMovesController;
        private readonly GamePlayEndGameController _gamePlayEndGameController;

        private GamePlaySceneView _view;

        public GamePlayUiController(Transform placeForUi, List<GameObject> balloons, InitialProfilePlayer initialProfilePlayer, MenuDetected menuDetected, List<GameObject> countBolls)
        {
            _balloons = balloons;
            _initialProfilePlayer = initialProfilePlayer;
            _countBolls = countBolls;

            _menuDetected = menuDetected;
            _storagePoints = new StoragePoints();

            _view = LoadView(placeForUi);
            _gamePlayUiButtonController = new GamePlayUiButtonController(_view, _menuDetected);
            _gamePlayUiMovesController = new GamePlayUiMovesController(_view, _balloons, _initialProfilePlayer, _menuDetected);
            _gamePlayUiPointsController = new GamePlayUiPointsController(_view, _balloons, _initialProfilePlayer, _storagePoints);
            _gamePlayEndGameController = new GamePlayEndGameController(_view, _balloons, _countBolls, _menuDetected);
        }
        private GamePlaySceneView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<GamePlaySceneView>();
        }

        public void Update()
        {
            
        }

        protected override void OnDispose()
        {
            _gamePlayUiButtonController.Dispose(); 
            _gamePlayUiPointsController.Dispose();
            _gamePlayUiMovesController.Dispose();
            _gamePlayEndGameController.Dispose();
        }

        public void FixedUpdate()
        {
            _gamePlayUiPointsController.FixedUpdate();
            _gamePlayUiMovesController.FixedUpdate();
        }
    }
}