using System.Collections.Generic;
using System.Linq;
using ChaptersSystem.Configs;
using ChaptersSystem.Enums;
using DataSystem;
using DG.Tweening;
using GameBase;
using SpaceJourney.Management;
using SpaceJourney.SaveData;
using UI.Management;
using UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace ChaptersSystem.UI.ChaptersView
{
    public class ChaptersView : UIView
    {
        [SerializeField] private ChapterViewItem _chapterPrefab;
        [SerializeField] private RectTransform _chaptersParent;
        [SerializeField] private ScrollRect _scroll;

        #region Debug

        [SerializeField] private Button _winLevelsButton;

        #endregion

        private List<ChapterViewItem> _chaptersList;
        private ChapterViewItem _currentChapter;
        private IJourneyManager _journeyManager;
        private const float CENTERING_ANIMATION_DURATION = 1.2f;
        private const float CENTERING_ANIMATION_DELAY = 0.6f;

        public override void Init()
        {
            base.Init();
            _journeyManager = GameContext.GetInstance<IJourneyManager>();
        }

        public override void Show()
        {
            /*if (_winLevelsButton != null)
                _winLevelsButton.gameObject.SetActive(Debug.isDebugBuild);

            FillChapters();
            base.Show(specialInstruction);
            ChaptersViewInstruction instruction = (ChaptersViewInstruction)specialInstruction;
            if (instruction == ChaptersViewInstruction.NewChapterUnlocked)
                GameContext.GetInstance<IEventBus>().Emmit<INewChapterUnlocked>(s => s.OnNewChapterUnlocked());
            HighLightActiveChapter(specialInstruction > 0);
            GameContext.GetInstance<IUIManager>().CloseView(UIViewType.Settings);*/
        }

        public override void Hide()
        {
            base.Hide();
            HideChaptersList();
            gameObject.SetActive(false);
        }

        private void FillChapters()
        {
            /*HideChaptersList();

            int count;
            List<ChapterConfig> chapters = _journeyManager.ChaptersConfig.Chapters;
            for (count = 0; count < chapters.Count; count++)
            {
                if (_chaptersList.ElementAtOrDefault(count) == null)
                {
                    InstantiateChapter(chapters[count]);
                }
                else
                {
                    _chaptersList[count].gameObject.SetActive(true);
                    _chaptersList[count].Init(chapters[count]);
                }
            }*/
        }

        private void InstantiateChapter(ChapterConfig config)
        {
            ChapterViewItem newChapter = Instantiate(_chapterPrefab, _chaptersParent);
            newChapter.gameObject.SetActive(true);
            newChapter.Init(config);
            newChapter.transform.SetAsFirstSibling();
            _chaptersList.Add(newChapter);
        }

        private void HighLightActiveChapter(bool animateChapterUnlock)
        {
            /*JourneySaveData data = GameContext.GetInstance<IDataManager>().GetGameData().JourneySaveData;
            ChapterProgress currentChapterProgress = data.ChaptersProgress.LastOrDefault(chapter => chapter.ChapterState == ChapterState.Active);
            if (currentChapterProgress == null) return;
            ChapterConfig currentChapterConfig = _journeyManager.ChaptersConfig.GetChapterByNumber(currentChapterProgress.ChapterNumber);
            _currentChapter = _chaptersList.FirstOrDefault(chapter => chapter.Config.ChapterNumber == currentChapterConfig.ChapterNumber);
            if (data.LastWonLevel < currentChapterConfig.StartLevel && animateChapterUnlock)
            {
                _currentChapter.SwitchLockedChapter(true);
                ChapterViewItem previousItem = _chaptersList.FirstOrDefault(chapter => chapter.Config.ChapterNumber == currentChapterConfig.ChapterNumber - 1);
                if (previousItem != null) _scroll.normalizedPosition = FindCenteredPosition(previousItem.GetComponent<RectTransform>());
                Sequence centeringAnimation = DOTween.Sequence();
                centeringAnimation.onComplete = OnAnimationComplete;
                centeringAnimation.AppendInterval(CENTERING_ANIMATION_DELAY);
                centeringAnimation.Append(_scroll.DONormalizedPos(FindCenteredPosition(_currentChapter.GetComponent<RectTransform>()), CENTERING_ANIMATION_DURATION));

                void OnAnimationComplete()
                {
                    centeringAnimation?.Kill(true);
                    _currentChapter.SwitchLockedChapter(false);
                }
            }
            else
                _scroll.normalizedPosition = FindCenteredPosition(_currentChapter.GetComponent<RectTransform>());*/
        }

        private Vector2 FindCenteredPosition(RectTransform element)
        {
            Canvas.ForceUpdateCanvases();
            RectTransform scroll = _scroll.transform as RectTransform;
            RectTransform content = _scroll.content;
            Vector3 itemCenterPositionInScroll = scroll.InverseTransformPoint(GetVisibleWorldPoint(element));
            Vector3 targetPositionInScroll = scroll.InverseTransformPoint(GetVisibleWorldPoint(scroll));
            Vector3 difference = targetPositionInScroll - itemCenterPositionInScroll;
            difference.z = 0f;

            if (!_scroll.horizontal) difference.x = 0f;
            if (!_scroll.vertical) difference.y = 0f;

            Vector2 normalizedDifference =
                new Vector2(difference.x / (content.rect.size.x - scroll.rect.size.x),
                    difference.y / (content.rect.size.y - scroll.rect.size.y));
            Vector2 newNormalizedPosition = _scroll.normalizedPosition - normalizedDifference;
            newNormalizedPosition.x = Mathf.Clamp01(newNormalizedPosition.x);
            newNormalizedPosition.y = Mathf.Clamp01(newNormalizedPosition.y);
            return newNormalizedPosition;
        }

        private Vector3 GetVisibleWorldPoint(RectTransform target)
        {
            Vector3 pivotOffset = new Vector3((0.5f - target.pivot.x) * target.rect.size.x,
                (0.5f - target.pivot.y) * target.rect.size.y, 0f);
            Vector3 localPosition = target.localPosition + pivotOffset;
            return target.parent.TransformPoint(localPosition);
        }

        private void HideChaptersList()
        {
            if (_chaptersList == null) _chaptersList = new List<ChapterViewItem>();
            if (_chaptersList.Count > 0) _chaptersList.ForEach(item => item.gameObject.SetActive(false));
        }

        private void ClearChaptersList()
        {
            if (_chaptersList == null || _chaptersList.Count == 0)
                return;
            foreach (ChapterViewItem chapter in _chaptersList)
            {
                Destroy(chapter.gameObject);
            }

            _chaptersList.Clear();
        }

        public override void RegisterEvents()
        {
            base.RegisterEvents();
            _winLevelsButton.onClick.AddListener(OnWinLevelsClick);
        }

        public override void UnregisterEvents()
        {
            base.UnregisterEvents();
            _winLevelsButton.onClick.RemoveListener(OnWinLevelsClick);
        }

        public override void Close()
        {
            ClearChaptersList();
            base.Close();
        }

        #region Debug

        /// <summary>
        /// Adds wins one by one, saves them. Use to check and debug Journey View
        /// </summary>
        private void OnWinLevelsClick()
        {
            /*IDataManager dataManager = GameContext.GetInstance<IDataManager>();
            int currentLevel = dataManager.GetGameData().CurrentLevel;
            int nextLevel = currentLevel + 1;
            GameContext.GetInstance<IEventBus>().Emmit<ILevelEnd>(s => s.OnLevelEnd(true));
            //if (currentLevel > _journeyManager.JourneySaves.LastWonLevel) nextLevel = currentLevel;
            // else nextLevel = currentLevel + 1;
            dataManager.GetGameData().SetLevel(nextLevel);
            dataManager.SaveGameData();
            FillChapters();*/
        }

        #endregion
    }
}