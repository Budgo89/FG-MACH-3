using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    internal class MainScreenController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("UI/Main");
        private Transform _placeForUi;

        private MainScreenView _view;

        private Button _newGameButton;
        private Button _recordsTableButton;
        private Button _aboutProgramButton;
        private Button _exitButton;
        private List<Button> _buttonList;

        private Button _logOffButton;
        private Button _stayButton;
        private List<Button> _additionalButtonsList;

        public MainScreenController(Transform placeForUi)
        {
            _placeForUi = placeForUi;
            _view = LoadView(placeForUi);
            GetButton(_view);
            SubscribeButton();
            SetActivButtons(_additionalButtonsList);
        }

        private MainScreenView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainScreenView>();
        }

        private void GetButton(MainScreenView mainScreenView)
        {
            _newGameButton = mainScreenView.NewGameButton;
            _recordsTableButton = mainScreenView.RecordTableButton;
            _aboutProgramButton = mainScreenView.AboutProgramButton;
            _exitButton = mainScreenView.ExitButton;
            _buttonList = new List<Button>
            {
                _newGameButton,
                _recordsTableButton,
                _aboutProgramButton,
                _exitButton
            };

            _logOffButton = mainScreenView.LogOffButton;
            _stayButton = mainScreenView.SayButton;
            _additionalButtonsList = new List<Button>
            {
                _logOffButton,
                _stayButton,
            };
        }

        private void SubscribeButton()
        {
            _newGameButton.onClick.AddListener(OpenNewGame);
            _recordsTableButton.onClick.AddListener(OpenRecordsTable);
            _aboutProgramButton.onClick.AddListener(OpenInformation);
            _exitButton.onClick.AddListener(GoExit);

            _logOffButton.onClick.AddListener(ExitGame);
            _stayButton.onClick.AddListener(Back);
        }

        private void OpenNewGame() => SceneManager.LoadScene(NameScene.GamePlay);

        private void OpenRecordsTable()
        {
            throw new System.NotImplementedException();
        }

        private void OpenInformation() => SceneManager.LoadScene(NameScene.InformationScene);

        private void GoExit()
        {
            SetActivButtons(_additionalButtonsList);
            SetActivButtons(_buttonList);
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        private void Back()
        {
            SetActivButtons(_additionalButtonsList);
            SetActivButtons(_buttonList);
        }

        private void UnsubscribeButton()
        {
            _newGameButton.onClick.RemoveAllListeners();
            _recordsTableButton.onClick.RemoveAllListeners();
            _aboutProgramButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();

            _logOffButton.onClick.RemoveAllListeners();
            _logOffButton.onClick.RemoveAllListeners();
        }
        protected override void OnDispose()
        {
            UnsubscribeButton();
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
    }
}
