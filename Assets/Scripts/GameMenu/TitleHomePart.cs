using DG.Tweening;
using UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace GameMenu
{
    public class TitleHomePart : ViewPart
    {
        [SerializeField] private Transform _target;
        [SerializeField] private int vibrato;
        [SerializeField] private int randomness;
        [SerializeField] private Vector3 dir;
        [SerializeField] private Button _but;
        private Sequence _floating;

        public override void Init()
        {
            base.Init();
            if (_floating == null) _floating = DOTween.Sequence();
            _but.onClick.AddListener(startanit);
        }

        void startanit()
        {
            _floating.Kill(true);
            _floating.Append(_target.transform.DOShakePosition(2.0f, dir, vibrato,  randomness, false, false));
            _floating.SetLoops(-1);
            _floating.Play();
        }

        public override void Show()
        {
            base.Show();
            _floating.Append(_target.transform.DOShakePosition(1.0f, dir, vibrato,  randomness, false, false));
            _floating.SetLoops(-1);
            _floating.Play();
        }

        public override void Hide()
        {
            base.Hide();
            _floating.Kill(true);
        }

        public override void Dispose()
        {
            base.Dispose();
            _floating.Kill(true);
        }
    }
}