
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))] //we want to edit Cube script
public class CubeEditor : Editor
{
   public override void OnInspectorGUI()
   {
        base.OnInspectorGUI(); //call the base class OnInspectorGUI()

        Cube cube = (Cube) target; //get the Cube script

        GUILayout.BeginHorizontal(); //begin a horizontal group
        //Everything in BeginHorizontal() and EndHorizontal() will be on the same line horizontally

        if(GUILayout.Button("Generate Color"))
        {
            //Debug.Log("We pressed Generate color!");
            cube.GenerateColor();
        }
        if(GUILayout.Button("Reset Color"))
        {
            //Debug.Log("We pressed Generate color!");
            cube.ResetColor();
        }

        GUILayout.EndHorizontal(); //end the horizontal group
   }


}
