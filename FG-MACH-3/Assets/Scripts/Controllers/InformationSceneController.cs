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
        private Transform _placeForUi;
        private Information _information;
        private InformationSceneView _view;
        private Button _backButton;

        public InformationSceneController(Transform placeForUi, Information information)
        {
            _placeForUi = placeForUi;
            _information = information;
            _view = LoadView(placeForUi);
            _backButton = _view.BackButton;
            _backButton.onClick.AddListener(OpenMainMenu);
            FillInInformation();
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
    }
}
