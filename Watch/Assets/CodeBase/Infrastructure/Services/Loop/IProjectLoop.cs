using System;

namespace CodeBase.Infrastructure.Services.Loop
{
    public interface IProjectLoop
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnDispose;

        public float FixedDeltaTime { get; }
        public float DeltaTime { get; }
    }
}