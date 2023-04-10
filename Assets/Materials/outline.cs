using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outline : MonoBehaviour
{

    public Material newMaterial;
    public Material originalMaterial;

    void OnMouseEnter()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = newMaterial;
    }

    void OnMouseExit()
    {
        // orijinal materyale geri dönmek için
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = originalMaterial;
    }
}

