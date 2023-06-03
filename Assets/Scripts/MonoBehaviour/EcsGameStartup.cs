using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace PATROL
{
    public class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _system;

        private void Start()
        {
            _world = new EcsWorld();
            _system = new EcsSystems(_world);

            _system.ConvertScene();
            
            AddInjections();
            AddOneFrames();
            AddSystem();
            
            _system.Init();
        }

        private void AddInjections()
        {
            
        }
        
        private void AddSystem()
        {
            _system.Add(new ClockSystem()).
                Add(new CursorLockSystem()).
                Add(new GravitySystem()).
                Add(new PlayerInputSystem()).
                Add(new PlayerMouseInputSystem()).
                Add(new PlayerMouseLookSystem()).
                Add(new PlayerActionSendEventSystem()).
                Add(new MovementSystem()).
                Add(new LookAtTheWatchSendEventSystem())
                ;
        }
        
        private void AddOneFrames()
        {
            _system.OneFrame<PlayerActionInputEvent>();
        }

        private void Update()
        {
            _system.Run();
        }

        private void OnDestroy()
        {
            if (_system == null) return;
            _system.Destroy();
            _world.Destroy();
        }
    }
}
