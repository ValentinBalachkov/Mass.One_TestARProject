using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestArProject.Objects
{
    public class HitObjectController : MonoBehaviour
    {
        #region Scene references

        [SerializeField] private Button _useBtn;
        [SerializeField] private List<ObjectOnScene> _objectsOnScene = new();
        

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
             
             if (Physics.Raycast(_ray, out _hit))
             {
                 if (_objectOnScene != null)
                 {
                     return;
                 }
                 if (_hit.transform.TryGetComponent(out _objectOnScene))
                 {
                     _useBtn.gameObject.SetActive(true);
                     _objectOnScene.SetOutline(5);
                 }
             }
             else if(_objectOnScene != null)
             {
                 _useBtn.gameObject.SetActive(false);
                 ClearOutlines();
             }
        }

        private void ClearOutlines()
        {
            foreach (var item in _objectsOnScene)
            {
                item.SetOutline(0);
            }

            _objectOnScene = null;
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

