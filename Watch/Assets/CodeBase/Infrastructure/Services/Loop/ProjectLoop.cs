using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Loop
{
    public class ProjectLoop : MonoBehaviour, IProjectLoop
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnDispose;

        public float FixedDeltaTime => Time.fixedDeltaTime;
        public float DeltaTime => Time.deltaTime;

        private void FixedUpdate() => OnFixedUpdate?.Invoke();

        private void Update() => OnUpdate?.Invoke();

        private void OnDestroy() => OnDispose?.Invoke();
    }
}