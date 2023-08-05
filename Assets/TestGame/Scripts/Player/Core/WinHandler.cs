using System.Collections;
using UnityEngine;

namespace RunningUnicorn
{
    public class WinHandler : MonoBehaviour
    {
        public delegate void Win();
        public event Win Won;

        [SerializeField] private float _positionXWin;

        private void Start()
        {
            StartCoroutine(WaitWinPosition());
        }

        private IEnumerator WaitWinPosition()
        {
            while (transform.position.x < _positionXWin)
            {
                yield return null;
            }

            Won?.Invoke();
            new LevelReload(this).ReloadCurrentLevel();
        }
    }
}
