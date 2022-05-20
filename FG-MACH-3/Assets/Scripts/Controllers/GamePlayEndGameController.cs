﻿using System.Collections.Generic;
using Tool;
using UnityEngine;
using View;

namespace Controllers
{
    internal class GamePlayEndGameController : BaseController
    {
        private GamePlaySceneView _view;
        private List<GameObject> _balloons;
        private List<GameObject> _countBolls;
        private MenuDetected _menuDetected;

        public GamePlayEndGameController(GamePlaySceneView view, List<GameObject> balloons, List<GameObject> countBolls, MenuDetected menuDetected)
        {
            _view = view;
            _balloons = balloons;
            _countBolls = countBolls;
            _menuDetected = menuDetected;
        }
    }
}