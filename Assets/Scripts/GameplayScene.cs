using System;
using System.Linq;
using Controllers;
using Domain.Stories;
using Domain.Actors;
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
        
        public World World;
        public Chapter Chapter;

        private void Awake()
        {
            Instance = this;
            Chapter = ChapterData.ToDomain();
            ContinueButton.onClick.AddListener(Resolve);
            
            World = new World();
        }
        
        private void Resolve()
        {
            Chapter.Resolve(WriteText, () =>
            {
                UnityEngine.Debug.Log("Acabou o capitulo");
            });
        }

        private void WriteText(string nextText)
        {
            var currentText = TextMeshPro.text;
            TextMeshPro.SetText($"{currentText} <br>{nextText}"); 
        }
        
        public void OpenModal(InputFieldResolver resolver, Action<string> callback)
        {
            InputModalController.GetInput(resolver.Tittle, callback);
        }
        
        public void OpenModal(InputDropdownResolver resolver, Action<StatOption> callback)
        {
            DropdownModalController.GetInput(resolver.Tittle, resolver.Options, callback);
        }
    }
}