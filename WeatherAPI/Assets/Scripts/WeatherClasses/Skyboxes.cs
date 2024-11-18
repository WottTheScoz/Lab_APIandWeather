using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyboxes
{
    List<string> names = new List<string>();

    List<Material> materials = new List<Material>();

    public void AddSkybox(string name, Material material) 
    {
        names.Add(name);
        materials.Add(material);
    }

    public string[] GetNames() 
    {
        string[] nameArray = new string[names.Count];

        for (int i = 0; i < names.Count; ++i)
        {
            nameArray[i] = names[i];
        }

        return nameArray;
    }

    public Material[] GetMaterials() 
    {
        Material[] materialArray = new Material[materials.Count];

        for (int i = 0; i < materials.Count; ++i)
        {
            materialArray[i] = materials[i];
        }

        return materialArray;
    }
}
