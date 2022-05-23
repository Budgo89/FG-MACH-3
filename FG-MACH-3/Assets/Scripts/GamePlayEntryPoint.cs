using System.Collections.Generic;
using Controllers;
using MonoBehaviours;
using Profile;
using Tool;
using UnityEngine;

public class GamePlayEntryPoint : MonoBehaviour
{
    [Header("Initial Settings")]
    [SerializeField] private InitialProfilePlayer _initialProfilePlayer;

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _placeForUi;
    private List<GameObject> _countBolls;

    private MainGamePlayController _gamePlayController;

    public void Awake()
    {
        CsvParser.DeleteRecords();
        _countBolls = new List<GameObject>();
        FillCountBolls();
        _gamePlayController = new MainGamePlayController(_camera, _placeForUi, _initialProfilePlayer, _countBolls);
    }

    public void Update()
    {
        _gamePlayController.Update();
    }

    public void FixedUpdate()
    {
        _gamePlayController.FixedUpdate();
    }
    private void OnDestroy()
    {
        _gamePlayController.Dispose();
    }
    private void FillCountBolls()
    {
        Blue[] blues = FindObjectsOfType(typeof(Blue)) as Blue[];
        foreach (var blue in blues)
        {
            _countBolls.Add(blue.gameObject);
        }
        Green[] greens = FindObjectsOfType(typeof(Green)) as Green[];
        foreach (var green in greens)
        {
            _countBolls.Add(green.gameObject);
        }
        Red[] reds = FindObjectsOfType(typeof(Red)) as Red[];
        foreach (var red in reds)
        {
            _countBolls.Add(red.gameObject);
        }
        Yellow[] yellows = FindObjectsOfType(typeof(Yellow)) as Yellow[];
        foreach (var yellow in yellows)
        {
            _countBolls.Add(yellow.gameObject);
        }
    }
}
