using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class InputModalController : MonoBehaviour
    {
        [field: SerializeField]
        private TextMeshProUGUI Tittle { get; set; }
        
        [field: SerializeField]
        private TMP_InputField InputField { get; set; }
        
        [field: SerializeField]
        private Button ContinueButton { get; set; }

        private bool CanContinue { get; set; }
        
        public void GetInput(string tittle, Action<string> callback)
        {
            gameObject.SetActive(true);
            
            Tittle.SetText(tittle);
            ContinueButton.onClick.AddListener(TryContinue);
            StartCoroutine(WaitForKeyDown(callback));
        }
        
        private IEnumerator WaitForKeyDown(Action<string> callback)
        {
            yield return new WaitUntil(() => CanContinue);
            gameObject.SetActive(false);
            callback(InputField.text);
        }

        private void TryContinue()
        {
            CanContinue = true;
        }
    }
}