using UnityEngine;

namespace ZXTemplate.UI
{
    public class UIRoot : MonoBehaviour
    {
        public Canvas Canvas => _canvas;
        public UIStack Stack => _stack;
        public LoadingScreen Loading => _loading;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private UIStack _stack;
        [SerializeField] private LoadingScreen _loading;
    }
}
