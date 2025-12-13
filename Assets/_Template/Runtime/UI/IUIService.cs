
namespace ZXTemplate.UI
{
    public interface IUIService
    {
        UIRoot Root { get; }
        void Push(UIWindow windowPrefab);
        void Pop();
        void ShowLoading(bool show);
    }
}
