using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    internal class StringTable : MonoBehaviour
    {
        [SerializeField] private TMP_Text _id;
        [SerializeField] private TMP_Text _data;
        [SerializeField] private TMP_Text _point;

        [SerializeField] private Image _imageSelection;

        public TMP_Text Id => _id;
        public TMP_Text Data => _data;
        public TMP_Text Point => _point;

        public Image Selection => _imageSelection;
    }
}
