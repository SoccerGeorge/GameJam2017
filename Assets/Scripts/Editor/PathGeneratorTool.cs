using UnityEditor;
using UnityEngine;

public class MyTools {
	[MenuItem("MyTools/CreatePath")]
	static void Create () {
		GameObject path = GameObject.Find("PathGenerator");

		PathGenerator gen = path.GetComponent<PathGenerator>();
		if (gen != null)
			gen.GeneratePath();
	}

	[MenuItem("MyTools/ClearPath")]
	static void Clear() {
		GameObject path = GameObject.Find("PathGenerator");
		if (path != null) {
			while (path.transform.childCount > 0) {
				foreach (Transform child in path.transform) {
					GameObject.DestroyImmediate(child.gameObject);
				}
			}
		}
	}
}
