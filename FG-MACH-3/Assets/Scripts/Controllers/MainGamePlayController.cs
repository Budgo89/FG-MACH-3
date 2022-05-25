using Profile;
using System.Collections.Generic;
using MonoBehaviours;
using Tool;
using UnityEngine;

namespace Controllers
{
    internal class MainGamePlayController : BaseController
    {
        private Camera _camera;
        private Transform _placeForUi;
        private InitialProfilePlayer _initialProfilePlayer;
        private List<GameObject> _countBolls;
        private Transform _ballStorage;

        private List<GameObject> _balloons;
        private MenuDetected _menuDetected;
        
        private readonly GamePlayController _gamePlayController;
        private readonly GamePlayUiController _gamePlayUiController;
        

        public MainGamePlayController(Camera camera, 
            Transform placeForUi, 
            InitialProfilePlayer initialProfilePlayer, 
            List<GameObject> countBolls, 
            GameObject highlightingFirstMove, 
            Transform ballStorage)
        {
            _camera = camera;
            _placeForUi = placeForUi;
            _initialProfilePlayer = initialProfilePlayer;
            _countBolls = countBolls;
            _ballStorage = ballStorage;

            _balloons = new List<GameObject>();
            _menuDetected = new MenuDetected();

            _gamePlayController = new GamePlayController(_camera, _balloons, _menuDetected, highlightingFirstMove, ballStorage);
            _gamePlayUiController = new GamePlayUiController(_placeForUi, _balloons, _initialProfilePlayer, _menuDetected, _countBolls);
        }


        public void Update()
        {
            _gamePlayController.Update();
        }

        protected override void OnDispose()
        {
            _gamePlayController?.Dispose();
            _gamePlayUiController?.Dispose();
        }

        public void FixedUpdate()
        {
            _gamePlayUiController.FixedUpdate();

        }
    }
}
