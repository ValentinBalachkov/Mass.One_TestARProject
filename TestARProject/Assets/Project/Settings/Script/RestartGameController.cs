using UnityEngine;
using UnityEngine.UI;

namespace TestArProject.Settings
{
    public class RestartGameController : MonoBehaviour
    {
        #region Scene references
        
        [SerializeField] private int _sceneIndex;
        [SerializeField] private Button _restartButton;
        [SerializeField] private SceneLoader _sceneLoader;

        #endregion

        #region Unity events

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
        }

        #endregion

        #region Private API

        private void RestartGame()
        {
            _sceneLoader.ChangeScene(_sceneIndex);
        }

        #endregion
        
    }
}

