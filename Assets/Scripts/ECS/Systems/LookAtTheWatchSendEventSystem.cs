using Leopotam.Ecs;
using UnityEngine;

namespace PATROL
{
    sealed class LookAtTheWatchSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LookAtTheWatchComponent> LookAtTheWatchFilter = null;

        public void Run()
        {
            foreach (var i in LookAtTheWatchFilter)
            {
                ref var lookAtTheWatchComponent = ref LookAtTheWatchFilter.Get1(i);
                if (!Input.GetKeyDown(KeyCode.T) ||
                    IsAnimationPlaying("LookAtTheWatchAnim", lookAtTheWatchComponent.LeftHand))
                {
                    lookAtTheWatchComponent.LeftHand.SetBool("LookAtTheWatch", false);
                    return;
                }
                else
                {
                    Debug.Log("Anim");
                    lookAtTheWatchComponent.LeftHand.SetBool("LookAtTheWatch", true);
                }
                // ref var entity = ref playerFilter.GetEntity(i);
                // entity.Get<PlayerActionInputEvent>();
            }
        }
        
        public bool IsAnimationPlaying(string animationName, Animator animator)
        {
            var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName(animationName))
                return true;

            return false;
        }
    }
}