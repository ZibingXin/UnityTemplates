using UnityEngine;
using ZXTemplate.Core;
using ZXTemplate.Input;

public class GameInstaller : MonoBehaviour
{
    private void Start()
    {
        //ServiceContainer.Get<IInputService>().EnableGameplay();
        ServiceContainer.Get<IInputModeService>().SetBaseMode(InputMode.Gameplay);
    }
}
