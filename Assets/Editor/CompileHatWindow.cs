using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class CompileHatWindow : EditorWindow
{

    private GorillaCosmetics.Data.Descriptors.HatDescriptor[] notes;
    [MenuItem("Window/Hat Exporter")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CompileHatWindow), false, "Hat Exporter", false);
    }
    public Vector2 scrollPosition = Vector2.zero;

    private void OnFocus()
    {
        notes = GameObject.FindObjectsOfType<GorillaCosmetics.Data.Descriptors.HatDescriptor>();
    }
    void OnGUI()
    {
        var window = EditorWindow.GetWindow(typeof(CompileHatWindow), false, "Hat Exporter", false);

        int ScrollSpace = (16 + 20) + (16 + 17 + 17 + 20 + 20);
        foreach (GorillaCosmetics.Data.Descriptors.HatDescriptor note in notes)
        {
            if (note != null)
            {

                ScrollSpace += (16 + 17 + 17 + 20 + 20);

            }
        }
        float currentWindowWidth = EditorGUIUtility.currentViewWidth;
        float windowWidthIncludingScrollbar = currentWindowWidth;
        if (window.position.size.y >= ScrollSpace)
        {
            windowWidthIncludingScrollbar += 30;
        }
        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, EditorGUIUtility.currentViewWidth, window.position.size.y), scrollPosition, new Rect(0, 0, EditorGUIUtility.currentViewWidth - 20, ScrollSpace), false, false);

        //GUILayout.ScrollViewScope
        GUILayout.Label("Notes", EditorStyles.boldLabel, GUILayout.Height(16));
        GUILayout.Space(20);

        foreach (GorillaCosmetics.Data.Descriptors.HatDescriptor note in notes)
        {
            if (note != null)
            {
                GUILayout.Label("GameObject : " + note.gameObject.name, EditorStyles.boldLabel, GUILayout.Height(16));
                note.AuthorName = EditorGUILayout.TextField("Author name", note.AuthorName, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(17));
                note.HatName = EditorGUILayout.TextField("Hat name", note.HatName, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(17));

                if (GUILayout.Button("Export " + note.HatName, GUILayout.Width(windowWidthIncludingScrollbar - 40), GUILayout.Height(20)))
                {
                    GameObject noteObject = note.gameObject;
                    if (noteObject != null && note != null)
                    {
                        string path = EditorUtility.SaveFilePanel("Save hat file", "", note.HatName + ".hat", "hat");
                        Debug.Log(path == "");

                        if (path != "")
                        {
                            EditorUtility.SetDirty(note);

                            noteObject = Instantiate(noteObject);
                            foreach(Collider collider in noteObject.GetComponentsInChildren<Collider>())
                            {
                                DestroyImmediate(collider);
                            }
                            noteObject.GetComponent<GorillaCosmetics.Data.Descriptors.HatDescriptor>().enabled = false;
                            DestroyImmediate(noteObject.GetComponent<GorillaCosmetics.Data.Descriptors.HatDescriptor>());
                            // do stuff 
                            ExporterUtils.ExportPackage(noteObject, path, "Hat", ExporterUtils.HatDescriptorToJSON(note));
                            EditorUtility.DisplayDialog("Exportation Successful!", "Exportation Successful!", "OK");
                            EditorUtility.RevealInFinder(path);
                        }
                        else
                        {
                            EditorUtility.DisplayDialog("Exportation Failed!", "Path is invalid.", "OK");
                        }
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Exportation Failed!", "Note GameObject is missing.", "OK");
                    }
                }
                GUILayout.Space(20);
            }
        }
        GUI.EndScrollView();
    }

}
