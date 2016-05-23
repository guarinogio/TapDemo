/* 
	VertexDirt plug-in for Unity
	Copyright 2014-2015, Zoltan Farago, All rights reserved.
*/
class VertexDirtWindow extends EditorWindow {

	@MenuItem ("Tools/Zololgo/VertexDirt Window", false, 10)
	static function ShowWindow () {

		var window : VertexDirtWindow = ScriptableObject.CreateInstance.<VertexDirtWindow>();
		
		window.position = Rect(100,100, 260,320);
		window.minSize = Vector2 (260,320);
		window.maxSize = Vector2 (260,320);
		window.titleContent = GUIContent("VD Ambient Occlusion");
		window.ShowUtility();
		VertexDirt.SetPreset (VDPRESET.AMBIENTOCCLUSION);

	}
	
    function OnGUI() {

		GUILayout.Label ("Occlusion distance");
		VertexDirt.samplingDistance = EditorGUILayout.Slider(VertexDirt.samplingDistance,0.01, 1000.0);
		GUILayout.Space(10);
		GUILayout.BeginHorizontal();
		GUILayout.Label ("Edge smooth enabled");
		GUILayout.FlexibleSpace();
		VertexDirt.edgeSmooth = GUILayout.Toggle(VertexDirt.edgeSmooth, "");
		GUILayout.EndHorizontal();
		//
		GUILayout.Space(10);
		GUILayout.Label ("Sampling angle");
		VertexDirt.samplingAngle = EditorGUILayout.Slider(VertexDirt.samplingAngle,100, 150);
		//		VertexDirt.skyCube = EditorGUILayout.ObjectField(VertexDirt.skyCube, Material, true);
		GUILayout.Space(10);
		GUILayout.BeginHorizontal();
		GUILayout.Label ("Legacy Mode (Unity 4.x indie)");
		GUILayout.FlexibleSpace();
		VertexDirt.legacyMode = GUILayout.Toggle(VertexDirt.legacyMode, "");
		GUILayout.EndHorizontal();
		//
		//
		// GUILayout.Space(10);
		// GUILayout.BeginHorizontal();
		// GUILayout.Label ("Compatibility Mode Enabled");
		// GUILayout.FlexibleSpace();
		// VertexDirt.compatibilityMode = GUILayout.Toggle(VertexDirt.compatibilityMode, "");
		// GUILayout.EndHorizontal();
		//		
		GUILayout.Space(10);
		GUILayout.Label ("Sky color");
		VertexDirt.skyColor = EditorGUILayout.ColorField(VertexDirt.skyColor);
		GUILayout.Space(10);
		GUILayout.Label ("Shadow color");
		VertexDirt.globalOccluderColor = EditorGUILayout.ColorField(VertexDirt.globalOccluderColor);
		//		globalOccluderColor = Color.black;
		
 		if (Selection.gameObjects) {
		
			if (GUI.Button(Rect(10,320-50,240,40),"Start") ) {

				var tempTime : float = EditorApplication.timeSinceStartup;
				VertexDirt.Dirt(Selection.GetFiltered(Transform, SelectionMode.Deep));
				Debug.Log ("Dirt time: " + (EditorApplication.timeSinceStartup - tempTime));
		
			}
			
		}
 
    }
	
}