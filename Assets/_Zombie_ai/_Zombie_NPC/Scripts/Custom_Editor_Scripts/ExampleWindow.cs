using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    //string myString = "Hello World!";

    Color color;
    
    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }
    
    void OnGUI()
    {
       GUILayout.Label("Color the selected Object.", EditorStyles.boldLabel);

       //myString = EditorGUILayout.TextField("Name", myString);

    //    if(GUILayout.Button("Colorize"))
    //    {
    //        Debug.Log(myString);
    //    }

        color = EditorGUILayout.ColorField("Color", color);
        if(GUILayout.Button("Colorize"))
        {
            Colorize();
        }
    }


    void Colorize()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach(GameObject go in selectedObjects)
        {
            Renderer renderer = go.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
