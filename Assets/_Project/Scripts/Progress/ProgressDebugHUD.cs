using UnityEngine;
using ZXTemplate.Core;
using ZXTemplate.Progress;

public class ProgressDebugHUD : MonoBehaviour
{
    private IProgressService _progress;

    private void Start()
    {
        _progress = ServiceContainer.Get<IProgressService>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) _progress.AddMoney(10);
        if (Input.GetKeyDown(KeyCode.Alpha2)) _progress.TrySpendMoney(5);
        if (Input.GetKeyDown(KeyCode.Alpha3)) _progress.UpdateInt1();
        if (Input.GetKeyDown(KeyCode.Alpha4)) _progress.UpdateFloat1();
        if (Input.GetKeyDown(KeyCode.Alpha5)) _progress.UpdateString1();
        if (Input.GetKeyDown(KeyCode.R)) _progress.ResetProgress();
    }

    private void OnGUI()
    {
        var d = _progress.Data;

        GUI.Label(new Rect(10, 10, 500, 25), $"Money: {d.money}");
        GUI.Label(new Rect(10, 35, 500, 25), $"Int 1: {d.stats_int_1}  Float 1: {d.stats_float_1}  String 1: {d.stats_string_1}");
        GUI.Label(new Rect(10, 60, 900, 25), "1:+10 money | 2:-5 money | 3:Int1++ | 4:Float1 + 1.2 | 5:Switch String | R:Reset");
    }
}
