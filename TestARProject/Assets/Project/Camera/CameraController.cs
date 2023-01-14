using TestArProject.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace TestArProject.UI
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Button _useBtn;
        private AbstractObjectOnScene _objectOnScene;
        private Vector3 _ray_start_position;
        
        private Camera _mainCamera;
        private void Awake()
        {
            _mainCamera = Camera.main;
            _useBtn.onClick.AddListener(ChangeObjectColor);
             _ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0);
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
            RaycastHit hit;
            
            Ray ray = _mainCamera.ScreenPointToRay(_ray_start_position);
            if (Physics.Raycast(ray, out hit)) {
                
                if (hit.transform.TryGetComponent(out _objectOnScene))
                {
                    _useBtn.gameObject.SetActive(true);
                }
                else
                {
                    _useBtn.gameObject.SetActive(false);
                }
                
            }
            else
            {
                _useBtn.gameObject.SetActive(false);
            }
        }
    }
}

