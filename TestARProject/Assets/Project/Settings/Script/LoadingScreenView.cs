using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestArProject.Settings
{
    public class LoadingScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _loadingProcentText;
        [SerializeField] private Slider _progressLoading;

        private void Start()
        {
            _loadingProcentText.text = "Loading: 0%...";
            _progressLoading.value = 0;
        }

        public void ShowDataOfLoad(float progress)
        {
            _loadingProcentText.text = $"Loading: {(progress * 100):F0}%...";
            _progressLoading.value = progress;
        }
    } 
}

