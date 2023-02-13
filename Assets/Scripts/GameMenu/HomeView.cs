using System.Collections.Generic;
using DataSystem;
using EventsManagement;
using GameBase;
using UI.Management;
using UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace GameMenu
{
    public class HomeView : UIView
    {
        // [SerializeField] private HomeContainer _homeContainer;
        [SerializeField] private List<ViewPart> _parts;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _shopButton;
        private IEventsManager _eventsManager;

        private IDataManager _data;

        // private ISoundManager _soundManager;
        private IUIManager _uiManager;
        // private IChaptersConfigData _ccd;

        // public HomeScreenBottomBar HomeBar => _bottomPanel;

        //  public HomeContainer HomeContainer => _homeContainer;

        public override void Init()
        {
            base.Init();
            _eventsManager = GameContext.GetInstance<IEventsManager>();
            _data = GameContext.GetInstance<IDataManager>();
            // _soundManager = GameContext.GetInstance<ISoundManager>();
            _uiManager = GameContext.GetInstance<IUIManager>();
            //  _ccd = GameContext.GetInstance<IConfigsManager>().Configs.ChaptersConfig;
            // _bottomPanel.Init();
            _parts.ForEach(p => p.Init());
        }

        public override void Show()
        {
            base.Show();
            _parts.ForEach(p => p.Show());
        }
        
        public override void Hide()
        {
            _parts.ForEach(p => p.Hide());
            base.Hide();
        }

        public override void Dispose()
        {
            _parts.ForEach(p => p.Dispose());
            base.Dispose();
        }

        public override void RegisterEvents()
        {
            base.RegisterEvents();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _shopButton.onClick.AddListener(OnShopButtonClick);
            
            _parts.ForEach(p => p.RegisterEvents());
            //  _lootManager.OnLootStateUpdated += AnimateStarsIfNeeded;
        }

        public override void UnregisterEvents()
        {
            base.UnregisterEvents();
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
            _shopButton.onClick.RemoveListener(OnShopButtonClick);
            
            _parts.ForEach(p => p.UnregisterEvents());
        }

        private void OnPlayButtonClick()
        {
            SceneLoader.Load(Scenes.LevelScene);
        }

        private void OnSettingsButtonClick()
        {
        }

        private void OnShopButtonClick()
        {
        }
    }
}