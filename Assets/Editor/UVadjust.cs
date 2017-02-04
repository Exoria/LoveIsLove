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
		mScale = EditorGUILayout.Slider ("Value", mScale, 0.001f, 999.9f);
		if (GUILayout.Button ("Apply")) {
			
			foreach(GameObject obj in Selection.gameObjects) {
				Mesh orig = obj.GetComponent<MeshFilter>().sharedMesh;
				obj.GetComponent<MeshFilter>().sharedMesh = (Mesh)Instantiate (obj.GetComponent<MeshFilter>().sharedMesh);
				Mesh mesh = obj.GetComponent<MeshFilter>().sharedMesh;
				mesh.name = orig.name + "b";

				System.Collections.Generic.List<Vector3> uv = new System.Collections.Generic.List<Vector3>();
				mesh.GetUVs (0, uv);

				Vector3 tmp = new Vector3();

				for(int i=0; i<mesh.vertexCount; ++i) {
					tmp = obj.transform.TransformVector (mesh.vertices[i]);
					uv [i] = new Vector3 (tmp.x*mScale, tmp.z*mScale, 0);
				}

				mesh.SetUVs (0, uv);
			}
		}
    }
}