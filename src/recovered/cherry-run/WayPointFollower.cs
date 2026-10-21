// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
	[SerializeField]
	private GameObject[] waypoints;

	private int currentwaypointIndex;

	[SerializeField]
	private float speed = 2f;

	private void Update()
	{
		if (Vector2.Distance(waypoints[currentwaypointIndex].transform.position, base.transform.position) < 0.1f)
		{
			currentwaypointIndex++;
			if (currentwaypointIndex >= waypoints.Length)
			{
				currentwaypointIndex = 0;
			}
		}
		base.transform.position = Vector2.MoveTowards(base.transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * speed);
	}
}
