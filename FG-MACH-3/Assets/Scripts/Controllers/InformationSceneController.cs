using SO;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Controllers
{
    internal class InformationSceneController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("UI/Information");

        private Information _information;

        private InformationSceneView _view;
        private Button _backButton;
        private Button _developerButton;


        public InformationSceneController(Transform placeForUi, Information information)
        {
            _information = information;
            _view = LoadView(placeForUi);
            _backButton = _view.BackButton;
            _developerButton = _view.DeveloperButton;
            _backButton.onClick.AddListener(OpenMainMenu);
            _developerButton.onClick.AddListener(FollowLink);
            FillInInformation();
        }

        private void FollowLink()
        {
            Application.OpenURL(_information.Developer);
        }

        private void FillInInformation()
        {
            _view.DescriptionText.text = _information.Description;
            _view.DeveloperText.text = _information.Developer;
            _view.ManagementText.text = _information.Management;
        }

        private void OpenMainMenu() => SceneManager.LoadScene(NameScene.MainScreen);

        private InformationSceneView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<InformationSceneView>();
        }

        protected override void OnDispose()
        {
            _backButton.onClick.RemoveAllListeners();
            _developerButton.onClick.RemoveAllListeners();
        }
    }
}
