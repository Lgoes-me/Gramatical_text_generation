using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Resolvers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class DropdownModalController : MonoBehaviour
    {
        [field: SerializeField]
        private TextMeshProUGUI Tittle { get; set; }
        
        [field: SerializeField]
        private TMP_Dropdown Dropdown { get; set; }
        
        [field: SerializeField]
        private Button ContinueButton { get; set; }

        private List<StatOption> Options { get; set; }
        private bool CanContinue { get; set; }
        
        public void GetInput(string tittle, List<StatOption> options, Action<StatOption> callback)
        {
            gameObject.SetActive(true);
            
            Options = options;
            Dropdown.options = Options.Select(s => new TMP_Dropdown.OptionData(s.StatValue)).ToList();
            
            Tittle.SetText(tittle);
            ContinueButton.onClick.AddListener(TryContinue);
            StartCoroutine(WaitForKeyDown(callback));
        }
        
        private IEnumerator WaitForKeyDown(Action<StatOption> callback)
        {
            yield return new WaitUntil(() => CanContinue);
            gameObject.SetActive(false);
            callback(Options[Dropdown.value]);
        }

        private void TryContinue()
        {
            CanContinue = true;
        }
    }
}