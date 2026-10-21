// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform target;

	public float xSpeed = 200f;

	public float ySpeed = 200f;

	public float mSpeed = 10f;

	public float yMinLimit = -50f;

	public float yMaxLimit = 50f;

	public float distance = 2f;

	public float minDistance = 2f;

	public float maxDistance = 30f;

	public bool needDamping = true;

	private float damping = 5f;

	public float x;

	public float y;

	private void Start()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		x = eulerAngles.y;
		y = eulerAngles.x;
	}

	private void LateUpdate()
	{
		if ((bool)target)
		{
			if (Input.GetMouseButton(1))
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}
			distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
			distance = Mathf.Clamp(distance, minDistance, maxDistance);
			Quaternion quaternion = Quaternion.Euler(y, x, 0f);
			Vector3 vector = new Vector3(0f, 0f, 0f - distance);
			Vector3 vector2 = quaternion * vector + target.position;
			if (needDamping)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, quaternion, Time.deltaTime * damping);
				base.transform.position = Vector3.Lerp(base.transform.position, vector2, Time.deltaTime * damping);
			}
			else
			{
				base.transform.rotation = quaternion;
				base.transform.position = vector2;
			}
		}
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
