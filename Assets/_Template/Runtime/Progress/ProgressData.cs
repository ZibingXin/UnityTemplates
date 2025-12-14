using System;
using UnityEngine;

namespace ZXTemplate.Progress
{
    [Serializable]
    public class ProgressData
    {
        public bool initialized = true;

        [Min(0)] public int money = 0;

        // Example int stats
        [Min(0)] public int stats_int_1 = 0;

        // Example float stats
        [Min(0f)] public float stats_float_1 = 0f;

        // Example String stats
        public string stats_string_1 = "default";


        public void Clamp()
        {
            money = Mathf.Max(0, money);
            stats_int_1 = Mathf.Max(0, stats_int_1);
            stats_float_1 = Mathf.Max(0f, stats_float_1);
            stats_string_1 ??= "default";

        }
    }
}
