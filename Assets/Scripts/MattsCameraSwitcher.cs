using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattsCameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CameraSwitch());
    }

    IEnumerator CameraSwitch()
    {
        yield return new WaitForSeconds(5.5f);
        camera2.enabled = true;
        camera1.enabled = false;
        yield return new WaitForSeconds(3f);
        camera1.enabled = true;
        camera2.enabled = false;
        yield return new WaitForSeconds(4f);
        camera3.enabled = true;
        camera1.enabled = false;
        yield return new WaitForSeconds(4f);
        camera4.enabled = true;
        camera3.enabled = false;  
    }
}
