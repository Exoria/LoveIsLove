using UnityEngine;
using UnityEditor;
using System.Collections;

class UVadjust : EditorWindow
{
	float mScale = 1.0f;

    [MenuItem("Window/Adjust UV")]
    public static void ShowWindow()
    {
		EditorWindow.GetWindow(typeof(UVadjust));
    }

    void OnGUI()
    {
        GUILayout.Label("Scale", EditorStyles.boldLabel);
		mScale = EditorGUILayout.Slider ("Value", mScale, 0.1f, 5.0f);
		if (GUILayout.Button ("Apply")) {
			
			foreach(GameObject obj in Selection.gameObjects) {
				Mesh orig = obj.GetComponent<MeshFilter>().sharedMesh;
				obj.GetComponent<MeshFilter>().sharedMesh = (Mesh)Instantiate (obj.GetComponent<MeshFilter>().sharedMesh);
				Mesh mesh = obj.GetComponent<MeshFilter>().sharedMesh;
				mesh.name = orig.name + "b";

				System.Collections.Generic.List<Vector3> uv = new System.Collections.Generic.List<Vector3>();
				mesh.GetUVs (0, uv);

				Vector3 tmp = new Vector3();

				for (int j = 0; j < mesh.triangles.Length; j += 3) {

					Vector3 N = mesh.normals [mesh.triangles[j]];
					float up = Mathf.Abs( Vector3.Dot (N, Vector3.up));
					float fw = Mathf.Abs( Vector3.Dot (N, Vector3.forward));
					float rh = Mathf.Abs( Vector3.Dot (N, Vector3.right));

					for(int i=j; i<j+3; ++i) {
						int id = mesh.triangles[i];

						tmp = obj.transform.TransformVector (mesh.vertices[id]);

						if (up > fw && up > rh) {
							uv [id] = new Vector3 (tmp.x*mScale, tmp.z*mScale, 0);
						} else if (fw > rh) {
							uv [id] = new Vector3 (tmp.x*mScale, tmp.y*mScale, 0);
						} else {
							uv [id] = new Vector3 (tmp.y*mScale, tmp.z*mScale, 0);
						}
					}
				}

				mesh.SetUVs (0, uv);
			}
		}
    }
}