using TMPro;
using UnityEngine;

namespace MonoBehaviours
{
    internal class StringTable : MonoBehaviour
    {
        [SerializeField] private TMP_Text _id;
        [SerializeField] private TMP_Text _data;
        [SerializeField] private TMP_Text _point;

        public TMP_Text Id => _id;
        public TMP_Text Data => _data;
        public TMP_Text Point => _point;
    }
}
