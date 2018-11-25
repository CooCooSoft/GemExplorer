using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerManager : MonoBehaviour
{
    public float radius;
    public GameObject[] Gems;
    public Material[] GemMaterials;

    private GameObject mainCamera;
    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("MixedRealityCamera");
        for (int i = 0; i < Gems.Length; i++)
        {
            float z = radius * Mathf.Cos(2 * Mathf.PI / Gems.Length * i);
            float x = radius * Mathf.Sin(2 * Mathf.PI / Gems.Length * i);
            Instantiate(Gems[i]);
            Gems[i].transform.position = mainCamera.transform.position + new Vector3(x, 0, z);
            Gems[i].GetComponentInChildren<MeshRenderer>().material = GemMaterials[i % GemMaterials.Length];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
