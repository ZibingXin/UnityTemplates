using UnityEngine;
using ZXTemplate.Core;
using ZXTemplate.Input;
using ZXTemplate.UI;

public class MainMenuInstaller : MonoBehaviour
{
    [SerializeField] private MainMenuWindow mainMenuPrefab;

    private void Start()
    {
        //ServiceContainer.Get<IInputService>().EnableUI();
        ServiceContainer.Get<IInputModeService>().SetBaseMode(InputMode.UI);
        ServiceContainer.Get<IUIService>().Push(mainMenuPrefab);
    }
}
