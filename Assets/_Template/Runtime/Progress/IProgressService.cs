namespace ZXTemplate.Progress
{
    public interface IProgressService
    {
        ProgressData Data { get; }

        void AddMoney(int amount);
        bool TrySpendMoney(int amount);

        void UpdateInt1();
        void UpdateFloat1();
        void UpdateString1();

        void Save();
        void ResetProgress(); // 可选：课程 demo 常用
    }
}
