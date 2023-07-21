using System;
using UnityEngine;

public class ProjectLoop : MonoBehaviour, IProjectLoop
{
    public event Action OnFixedUpdate;
    public event Action OnDispose;

    public float FixedDeltaTime => Time.fixedDeltaTime;

    private void FixedUpdate() => OnFixedUpdate?.Invoke();

    private void OnDestroy() => OnDispose?.Invoke();
}