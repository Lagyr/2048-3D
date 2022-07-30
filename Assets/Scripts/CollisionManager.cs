using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{ 

    private void OnEnable()
    {
        Cube.EnterCollision += DestroyCollisionCube;
    }

    private void OnDisable()
    {
        Cube.EnterCollision -= DestroyCollisionCube;
    }

    private void DestroyCollisionCube(GameObject firstCube, GameObject secondCube, int Value)
    {
        Destroy(secondCube);
    }
}
