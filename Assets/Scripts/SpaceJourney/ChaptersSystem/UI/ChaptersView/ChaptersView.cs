using System.Collections.Generic;
using ChaptersSystem.Configs;
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
        private const float CENTERING_ANIMATION_DURATION = 1.2f;
        private const float CENTERING_ANIMATION_DELAY = 0.6f;

        public override void Init()
        {
            base.Init();
        }

        public override void Show()
        {
        }

        public override void Hide()
        {
            base.Hide();
            HideChaptersList();
            gameObject.SetActive(false);
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
         
        }

        #endregion
    }
}