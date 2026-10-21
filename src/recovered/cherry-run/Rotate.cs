// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField]
	private float speed = 2f;

	private void Update()
	{
		base.transform.Rotate(0f, 0f, 360f * speed * Time.deltaTime);
	}
}
