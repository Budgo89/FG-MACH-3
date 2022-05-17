using UnityEngine;
using UnityEngine.UI;

public class MainScreenView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _recordsTableButton;
    [SerializeField] private Button _aboutProgramButton;
    [SerializeField] private Button _exitButton;

    [Header("AdditionalButtons")]
    [SerializeField] private Button _logOffButton;
    [SerializeField] private Button _stayButton;

    public Button NewGameButton => _newGameButton;
    public Button RecordTableButton => _recordsTableButton;
    public Button AboutProgramButton => _aboutProgramButton;
    public Button ExitButton => _exitButton;
    public Button LogOffButton => _logOffButton;
    public Button SayButton => _stayButton;
}
