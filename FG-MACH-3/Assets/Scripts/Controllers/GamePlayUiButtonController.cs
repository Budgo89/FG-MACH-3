﻿using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Controllers
{
    internal class GamePlayUiButtonController : BaseController
    {
        private GamePlaySceneView _view;
        MenuDetected _menuDetected;

        private Button _mainMenuButton;
        private Button _onMenuButton;
        private Button _stayButton;
        private List<Button> _balloons;

        public GamePlayUiButtonController(GamePlaySceneView view, MenuDetected menuDetected)
        {
            _view = view;
            _menuDetected = menuDetected;

            _mainMenuButton = _view.MainMenuButton;
            _stayButton = _view.StayButton;
            _onMenuButton = _view.OnMenuButton;

            SubscribeButton();
            SetActivButtons(_balloons);
        }

        private void SubscribeButton()
        {
            _mainMenuButton.onClick.AddListener(OpenAdditionalВuttons);
            _onMenuButton.onClick.AddListener(OpenMainScreen);
            _stayButton.onClick.AddListener(Back);
            _balloons = new List<Button>
            {
                _stayButton,
                _onMenuButton
            };
        }

        private void Back()
        {
            Time.timeScale = 1;
            SetActivButtons(_balloons);
            _mainMenuButton.gameObject.SetActive(true);
            _menuDetected.IsVisible = false;
        }

        private void OpenMainScreen()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(NameScene.MainScreen);
        }

        private void OpenAdditionalВuttons()
        {
            Time.timeScale = 0;
            SetActivButtons(_balloons);
            _mainMenuButton.gameObject.SetActive(false);
            _menuDetected.IsVisible = true;
        }

        private void SetActivButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                if (button.gameObject.activeSelf)
                {
                    button.gameObject.SetActive(false);
                }
                else
                {
                    button.gameObject.SetActive(true);
                }
            }
        }
        protected override void OnDispose()
        {
            _mainMenuButton.onClick.RemoveAllListeners();
            _onMenuButton.onClick.RemoveAllListeners();
            _stayButton.onClick.RemoveAllListeners();
        }
    }
}