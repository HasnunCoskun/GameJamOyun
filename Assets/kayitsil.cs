using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kayitsil : MonoBehaviour
{

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
