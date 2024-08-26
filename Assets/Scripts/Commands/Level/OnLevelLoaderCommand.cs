using UnityEngine;

namespace Assets.Scripts.Commands.Level
{
    public class OnLevelLoaderCommand
    {
        private readonly Transform _levelHolder;

        public OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute(short levelIndex)
        {
            var level = Resources.Load<GameObject>($"Prefabs/LevelPrefabs/Level {levelIndex}");

            Object.Instantiate(level, _levelHolder, true);
        }
    }
}
