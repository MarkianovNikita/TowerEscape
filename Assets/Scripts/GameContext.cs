using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GameContext", menuName = "Scriptables/Create Game Context")]
    public class GameContext : ScriptableObject
    {
        public int Difficulty;
    }
}