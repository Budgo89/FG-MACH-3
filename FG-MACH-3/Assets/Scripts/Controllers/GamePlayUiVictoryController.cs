using System.Collections.Generic;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Controllers
{
    internal class GamePlayUiVictoryController : GamePlayUiAbstractController
    {
        private const string StayText = "Повторить";

        private GamePlaySceneView _view;
        private string _defeat;
        private MenuDetected _menuDetected;

        private Button _onMenuButton;
        private Button _stayButton;
        private Button _mainMenuButton;

        private TMP_Text _resultText;
        private TMP_Text _stayText;

        private List<Button> _balloons;

        public GamePlayUiVictoryController(GamePlaySceneView view, string defeat, MenuDetected menuDetected)
        {
            _view = view;
            _defeat = defeat;
            _menuDetected = menuDetected;
            
            _stayButton = _view.StayButton;
            _onMenuButton = _view.OnMenuButton;

            _resultText = _view.ResultText;
            _stayText = _view.StayText;
            _mainMenuButton = _view.MainMenuButton;

            SubscribeButton();
            SetActivButtons(_balloons);
            _mainMenuButton.gameObject.SetActive(false);

            _resultText.text = _defeat;
            _stayText.text = StayText;
            _menuDetected.IsVisible = true;
            Time.timeScale = 0;
        }

        private void SubscribeButton()
        {
            _onMenuButton.onClick.AddListener(OpenMainScreen);
            _stayButton.onClick.AddListener(Repeat);
            _balloons = new List<Button>
            {
                _stayButton,
                _onMenuButton
            };
        }
        private void Repeat()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(NameScene.GamePlay);
        }

        private void OpenMainScreen()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(NameScene.MainScreen);
        }
        protected override void OnDispose()
        {
            _onMenuButton.onClick.RemoveAllListeners();
            _stayButton.onClick.RemoveAllListeners();
        }
    }
}