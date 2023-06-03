using Leopotam.Ecs;
using UnityEngine;

namespace PATROL
{
    sealed class ClockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ClockComponent> clockFilter = null;
        private const float REAL_SECOND_PER_INGAME_DAY = 10800f;//21600f; //43200f;
        private const int HOURS_PER_DAY = 24;
        private const int MIN_PER_HOURS = 60;
        public void Run()
        {
            foreach (var i in clockFilter)
            {
                ref var clockComponent = ref clockFilter.Get1(i);
                clockComponent.day += Time.deltaTime / REAL_SECOND_PER_INGAME_DAY;
                
                clockComponent.dayNormalized = clockComponent.day % 1f;

                clockComponent.HourTextMeshProUGUI.text 
                    = Mathf.Floor(clockComponent.dayNormalized * HOURS_PER_DAY).ToString("00");
                clockComponent.MinTextMeshProUGUI.text 
                    = Mathf.Floor(clockComponent.dayNormalized * HOURS_PER_DAY % 1f * MIN_PER_HOURS).ToString("00");
            }
        }
    }
}