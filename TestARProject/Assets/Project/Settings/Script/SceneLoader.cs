using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestArProject.Settings
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instance;
        [SerializeField] private LoadingScreenView _loadingScreenViewPrefab;
        private LoadingScreenView _loadingScreenView;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void ChangeScene(int index)
        {
            _loadingScreenView = Instantiate(_loadingScreenViewPrefab);
            StartCoroutine(TrackingLoadProcentCoroutine(index));
        }
        
        private IEnumerator TrackingLoadProcentCoroutine(int numberScene)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(numberScene);
            
            while (!asyncOperation.isDone)
            {
                _loadingScreenView.ShowDataOfLoad(asyncOperation.progress);
                yield return null;
            }
        }
    }
}

