using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    internal class InformationSceneView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private TMP_Text _managementText;
        [SerializeField] private TMP_Text _developerText;

        public Button BackButton => _backButton;
        public TMP_Text DescriptionText => _descriptionText;
        public TMP_Text ManagementText => _managementText;
        public TMP_Text DeveloperText => _developerText;
    }
}
