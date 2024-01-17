using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private bool CanContinue { get; set; }
        
        public void GetInput(string tittle, List<string> options, Action<string> callback)
        {
            gameObject.SetActive(true);
            
            Tittle.SetText(tittle);
            Dropdown.options = options.Select(s => new TMP_Dropdown.OptionData(s)).ToList();
            
            ContinueButton.onClick.AddListener(TryContinue);
            StartCoroutine(WaitForKeyDown(callback));
        }
        
        private IEnumerator WaitForKeyDown(Action<string> callback)
        {
            yield return new WaitUntil(() => CanContinue);
            gameObject.SetActive(false);
            callback(Dropdown.options[Dropdown.value].text);
        }

        private void TryContinue()
        {
            CanContinue = true;
        }
    }
}