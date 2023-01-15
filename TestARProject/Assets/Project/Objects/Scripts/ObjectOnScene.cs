using UnityEngine;

namespace TestArProject.Objects
{
    public class ObjectOnScene : MonoBehaviour
    {
        #region Scene references
        
        [SerializeField] private MeshRenderer _meshRenderer;
        
        #endregion
        
        #region Unity events
        private void Awake()
        {
            _material = _meshRenderer.material;
        }

        #endregion

        #region Public API

        public void SetRandomColor()
        {
            _material.color = GetRandomColor();
        }
        
        #endregion

        #region Private API

        private Material _material;
        private Color GetRandomColor()
        {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }

        #endregion
        
    }
}

