using UnityEngine;

namespace TestArProject.Objects
{
    public abstract class AbstractObjectOnScene : MonoBehaviour
    {
        protected Material _material;
        [SerializeField] private MeshRenderer _meshRenderer;
        public abstract void SetRandomColor();
        public abstract void SetOutline();

        protected Color GetRandomColor()
        {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }

        private void Awake()
        {
            _material = _meshRenderer.material;
        }
    }
}

