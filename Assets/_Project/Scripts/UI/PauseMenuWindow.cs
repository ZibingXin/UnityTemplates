using UnityEngine;
using UnityEngine.UI;
using ZXTemplate.Core;
using ZXTemplate.Input;
using ZXTemplate.UI;

public class PauseMenuWindow : UIWindow
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private SettingsWindow settingsWindowPrefab;

    private IPauseService _pause;
    //private IInputService _input;
    private IInputModeService _inputMode;

    private object _pauseToken;
    private object _inputToken;

    public override void OnPushed()
    {
        _pause = ServiceContainer.Get<IPauseService>();
        //_input = ServiceContainer.Get<IInputService>();
        _inputMode = ServiceContainer.Get<IInputModeService>();

        // 获得一个暂停 token（引用计数）
        _pauseToken = _pause.Acquire("PauseMenu");
        //_input.EnableUI();
        _inputToken = _inputMode.Acquire(InputMode.UI, "PauseMenu");

        resumeButton.onClick.AddListener(Resume);
        settingsButton.onClick.AddListener(OpenSettings);

    }

    public override void OnPopped()
    {
        resumeButton.onClick.RemoveListener(Resume);
        settingsButton.onClick.RemoveListener(OpenSettings);

        // 释放 token
        _pause.Release(_pauseToken);
        _pauseToken = null;

        //_input.EnableGameplay();
        _inputMode.Release(_inputToken);
        _inputToken = null;


    }

    private void Resume()
    {
        // 由控制器负责 Pop（更统一），这里也可以直接 Pop
        ServiceContainer.Get<IUIService>().Pop();
    }

    private void OpenSettings()
    {
        ServiceContainer.Get<IUIService>().Push(settingsWindowPrefab);
    }
}
