using UnityEngine;
using System.Collections;

public static class GameUtility
{
    public static float DistanceSquared(Transform obj1, Transform obj2)
    {
        Vector3 delta = obj1.position - obj2.position;

        return delta.x * delta.x + delta.y * delta.y + delta.z * delta.z;
    }
}
