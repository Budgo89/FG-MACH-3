using System.Collections.Generic;
using System.Linq;
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

        private RecordsTableView _view;

        private Button _mainMenuButton;
        private List<StringPoint> _stringPoints;
        private StringPoint _record;
        private int? _recordId;


        public RecordsTableController(Transform placeForUi)
        {
            _stringPoints = CsvParser.GetTableRecord();
            _view = LoadView(placeForUi);
            _mainMenuButton = _view.MainMenuButton;
            _mainMenuButton.onClick.AddListener(OpenMaimMenu);
            CheckForRecords();
        }

        private void CheckForRecords()
        {
            _record = CsvParser.GetRecord();
            if (_record != null)
            {
                AddTableRecords();
                ShowNewRecord();
            }
            SetTableRecords();
        }

        private void ShowNewRecord()
        {
            _recordId = _stringPoints.Where(x => x.Point == _record.Point && x.Data == _record.Data ).ToList().First().Id;
        }

        private void AddTableRecords()
        {
            _stringPoints.Add(_record);
            _stringPoints = _stringPoints.OrderByDescending(x => x.Point).ToList();
            for (int i = 0; i < _stringPoints.Count; i++)
            {
                _stringPoints[i].Id = i + 1;
            }
            CsvParser.SetTableRecord(_stringPoints);
        }

        private void SetTableRecords()
        {
            if (_stringPoints.Count > 10)
            {
                DoSetTableRecords(10);
            }
            else
            {
                DoSetTableRecords(_stringPoints.Count);
            }
        }

        private void DoSetTableRecords(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _view.StringTables[i].Id.text = _stringPoints[i].Id.ToString();
                _view.StringTables[i].Data.text = _stringPoints[i].Data;
                _view.StringTables[i].Point.text = _stringPoints[i].Point.ToString();
                if (_stringPoints[i].Id == _recordId)
                {
                    _view.StringTables[i].Selection.gameObject.SetActive(true);
                }
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
