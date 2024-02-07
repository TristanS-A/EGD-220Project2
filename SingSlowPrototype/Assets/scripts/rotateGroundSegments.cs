using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGroundSegments : MonoBehaviour
{
    public float segmentTime = 1;
    public float rotSegmentDistence = 1;
    public float rotLerpTimeTotal = 0.3f;
    private float currSegmentTime = 0;
    private Vector3 newRot;
    private Vector3 startLerpPos;
    private float rotLerpTime = 0;
    private Coroutine currCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currSegmentTime += Time.deltaTime;

        if (currSegmentTime >= segmentTime)
        {
            Vector3 eAngles = transform.eulerAngles;
            newRot = new Vector3(eAngles.x, eAngles.y, eAngles.z + rotSegmentDistence);
            startLerpPos = transform.eulerAngles;
            rotLerpTime = 0;

            if (currCoroutine != null)
            {
                StopCoroutine(currCoroutine);
            }

            currCoroutine = StartCoroutine(Co_StartSegmentRotation());
            currSegmentTime = 0;
        }
    }

    private bool rotateGround()
    {
        rotLerpTime += Time.deltaTime;
        transform.eulerAngles = Vector3.Lerp(startLerpPos, newRot, rotLerpTime / rotLerpTimeTotal);

        return transform.eulerAngles == newRot;
    }

    private IEnumerator Co_StartSegmentRotation()
    {
        yield return new WaitUntil(rotateGround);
    }
}
