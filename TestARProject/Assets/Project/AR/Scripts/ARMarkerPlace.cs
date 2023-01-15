using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace TestArProject.ARComponents
{
    public class ARMarkerPlace : MonoBehaviour
    {
        #region Scene references

        [SerializeField] private ARRaycastManager _arRaycastManager;
        [SerializeField] private GameObject _markerObject;

        #endregion
        
        private Vector3 _ray_start_position;
        private List<ARRaycastHit> _hits = new();

        #region Unity events

        private void Awake()
        {
            _ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0);
        }
        private void Update()
        {
            _arRaycastManager.Raycast(_ray_start_position, _hits, TrackableType.Planes);
            if (_hits.Count > 0)
            {
                _markerObject.transform.position = _hits[0].pose.position;
                _markerObject.transform.rotation = _hits[0].pose.rotation;
            }
        }

        #endregion
       
    }
}

