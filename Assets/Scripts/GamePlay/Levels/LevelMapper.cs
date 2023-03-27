using UnityEngine;

namespace GamePlay.Levels
{
    public class LevelMapper : MonoBehaviour
    {
        [SerializeField] private Transform _paddleSpawnPosition;
        [SerializeField] private Transform _bricksSpawnPosition;

        public Transform PaddleSpawnPosition => _paddleSpawnPosition;

        public Transform BricksSpawnPosition => _bricksSpawnPosition;
    }
}