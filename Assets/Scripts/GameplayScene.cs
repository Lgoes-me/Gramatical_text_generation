using System;
using Controllers;
using Domain;
using Domain.Resolvers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Debug
{
    public class GameplayScene : MonoBehaviour
    {
        public static GameplayScene Instance { get; private set; }
        
        public InputModalController InputModalController;
        public DropdownModalController DropdownModalController;
        public TextMeshProUGUI TextMeshPro;
        public Button ContinueButton;
        
        public Data.Chapter ChapterData;
        
        public Actor Actor;
        
        private Chapter Chapter;

        private void Awake()
        {
            Instance = this;
            Chapter = ChapterData.ToDomain();
            ContinueButton.onClick.AddListener(Resolve);
            
            Actor = new Actor();
        }
        
        private void Resolve()
        {
            Chapter.Resolve(WriteText);
        }

        private void WriteText(string nextText)
        {
            var currentText = TextMeshPro.text;
            TextMeshPro.SetText($"{currentText} <br>{nextText}"); 
        }

        public void OpenModal(InputResolver resolver, Action<string> callback)
        {
            switch (resolver)
            {
                case InputFieldResolver inputFieldResolver:
                {
                    InputModalController.GetInput(inputFieldResolver.Tittle, callback);
                    break;
                }
                case InputDropdownResolver dropdownResolver:
                {
                    DropdownModalController.GetInput(dropdownResolver.Tittle, dropdownResolver.Options, callback);
                    break;
                }
            }
            
        }
        
    }
}