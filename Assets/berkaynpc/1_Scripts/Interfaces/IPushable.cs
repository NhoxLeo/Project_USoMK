using UnityEngine;

public interface IPushable 
{
    Vector3 myCurrentVelocity { get; }
    void Pushing(Vector3 pushDir);
    void NotPushing();
}
