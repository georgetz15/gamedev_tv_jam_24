using UnityEngine;

namespace SOs
{
    [CreateAssetMenu(fileName = "Data", menuName = "SOs/WaveScriptableObject", order = 1)]
    public class WaveScriptableObject : ScriptableObject
    {
        public int numBasicEnemies = 3;
        public float speedModifier = 0.0f;
        public float spawnRate = 0.75f;
    }
}