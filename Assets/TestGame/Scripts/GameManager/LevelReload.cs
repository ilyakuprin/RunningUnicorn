using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunningUnicorn
{
    public class LevelReload
    {
        private readonly float _timeWait = 5;
        private readonly MonoBehaviour _monoBeh;

        public LevelReload(MonoBehaviour monoBehaviour)
        {
            _monoBeh = monoBehaviour;
        }

        public void ReloadCurrentLevel()
        {
            _monoBeh.StartCoroutine(WaitAndReload());
        }

        private IEnumerator WaitAndReload()
        {
            yield return new WaitForSeconds(_timeWait);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
}
