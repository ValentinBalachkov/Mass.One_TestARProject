using TestArProject.Objects;
using TestArProject.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace TestArProject.UI
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Button _useBtn;
        [SerializeField] private Button _restartBtn;

        private AbstractObjectOnScene _objectOnScene;
        private Vector3 _ray_start_position;
        private RaycastHit _hit;
        private Ray _ray;
        private Camera _mainCamera;
        private void Awake()
        {
            _mainCamera = Camera.main;
            _useBtn.onClick.AddListener(ChangeObjectColor);
            _restartBtn.onClick.AddListener(RestartScene);
             _ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0);
        }
        private void RestartScene()
        {
            SceneLoader.instance.ChangeScene(1);
        }

        private void ChangeObjectColor()
        {
            if (_objectOnScene != null)
            {
                _objectOnScene.SetRandomColor();
            }
        }

        private void Update()
        {
            _ray = _mainCamera.ScreenPointToRay(_ray_start_position);
            _useBtn.gameObject.SetActive(Physics.Raycast(_ray, out _hit) &&
                                         _hit.transform.TryGetComponent(out _objectOnScene));
        }
    }
}

