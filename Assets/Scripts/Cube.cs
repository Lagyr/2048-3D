using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    [Header("RigidBody Cube")]
    public Rigidbody rigidbody;

    [Header("Value Cube")]
    public float Value;

    [Header("Texture")]
    public MeshRenderer meshRenderer;

    [Header("Bool")]
    public bool isReleased = false;
    public bool isPressed = false;

    public static Action <GameObject, GameObject, int> EnterCollision;
    public static Action GameOver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube" && Value == collision.gameObject.GetComponent<Cube>().Value)
        {
            EnterCollision?.Invoke(this.gameObject, collision.gameObject, (int)Value);
            rigidbody.AddForce(new Vector3(transform.position.x, transform.position.y + 1500, transform.position.z), ForceMode.Impulse);
            ChangeCube();
        }

        if (collision.gameObject.tag == "Death")
        {
            GameOver?.Invoke();
        }
    }

    private void ChangeCube()
    {
        Value++;
        meshRenderer.material = MaterialData.instance.materials[(int)Value - 1];
    }

}
