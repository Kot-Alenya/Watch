using System;

public interface IProjectLoop
{
    public event Action OnFixedUpdate;
    public event Action OnDispose;

    public float FixedDeltaTime { get; }
}