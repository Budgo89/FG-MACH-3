using Enums;
using UnityEngine;

namespace MonoBehaviours
{
    internal class Red : MonoBehaviour, IBalloons
    {
        public Colors Colors { get; } = Colors.Red;
    }
}
