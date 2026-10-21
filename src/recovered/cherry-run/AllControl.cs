// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class AllControl : MonoBehaviour
{
	public class GameManager
	{
		private static GameManager _instance;

		public int score;

		public static GameManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameManager();
				}
				return _instance;
			}
		}
	}
}
