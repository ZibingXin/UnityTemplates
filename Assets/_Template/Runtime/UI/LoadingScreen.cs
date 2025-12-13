using UnityEngine;

namespace ZXTemplate.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;

        public void Show()
        {
            group.alpha = 1;
            group.blocksRaycasts = true;
            group.interactable = true;
        }

        public void Hide()
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
            group.interactable = false;
        }
    }
}
