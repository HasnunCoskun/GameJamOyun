using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnClick : MonoBehaviour
{
    public Material pc_materyal;

    private void OnMouseDown()
    {
        GetComponent<Renderer>().material = pc_materyal;
    }
}
