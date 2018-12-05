using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class GemController : MonoBehaviour, IFocusable
{
    public float revolutionSpeed;
    public float rotationSpeed;
    public float waveSpeed;
    public float waveAmplitude;
    public GameObject Lable;

    private float totalTime;
    private GameObject mainCamera;
    private GameObject lable;

    public void OnFocusEnter()
    {
        lable = Instantiate(Lable, transform);
    }

    public void OnFocusExit()
    {
        Destroy(lable);
    }

    // Use this for initialization
    void Start()
    {
        totalTime = Random.Range(0, 2 * Mathf.PI / waveSpeed);
        mainCamera = GameObject.Find("MixedRealityCameraParent");
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed, Space.World);

        // RevolutionWave
        totalTime = (totalTime + Time.deltaTime) % (2 * Mathf.PI / waveSpeed);
        transform.Translate(Vector3.up * Time.deltaTime * waveAmplitude * Mathf.Cos(waveSpeed * totalTime), mainCamera.transform);
        transform.RotateAround(mainCamera.transform.position, Vector3.up, Time.deltaTime * revolutionSpeed);
    }
}
