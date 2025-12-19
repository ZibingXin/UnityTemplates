namespace ZXTemplate.Input
{
    public interface IInputModeService
    {
        InputMode BaseMode { get; }
        InputMode CurrentMode { get; }

        void SetBaseMode(InputMode mode);

        object Acquire(InputMode mode, string reason);
        void Release(object token);
    }
}
