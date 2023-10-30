using ChaptersSystem.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SpaceJourney.SaveData;

namespace ChaptersSystem.UI.ChaptersView
{
    public class ChapterViewItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _numberText;
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private Slider _progressBar;
        [SerializeField] private Image _preview;
        [SerializeField] private Image _lock;
        [SerializeField] private Image _fader;
        [SerializeField] private GameObject _comingSoonLabel;
        [SerializeField] private Color _transparentColor;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _defaultFaderColor;
        
        private const string DEFAULT_PREVIEW_SPRITE = "JourneyPreviewDefault";
        private const float LOCK_ANIMATION_SCALE = 10f;
        private const float LOCK_ANIMATION_DURATION = 1f;
        private const float FADER_ANIMATION_DURATION = 2f;
        private ChapterConfig _config;

        public ChapterConfig Config => _config;

        public void Init(ChapterConfig config)
        {
          
        }
    }
}