using UnityEngine;
using UnityEditor; // ✅ Add this line
using System.Collections.Generic;

public class MissingReferenceFinder : MonoBehaviour
{
    [MenuItem("Tools/Find Missing References in Scene")]
    static void FindMissingReferences()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int missingCount = 0;

        foreach (GameObject obj in allObjects)
        {
            Component[] components = obj.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                Component comp = components[i];

                if (comp == null)
                {
                    Debug.LogError($"Missing Component in GameObject: '{obj.name}'", obj);
                    missingCount++;
                    continue;
                }

                SerializedObject so = new SerializedObject(comp);
                SerializedProperty prop = so.GetIterator();

                while (prop.NextVisible(true))
                {
                    if (prop.propertyType == SerializedPropertyType.ObjectReference && prop.objectReferenceValue == null && prop.objectReferenceInstanceIDValue != 0)
                    {
                        Debug.LogWarning($"Missing reference in '{obj.name}' (Component: {comp.GetType()}) Property: '{prop.displayName}'", obj);
                        missingCount++;
                    }
                }
            }
        }

        Debug.Log($"Missing reference scan complete. Found {missingCount} issues.");
    }
}