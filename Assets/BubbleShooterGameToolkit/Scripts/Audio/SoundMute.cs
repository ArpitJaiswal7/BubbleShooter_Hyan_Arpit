
 










using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.Audio
{
    public class SoundMute : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private CanvasRenderer canvasRenderer;
        public string volumeVariable = "soundVolume";
        public TextMeshProUGUI text;
        private IEventSystemHandler m_Toggle;

        private void Awake()
        {
            m_Toggle = GetComponent<IEventSystemHandler>();
        }

        void Start()
        {
            if (m_Toggle.GetType() == typeof(Toggle))
                ((Toggle)m_Toggle).onValueChanged.AddListener(delegate { Mute(); });
            else if (m_Toggle.GetType() == typeof(Slider))
                ((Slider)m_Toggle).onValueChanged.AddListener(delegate { Mute(); });
        }
        private void OnEnable()
        {
            SetSound(PlayerPrefs.GetInt(volumeVariable));
        }

        public void Mute()
        {
            if(!GetStatus()) PlayerPrefs.SetInt(volumeVariable,-80);
            else PlayerPrefs.SetInt(volumeVariable,0);
            PlayerPrefs.Save();
            SetSound(PlayerPrefs.GetInt(volumeVariable));
        }

        private bool GetStatus()
        {
            if (m_Toggle.GetType() == typeof(Toggle))
                return ((Toggle) m_Toggle).isOn;
            else return ((Slider) m_Toggle).value == 1;
        }

        private void SetSound(int getInt)
        {
            audioMixer.SetFloat(volumeVariable, getInt);
            if (canvasRenderer != null) canvasRenderer.SetAlpha(getInt < 0 ? 0.3f : 1);
            if (text != null) text.text = getInt < 0 ? "OFF" : "ON";
            if (m_Toggle.GetType() == typeof(Toggle))
                ((Toggle) m_Toggle).isOn = getInt >= 0;
            else ((Slider) m_Toggle).value = getInt < 0 ? 0 : 1;
        }
    }
}