using UnityEngine;

namespace Profile
{
    [CreateAssetMenu(fileName = nameof(InitialProfilePlayer), menuName = "Configs/" + nameof(InitialProfilePlayer))]
    internal class InitialProfilePlayer : ScriptableObject
    {
        [SerializeField] private int _numberOfMoves = 10;
        [SerializeField] private int _pointMultiplication = 2;
        [SerializeField] private string _textDefeat = "Порожение";

        public int NumberOfMoves => _numberOfMoves;
        public int PointMultiplication => _pointMultiplication;
        public string TextDefeat => _textDefeat;
    }
}
