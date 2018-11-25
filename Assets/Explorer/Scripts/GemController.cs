using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class GemController : MonoBehaviour, IFocusable
{
    public float revolutionSpeed;
    public float rotationSpeed;
    public float cycle;
    public float amplitude;
    public GameObject Tag;

    private float totalTime;
    private Transform Camera;
    private GameObject tag;

    public void OnFocusEnter()
    {
        tag = Instantiate(Tag, transform);
    }

    public void OnFocusExit()
    {
        Destroy(tag);
    }

    // Use this for initialization
    void Start()
    {
        totalTime = Random.Range(0, cycle);
        Camera = GameObject.Find("MixedRealityCameraParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime = (totalTime + Time.deltaTime) % cycle;
        transform.Translate(Vector3.up * Time.deltaTime * amplitude * Mathf.Cos((2 * Mathf.PI / cycle) * totalTime));
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed, Space.World);
        transform.RotateAround(Camera.position, Vector3.up, Time.deltaTime * revolutionSpeed);
    }
}
