
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(CarController))]
public class CarControllerEditor : Editor
{

    Transform transformWithPosition;

    public override void OnInspectorGUI()
    {
        CarController car = (CarController)target;

        transformWithPosition = EditorGUILayout.ObjectField("Transform", transformWithPosition, typeof(Transform), true) as Transform;

        if (GUILayout.Button("Stwórz vectory"))
        {
            MakeVectors(car);
        }

        base.OnInspectorGUI();
    }

    void MakeVectors(CarController car)
    {
        if (transformWithPosition == null)
        {
            Debug.LogError("Nie ma zaznaczonego żadnego obiektu");
            return;
        }
        if (transformWithPosition.childCount == 0)
        {
            Debug.LogError("Obiekt nie ma żadnych dzieci");
            return;
        }

        Vector3 startVector;
        List<Vector3> vectorList = new List<Vector3>();

        startVector = car.transform.position;

        for (int i = 0; i < transformWithPosition.childCount; i++)
        {
            Vector3 newVector = transformWithPosition.GetChild(i).position;
            vectorList.Add(newVector - startVector);
            startVector = newVector;
        }

        car.vectors = vectorList;
    }
}