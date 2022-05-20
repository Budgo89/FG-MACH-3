using Profile;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using View;

namespace Controllers
{
    internal class GamePlayUiPointsController : BaseController
    {
        private GamePlaySceneView _view;
        private List<GameObject> _balloons;
        private InitialProfilePlayer _initialProfilePlayer;
        private StoragePoints _storagePoints;

        private TMP_Text _pointsText;
        private int _pointMultiplication;

        public GamePlayUiPointsController(GamePlaySceneView view, List<GameObject> balloons, InitialProfilePlayer initialProfilePlayer, StoragePoints storagePoints)
        {
            _view = view;
            _balloons = balloons;
            _initialProfilePlayer = initialProfilePlayer;
            _storagePoints = storagePoints;

            _pointsText = _view.PointsText;
            _pointMultiplication = _initialProfilePlayer.PointMultiplication;
        }

        public void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                AccrualCheckGlasses();
            }
        }

        private void AccrualCheckGlasses()
        {
            if (_balloons.Count > 0)
            {
                EarnPoints();
            }
        }

        private void EarnPoints()
        {
           _storagePoints.Points += _balloons.Count * _pointMultiplication;
           _pointsText.text = _storagePoints.Points.ToString();
        }
    }
}