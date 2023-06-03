using Leopotam.Ecs;
using UnityEngine;

namespace PATROL
{
    sealed class PlayerActionSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CheckPointComponent> checkPointFilter = null;
        private readonly EcsFilter<CharacterComponent> playerFilter = null;

        public void Run()
        {
            foreach (var i in checkPointFilter)
            {
                ref var characterComponent = ref playerFilter.Get1(i);
                ref var checkPointComponent = ref checkPointFilter.Get1(i);
                if (!Input.GetKeyDown(KeyCode.E) || Vector3.Distance(
                        characterComponent.CharacterController.transform.position,
                        checkPointComponent.CheckPointPosition.position) > checkPointComponent.ActivationDistance)
                {
                    return;
                }
                else
                {
                    Debug.Log("ТЕЛЕФОН НАЖАТ");
                }
                ref var entity = ref playerFilter.GetEntity(i);
                entity.Get<PlayerActionInputEvent>();
            }
        }
    }
}