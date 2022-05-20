using Controllers;
using UnityEngine;

namespace Assets
{
    internal class RecordsTableEnrtyPoint : MonoBehaviour
    {
        [Header("Scene Objects")]
        [SerializeField] private Transform _placeForUi;

        private RecordsTableController _recordsTableController;

        private void Awake()
        {
            _recordsTableController = new RecordsTableController(_placeForUi);
        }

        private void OnDestroy()
        {
            _recordsTableController.Dispose();
        }
    }
}
