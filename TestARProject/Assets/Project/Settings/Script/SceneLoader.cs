using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestArProject.Settings
{
    public class SceneLoader : MonoBehaviour
    {
        #region Scene references

        [SerializeField] private LoadingScreenView _loadingScreenViewPrefab;
        [SerializeField] private Transform parent;

        #endregion
        
        #region Unity events

        private void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                ChangeScene(1);
            }
        }

        #endregion

        #region Public API

        public void ChangeScene(int index)
        {
            _loadingScreenView = Instantiate(_loadingScreenViewPrefab, parent);
            StartCoroutine(TrackingLoadProcentCoroutine(index));
        }

        #endregion

        #region Private API

        private LoadingScreenView _loadingScreenView;
        
        private IEnumerator TrackingLoadProcentCoroutine(int numberScene)
        {
            yield return new WaitForSeconds(1f);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(numberScene);
            
            while (!asyncOperation.isDone)
            {
                _loadingScreenView.ShowDataOfLoad(asyncOperation.progress);
                yield return null;
            }
        }

        #endregion
        
    }
}

