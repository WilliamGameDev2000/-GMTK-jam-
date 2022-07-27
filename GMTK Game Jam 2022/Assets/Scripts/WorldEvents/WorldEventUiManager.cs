using System.Collections;
using TMPro;
using UnityEngine;

namespace WorldEvents
{
    public class WorldEventUiManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI worldEventPopupText;
        [SerializeField] private float popupDuration;

        private void OnEnable()
        {
            WorldEventManager.Instance.OnWorldEventTriggered += OnWorldEventTrigger;
        }

        private void OnDisable()
        {
            WorldEventManager.Instance.OnWorldEventTriggered -= OnWorldEventTrigger;
        }

        private void Start()
        {
            worldEventPopupText.gameObject.SetActive(false);  
        }

        private void OnWorldEventTrigger(string worldEvent)
        {
            worldEventPopupText.gameObject.SetActive(true);
            worldEventPopupText.text = worldEvent.Remove(0, 12) + "!";
            StartCoroutine(WorldEventPopupDuration());
        }

        private IEnumerator WorldEventPopupDuration()
        {
            yield return new WaitForSeconds(popupDuration);
            worldEventPopupText.gameObject.SetActive(false);
        }
    }
}
