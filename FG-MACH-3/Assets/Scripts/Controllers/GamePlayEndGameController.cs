using System.Collections.Generic;
using System.Linq;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

namespace Controllers
{
    internal class GamePlayEndGameController : BaseController
    {
        private GamePlayUiVictoryController _gamePlayUiVictoryController;

        private GamePlaySceneView _view;
        private List<GameObject> _balloons;
        private List<GameObject> _countBolls;
        private MenuDetected _menuDetected;
        private StoragePoints _storagePoints;
        private string _defeat = "Победа, но очков вы не набрали";

        public GamePlayEndGameController(GamePlaySceneView view, List<GameObject> balloons, List<GameObject> countBolls, MenuDetected menuDetected, StoragePoints storagePoints)
        {
            _view = view;
            _balloons = balloons;
            _countBolls = countBolls;
            _menuDetected = menuDetected;
            _storagePoints = storagePoints;
        }

        public void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                foreach (var balloon in _balloons)
                {
                    _countBolls.Remove(balloon);
                }
                if (_countBolls.Count == 0)
                {
                    StartGameOver();
                }
            }
        }

        private void StartGameOver()
        {
            var tableRecords = CsvParser.GetTableRecord();
            var minRecords = tableRecords.Min(x => x.Point);
            if (_storagePoints.Points >= minRecords)
            {
                CsvParser.SetRecord(_storagePoints);
                SceneManager.LoadScene(NameScene.RecordsTable);
            }
            else
            {
                _gamePlayUiVictoryController = new GamePlayUiVictoryController(_view, _defeat, _menuDetected);
            }
        }

        protected override void OnDispose()
        {
            _gamePlayUiVictoryController?.Dispose();
        }
    }
}