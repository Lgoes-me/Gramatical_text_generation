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
    [CustomEditor(typeof(TextEvent))]
    public class TextEventEditor : UnityEditor.Editor
    {
        private TextEvent _textEvent;
        private List<Resolver> _resolvers;

        private void OnEnable()
        {
            if (_textEvent == null)
            {
                _textEvent = target as TextEvent;
                _resolvers ??= GetEnumerableOfType<Resolver>();
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _resolvers ??= GetEnumerableOfType<Resolver>();

            foreach (var resolver in _resolvers)
            {
                if (GUILayout.Button($"Create {resolver.GetType().Name}"))
                {
                    var type = resolver.GetType();
                    _textEvent.AddResolver((Resolver) Activator.CreateInstance(type));
                }
            }
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
    }
}