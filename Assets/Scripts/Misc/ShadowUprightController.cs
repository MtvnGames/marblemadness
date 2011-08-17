using UnityEngine;
using System.Collections;

public class ShadowUprightController : MonoBehaviour
{
	public float height = 8.246965f;
	
    void Update()
    {
		// keep the shadow projector upright
        transform.position = transform.parent.position + Vector3.up * height;
        transform.rotation = Quaternion.LookRotation(-Vector3.up, transform.parent.forward);
    }
}
