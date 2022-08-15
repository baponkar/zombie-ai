
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Sphere))]
public class SphereEditor : Editor
{
   public override void OnInspectorGUI()
   {
      //base.OnInspectorGUI(); //Showing up all serialized variables of sphere class on GUI Inspector

      Sphere sphere = (Sphere) target;

      GUILayout.Label("Oscilate Sphere size around base Size", EditorStyles.boldLabel);

      sphere.baseSize = EditorGUILayout.Slider("Base Size", sphere.baseSize, 0.1f, 2f);
      sphere.transform.localScale = Vector3.one * sphere.baseSize;
      
   }
}
