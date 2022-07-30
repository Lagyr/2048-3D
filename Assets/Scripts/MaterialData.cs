using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialData : MonoBehaviour
{
    public static MaterialData instance;

    [Header("List Material Cubes")]
    public List<Material> materials;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
}
