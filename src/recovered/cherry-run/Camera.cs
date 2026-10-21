// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class Camera : MonoBehaviour
{
	[SerializeField]
	private Transform player;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.position = new Vector3(player.position.x, player.position.y, base.transform.position.z);
	}
}
