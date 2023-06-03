using Leopotam.Ecs;
using UnityEngine;

namespace PATROL
{
    sealed class GravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent, MovableComponent, GravityComponent> gravityFilter = null;

        public void Run()
        {
            foreach (var i in gravityFilter)
            {
                ref var characterComponent = ref gravityFilter.Get1(i);
                ref var movableComponent = ref gravityFilter.Get2(i);
                ref var gravityComponent = ref gravityFilter.Get3(i);

                ref var characterController = ref characterComponent.CharacterController;
                
                ref var velocity = ref movableComponent.Velocity;
                velocity.y += gravityComponent.Gravity * Time.deltaTime;

                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}