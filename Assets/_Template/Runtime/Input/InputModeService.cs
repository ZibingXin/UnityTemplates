using System.Collections.Generic;

namespace ZXTemplate.Input
{
    public class InputModeService : IInputModeService
    {
        private readonly IInputService _input;

        private InputMode _baseMode = InputMode.Gameplay;

        private long _nextId = 1;
        private readonly List<Handle> _handles = new();

        public InputMode BaseMode => _baseMode;
        public InputMode CurrentMode => ComputeEffectiveMode();

        public InputModeService(IInputService input)
        {
            _input = input;
            Apply(CurrentMode);
        }

        public void SetBaseMode(InputMode mode)
        {
            _baseMode = mode;
            Apply(CurrentMode);
        }

        public object Acquire(InputMode mode, string reason)
        {
            var token = new Handle(_nextId++, mode, reason);
            _handles.Add(token);
            Apply(CurrentMode);
            return token;
        }

        public void Release(object token)
        {
            if (token is not Handle h) return;

            for (int i = _handles.Count - 1; i >= 0; i--)
            {
                if (_handles[i].Id == h.Id)
                {
                    _handles.RemoveAt(i);
                    break;
                }
            }

            Apply(CurrentMode);
        }

        private InputMode ComputeEffectiveMode()
        {
            if (_handles.Count == 0) return _baseMode;
            return _handles[^1].Mode; // last acquired wins
        }

        private void Apply(InputMode mode)
        {
            if (mode == InputMode.UI) _input.EnableUI();
            else _input.EnableGameplay();
        }

        private sealed class Handle
        {
            public long Id { get; }
            public InputMode Mode { get; }
            public string Reason { get; }

            public Handle(long id, InputMode mode, string reason)
            {
                Id = id;
                Mode = mode;
                Reason = reason;
            }
        }
    }
}
