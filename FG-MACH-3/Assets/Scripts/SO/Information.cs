using UnityEngine;
using UnityEngine.UI;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(Information), menuName = "Information/" + nameof(Information))]
    internal class Information : ScriptableObject
    {
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public string Management { get; private set; }
        [field: SerializeField] public string Developer { get; private set; }

    }
}
