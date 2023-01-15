using UnityEngine;
using UnityEngine.UI;

namespace TestArProject.Objects
{
    public class HitObjectController : MonoBehaviour
    {
        #region Scene references

        [SerializeField] private Button _useBtn;

        #endregion
        
        #region Unity events

        private void Awake()
        {
            _mainCamera = Camera.main;
            _useBtn.onClick.AddListener(ChangeObjectColor);
            _ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0);
        }
        
        private void Update()
        {
            _ray = _mainCamera.ScreenPointToRay(_ray_start_position);
            _useBtn.gameObject.SetActive(Physics.Raycast(_ray, out _hit) &&
                                         _hit.transform.TryGetComponent(out _objectOnScene));
            
        }

        #endregion

        #region Private API
        
        private ObjectOnScene _objectOnScene;
        private Vector3 _ray_start_position;
        private RaycastHit _hit;
        private Ray _ray;
        private Camera _mainCamera;
        
        private void ChangeObjectColor()
        {
            if (_objectOnScene != null)
            {
                _objectOnScene.SetRandomColor();
            }
        }

        #endregion
    }
}

