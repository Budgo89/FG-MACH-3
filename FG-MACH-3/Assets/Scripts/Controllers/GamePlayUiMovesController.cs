using System.Collections.Generic;
using Profile;
using TMPro;
using Tool;
using UnityEngine;
using View;

namespace Controllers
{
    internal class GamePlayUiMovesController : BaseController
    {
        private GamePlaySceneView _view;
        private List<GameObject> _balloons;
        private MenuDetected _menuDetected;
        
        private int _numberOfMoves;
        private TMP_Text _movementsText;
        private GamePlayUiVictoryController _gamePlayUiVictoryController;

        private string _defeat = "Порожение";

        public GamePlayUiMovesController(GamePlaySceneView view, List<GameObject> balloons, InitialProfilePlayer initialProfilePlayer, MenuDetected menuDetected)
        {
            _view = view;
            _balloons = balloons;
            _menuDetected = menuDetected;

            _numberOfMoves = initialProfilePlayer.NumberOfMoves;
            _movementsText = _view.MovementsText;
            _defeat = initialProfilePlayer.TextDefeat;
            _movementsText.text = _numberOfMoves.ToString();

        }

        public void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                StrokeCheck();
            }
        }

        private void StrokeCheck()
        {
            if (_balloons.Count > 0)
            {
                WriteOffMove();
            }
        }

        private void WriteOffMove()
        {
            if (_balloons.Count == 1)
            {
                _numberOfMoves--;
                _movementsText.text = _numberOfMoves.ToString();
            }
            else
            {
                _numberOfMoves -=(_balloons.Count - 1);
                _movementsText.text = _numberOfMoves.ToString();
            }

            if (_numberOfMoves <= 0)
            {
                _movementsText.text = 0.ToString();
                _gamePlayUiVictoryController = new GamePlayUiVictoryController(_view, _defeat, _menuDetected);
            }
            _balloons.Clear();
        }

        protected override void OnDispose()
        {

        }
    }
}