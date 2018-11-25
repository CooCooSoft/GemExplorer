using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerManager : MonoBehaviour
{
    public float radius;
    public GameObject[] Gems;

    private Transform Camera;
    // Use this for initialization
    void Start()
    {
        Camera = GameObject.Find("MixedRealityCameraParent").transform;
        for (int i = 0; i < Gems.Length; i++)
        {
            float z = radius * Mathf.Cos(2 * Mathf.PI / Gems.Length * i);
            float x = radius * Mathf.Sin(2 * Mathf.PI / Gems.Length * i);
            Instantiate(Gems[i], new Vector3(x, 0, z), Gems[i].transform.rotation, Camera);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
