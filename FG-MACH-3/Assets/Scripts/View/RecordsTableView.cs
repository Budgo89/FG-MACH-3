using System.Collections.Generic;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    internal class RecordsTableView : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private List<StringTable> _stringTables;

        public Button MainMenuButton => _mainMenuButton;
        public List<StringTable> StringTables => _stringTables;
    }
}
