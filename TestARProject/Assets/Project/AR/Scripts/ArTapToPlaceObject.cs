using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArTapToPlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private ARRaycastManager _arRaycastManager;
    
    private GameObject _spawnedObject;
    private Vector2 _touchPosition;

    private static List<ARRaycastHit> _hits = new();

    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out _touchPosition))
        {
            Debug.Log("AAAB");
            return;
        }

        if (_arRaycastManager.Raycast(_touchPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            Debug.Log("AAA");
            var hitPose = _hits[0].pose;
            if (_spawnedObject == null)
            {
                _spawnedObject = Instantiate(_objectPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                _spawnedObject.transform.position = hitPose.position;
            }
        }
        
    }
}
