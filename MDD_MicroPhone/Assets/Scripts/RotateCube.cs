using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    // 장식용
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.right * 30.0f * Time.deltaTime);
    }
}
