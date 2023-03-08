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

        //[SerializeField] private GameObject _completedTick;
        private const string DEFAULT_PREVIEW_SPRITE = "JourneyPreviewDefault";
        private const float LOCK_ANIMATION_SCALE = 10f;
        private const float LOCK_ANIMATION_DURATION = 1f;
        private const float FADER_ANIMATION_DURATION = 2f;
        private ChapterConfig _config;

        public ChapterConfig Config => _config;

        public void Init(ChapterConfig config)
        {
            /*_config = config;
            Sprite previewSprite = GameContext.GetInstance<ITileSpriteProvider>().GetSprite(config.ChapterPreviewID);
            if (previewSprite == null) previewSprite = GameContext.GetInstance<ITileSpriteProvider>().GetSprite(DEFAULT_PREVIEW_SPRITE);
            _preview.sprite = previewSprite;
            _nameText.text = _config.ChapterName;
            _numberText.text = $"Chapter {_config.ChapterNumber}";

            JourneySaveData data = GameContext.GetInstance<IDataManager>().GetGameData().JourneySaveData;
            bool isChapterAvailable = _config.IsAvailableInGame;
            bool isChapterUnlocked = data.TryGetChapter(_config.ChapterNumber, out ChapterProgress progress);
            _fader.color = _defaultFaderColor;
            _lock.transform.localScale = Vector3.one;
            _lock.color = _defaultColor;
            _fader.gameObject.SetActive(!isChapterAvailable || !isChapterUnlocked);
            _comingSoonLabel.SetActive(!isChapterAvailable);
            _lock.gameObject.SetActive(!isChapterUnlocked && isChapterAvailable);

            UpdateProgressBar(progress, data.LastWonLevel);*/
        }

        public void SwitchLockedChapter(bool locked)
        {
            /*HomeView homeView = GameContext.GetInstance<IUIManager>().GetOpenedView<HomeView>();
            bool isChapterAvailable = _config.IsAvailableInGame;
            if (locked)
            {
                if (homeView != null)
                {
                    homeView.HomeBar.Block();
                }
                UpdateProgressBar(null, 0);
                _fader.gameObject.SetActive(true);
                _lock.gameObject.SetActive(true);
            }
            else
            {
                JourneySaveData data = GameContext.GetInstance<IDataManager>().GetGameData().JourneySaveData;
                bool isChapterUnlocked = data.TryGetChapter(_config.ChapterNumber, out ChapterProgress progress);
                if (isChapterAvailable && isChapterUnlocked)
                {
                    GameContext.GetInstance<ISoundManager>().PlaySound(SoundTypes.OpenChapter);
                    Sequence unlockAnimation = DOTween.Sequence();
                    Sequence unFadeAnimation = DOTween.Sequence();
                    unlockAnimation.onComplete = UnFadeAnimation;
                    unFadeAnimation.onComplete = OnAnimationsComplete;
                    unlockAnimation.Append(_lock.transform.DOScale(LOCK_ANIMATION_SCALE, LOCK_ANIMATION_DURATION));
                    unlockAnimation.Join(_lock.DOColor(_transparentColor, LOCK_ANIMATION_DURATION));
                    unlockAnimation.Play();

                    void UnFadeAnimation()
                    {
                        unlockAnimation?.Kill(true);
                        unFadeAnimation.Append(_fader.DOColor(_transparentColor, FADER_ANIMATION_DURATION));
                        unFadeAnimation.Play();
                    }

                    void OnAnimationsComplete()
                    {
                        unFadeAnimation?.Kill(true);
                        if (homeView != null)
                        {
                            homeView.HomeBar.Unblock();
                        }
                    }
                }
                else
                {
                    _comingSoonLabel.SetActive(!isChapterAvailable);
                    _fader.gameObject.SetActive(true);
                    _lock.gameObject.SetActive(true);
                }
            }*/
        }

        private void UpdateProgressBar(ChapterProgress progress, int lastWonLevel)
        {
            /*if (progress == null)
            {
                UpdateProgressLine(0, 0, 0);
                //  _completedTick.SetActive(false);
                _progressText.text = $"Levels {_config.StartLevel}-{_config.EndLevel}";
                return;
            }

            switch (progress.ChapterState)
            {
                case ChapterState.Active:
                    int progressBarMax = _config.EndLevel - _config.StartLevel + 1;
                    int progressBarCurrent = lastWonLevel - _config.StartLevel + 1;
                    UpdateProgressLine(_config.StartLevel - 1, _config.EndLevel, lastWonLevel);
                    _progressText.text = $"{progressBarCurrent}/{progressBarMax}";
                    break;

                case ChapterState.ReachedEnd:
                    UpdateProgressLine(_config.StartLevel, _config.EndLevel, _config.EndLevel);
                    _progressText.text = "End of chapter reached";
                    break;

                case ChapterState.Completed:
                    //  _completedTick.SetActive(true);
                    _progressText.text = $"Completed";
                    UpdateProgressLine(_config.StartLevel, _config.EndLevel, _config.EndLevel);
                    break;
            }*/
        }

        private void UpdateProgressLine(int min, int max, int current)
        {
            _progressBar.minValue = min;
            _progressBar.maxValue = max;
            _progressBar.value = current;
        }
    }
}