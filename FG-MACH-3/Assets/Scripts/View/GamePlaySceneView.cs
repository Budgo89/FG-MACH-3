using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    internal class GamePlaySceneView : MonoBehaviour
    {
        [Header("BasicВuttons")]
        [SerializeField] private Button _mainMenuButton;

        [Header("AdditionalВuttons")] 
        [SerializeField] private Button _onMenuButton;
        [SerializeField] private Button _stayButton;

        [Header("Text")] 
        [SerializeField] private TMP_Text _movesText;
        [SerializeField] private TMP_Text _pointsText;
        [SerializeField] private TMP_Text _resultText;
        [SerializeField] private TMP_Text _stayText;
        
        public Button MainMenuButton => _mainMenuButton;
        public Button OnMenuButton => _onMenuButton;
        public Button StayButton => _stayButton;

        public TMP_Text MovementsText => _movesText;
        public TMP_Text PointsText => _pointsText;
        public TMP_Text ResultText => _resultText;
        public TMP_Text StayText => _stayText;
    }
}
