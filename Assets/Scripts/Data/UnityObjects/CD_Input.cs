using Assets.Scripts.Data.ValueObjects;
using UnityEngine;

namespace Assets.Scripts.Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Input", menuName = "Picker3D/CD_Input", order = 0)]
    public class CD_Input : ScriptableObject
    {
        public InputData InputData;
    }
}
