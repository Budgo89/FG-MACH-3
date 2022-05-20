using System.Collections.Generic;
using Models;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Controllers
{
    internal class RecordsTableController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("UI/RecordsTable");
        private Transform _placeForUi;
        private RecordsTableView _view;

        private Button _mainMenuButton;

        private List<StringPoint> _stringPoints;

        public RecordsTableController(Transform placeForUi)
        {
            _placeForUi = placeForUi;
            _view = LoadView(placeForUi);
            _mainMenuButton = _view.MainMenuButton;
            _mainMenuButton.onClick.AddListener(OpenMaimMenu);
            SetTablerecords();
        }

        private void SetTablerecords()
        {
            _stringPoints = CsvParser.StartParser();
            for (int i = 0; i < _stringPoints.Count; i++)
            {
                _view.StringTables[i].Id.text = _stringPoints[i].Id;
                _view.StringTables[i].Data.text = _stringPoints[i].Data;
                _view.StringTables[i].Point.text = _stringPoints[i].Point;

            }
        }

        private void OpenMaimMenu() => SceneManager.LoadScene(NameScene.MainScreen);

        private RecordsTableView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<RecordsTableView>();
        }
        protected override void OnDispose()
        {
            _mainMenuButton.onClick.RemoveAllListeners();
        }
    }
}
