using UnityEngine;
using System.Collections;

public class ConstantForceController : MonoBehaviour {
	
	public const float MAX_FORCE = 10.0f;
	
	private Vector3 inputForce = Vector3.zero;
	private Vector3 forceRelativeToCamera = Vector3.zero;
	
	public bool Enabled = true;
	
	void Start () 
	{
		if(!constantForce)
		{
			Debug.LogError("ConstantForceController needs a constantForce to be applied to this GameObject!");
		}
		
		if(!rigidbody)
		{
			Debug.LogError("ConstantForceController needs a rigidBody to be applied to this GameObject!");
		}
	}
	
	void Update() 
	{
		if(!Enabled)
		{
			return;	
		}
		
		// apply horizontal acceleration/deceleration
		float h = Input.GetAxis("Horizontal");
		inputForce.x = MAX_FORCE * h;
		
		// apply vertical acceleration/deceleration
		float v = Input.GetAxis("Vertical");
		inputForce.z = MAX_FORCE * v;
		
		// forward vector relative to the camera
		Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;
		
		// right vector relative to the camera
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		
		// translate the input force to be relative to the camera
		forceRelativeToCamera = inputForce.x * right + inputForce.z * forward;
	}
	
	public void ClearForceAndVelocity()
	{
		inputForce = Vector3.zero;
		forceRelativeToCamera = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
	}
	
	void FixedUpdate()
	{
		rigidbody.AddForce(forceRelativeToCamera);
	}
}
