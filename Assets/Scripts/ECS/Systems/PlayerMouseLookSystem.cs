using Leopotam.Ecs;
using UnityEngine;

namespace PATROL
{
    sealed class PlayerMouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> playerFilter = null;
        private readonly EcsFilter<PlayerTag, ModelComponent, MouseLookDirectionComponent> mouseLookFilter = null;

        private Quaternion startTransformRotation;

        public void Init()
        {
            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                ref var model = ref entity.Get<ModelComponent>();
                
                startTransformRotation = model.ModelTransform.rotation;
            }
        }

        public void Run()
        {
            foreach (var i in mouseLookFilter)
            {
                ref var entity = ref mouseLookFilter.GetEntity(i);

                entity.Get<ModelComponent>();
                
                ref var model = ref mouseLookFilter.Get2(i);
                ref var lookComponent = ref mouseLookFilter.Get3(i);

                var axisX = lookComponent.Direction.x;
                var axisY = lookComponent.Direction.y;

                var rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * lookComponent.MouseSensitivity);
                var rotateY = Quaternion.AngleAxis(axisY, Vector3.right * Time.deltaTime * lookComponent.MouseSensitivity);

                model.ModelTransform.rotation = startTransformRotation * rotateX;
                lookComponent.PlayerCameraTransform.rotation = model.ModelTransform.rotation * rotateY;
            }
        }
    }
}