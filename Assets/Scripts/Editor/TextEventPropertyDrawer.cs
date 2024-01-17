using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Data;
using Data.Resolvers;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    /*[CustomPropertyDrawer(typeof(TextEvent))]
    public class TextEventPropertyDrawer : PropertyDrawer
    {
        private List<Resolver> _resolvers;

        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            var textEvent = property.managedReferenceValue as TextEvent;
            
            EditorGUI.PropertyField(rect, property, new GUIContent(textEvent?.Name), true);
            GUILayout.Space(20);

            if (!property.isExpanded) 
                return;
            
            _resolvers ??= GetEnumerableOfType<Resolver>();

            for (var index = 0; index < _resolvers.Count; index++)
            {
                var resolver = _resolvers[index];

                if (GUI.Button(
                    new Rect(
                        rect.xMin + 30f,
                        rect.yMax - 20f * (index + 1),
                        rect.width - 30f,
                        20f),
                    $"Create {resolver.GetType().Name}"))
                {
                    var type = resolver.GetType();
                    textEvent?.AddResolver((Resolver) Activator.CreateInstance(type));
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!property.isExpanded) 
                return EditorGUI.GetPropertyHeight(property);
            
            _resolvers ??= GetEnumerableOfType<Resolver>();
            return EditorGUI.GetPropertyHeight(property) + 20f * _resolvers.Count;
        }
        
        private static List<T> GetEnumerableOfType<T>() where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T) System.Runtime.Serialization.FormatterServices.GetUninitializedObject(type));
            }

            objects.Sort();
            return objects.ToList();
        }
    }*/
}