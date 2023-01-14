using UnityEngine;

namespace TestArProject.Settings
{
    public class InitScene : MonoBehaviour
    {
        private void Start()
        {
            SceneLoader.instance.ChangeScene(1);
        }
    } 
}

