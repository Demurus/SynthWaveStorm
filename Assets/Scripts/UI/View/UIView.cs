using DG.Tweening;
using GameBase;
using UI.Management;
using UI.UIManagement;
using UnityEngine;

namespace UI.View
{
    public class UIView : MonoBehaviour
    {
        public UIViewType Type;

        [SerializeField] protected CanvasGroup _internalPanel;
        [SerializeField] protected float _fadeSpeed = 0.5f;

        private Sequence _fadeInSequence;
        private Sequence _fadeOutSequence;

        public virtual void Init()
        {
        }

        public virtual void SetData(UIViewData data)
        {
        }

        public virtual void Show()
        {
            RegisterEvents();
            gameObject.SetActive(true);
            if (_internalPanel != null)
            {
                if (_fadeInSequence == null) _fadeInSequence = DOTween.Sequence();
                _fadeInSequence.onComplete = OnFadeInComplete;
                _fadeInSequence.Append(_internalPanel.DOFade(1, _fadeSpeed).From(_internalPanel.alpha));
                _fadeInSequence.Play();
            }

            // GameContext.GetInstance<IEventBus>().Emmit<IViewChanged>(s => s.OnViewOpened(Type));
            void OnFadeInComplete()
            {
                _fadeInSequence?.Kill(true);
            }
        }


        public virtual void Hide()
        {
            UnregisterEvents();

            if (_internalPanel != null)
            {
                if (_fadeOutSequence == null) _fadeOutSequence = DOTween.Sequence();
                _fadeOutSequence.onComplete = OnFadeOutComplete;
                _fadeOutSequence.Append(_internalPanel.DOFade(0, _fadeSpeed).From(_internalPanel.alpha));
                _fadeOutSequence.Play();
            }
            else
            {
                gameObject.SetActive(false);
            }

            void OnFadeOutComplete()
            {
                gameObject.SetActive(false);
                _fadeOutSequence?.Kill(true);
            }

            // GameContext.GetInstance<IEventBus>().Emmit<IViewChanged>(s => s.OnViewClosed(Type));
        }

        public virtual void Close()
        {
            GameContext.GetInstance<IUIManager>().CloseView(Type, null, false);
        }

        public virtual void Dispose()
        {
            UnregisterEvents();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        public virtual void RegisterEvents()
        {
        }

        public virtual void UnregisterEvents()
        {
        }

        protected virtual void SwitchAlpha(bool on)
        {
            if (_internalPanel == null) return;
            if (on) _internalPanel.alpha = 1f;
            else _internalPanel.alpha = 0;
        }
    }
}