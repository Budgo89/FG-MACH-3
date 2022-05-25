using Controllers;
using SO;
using UnityEngine;

public class InformationSceneEntryPoint : MonoBehaviour
{
    [Header("Scene Objects")]
    [SerializeField] private Transform _placeForUi;

    [Header("Information")]
    [SerializeField] private Information _information;

    private InformationSceneController _informationSceneController;


    void Awake()
    {
        _informationSceneController = new InformationSceneController(_placeForUi, _information);
    }
    private void OnDestroy()
    {
        _informationSceneController.Dispose();
    }
}
