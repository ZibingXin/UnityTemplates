using ZXTemplate.Save;

namespace ZXTemplate.Progress { 
    public class ProgressService : IProgressService
    {
        public ProgressData Data { get; private set; }

        private readonly ISaveService _save;

        public ProgressService(ISaveService save)
        {
            _save = save;

            if (!_save.TryLoad(ProgressKeys.Main, out ProgressData data) || data == null || !data.initialized)
            {
                Data = new ProgressData();
                _save.Save(ProgressKeys.Main, Data);
            }
            else
            {
                data.Clamp();
                Data = data;
            }
        }

        public void AddMoney(int amount)
        {
            if (amount <= 0) return;
            Data.money += amount;
            Save();
        }

        public bool TrySpendMoney(int amount)
        {
            if (amount <= 0) return true;
            if (Data.money < amount) return false;

            Data.money -= amount;
            Save();
            return true;
        }

        public void UpdateInt1()
        {
            Data.stats_int_1 += 1;
            Save();
        }

        public void UpdateFloat1()
        {
            Data.stats_float_1 += 1.2f;
            Save();
        }

        public void UpdateString1()
        {
            Data.stats_string_1 = Data.stats_string_1 == "default" ? "updated" : "default";
            Save();
        }

        public void Save()
        {
            Data.Clamp();
            _save.Save(ProgressKeys.Main, Data);
        }

        public void ResetProgress()
        {
            Data = new ProgressData();
            _save.Save(ProgressKeys.Main, Data);
        }
    }
}
