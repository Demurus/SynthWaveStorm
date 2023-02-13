using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EventsManagement;
using GameBase;
using UI.UIManagement;
using UI.View;

namespace UI.Management
{
    public class UIManager : MonoBehaviour, IUIManager, ISceneLoaded
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private Canvas _popUpCanvas;
        [SerializeField] private GraphicRaycaster _raycater;
        [SerializeField] private GraphicRaycaster _popupsRaycater;

        [SerializeField] private GameObject _loadingCanvas;
        private Dictionary<UIViewType, UIView> _cachedViews;
        private UIView _currentView;
        private UIView _currentPopUp;
        private IEventsManager _eventsManager;
        private const int POPUPS_ENUM_START = 100;

        public void Init()
        {
            _cachedViews = new Dictionary<UIViewType, UIView>();
            _eventsManager = GameContext.GetInstance<IEventsManager>();
            _eventsManager.Subscribe<ISceneLoaded>(this);
        }

        public void OnSceneLoaded(Scenes sceneName, LoadSceneMode mode)
        {
            DisposeActiveViews();
            switch (sceneName)
            {
                //case Scenes.InitScene:
                case Scenes.GameMenu:
                    ShowView(UIViewType.HomeView);
                    break;
                case Scenes.LevelScene:
                    break;
            }
        }

        public void ShowView(UIViewType viewType)
        {
            ShowView(viewType, null);
        }

        /*public void ShowAtTop(UIViewType viewType, UIViewData data = null, byte specialInstruction = 0)
        {
            if (_cachedViews.TryGetValue(viewType, out UIView cachedView))
            {
                RebaseToCanvas(cachedView, _popUpCanvas);
                ShowPreCachedPopUp(cachedView, data, specialInstruction);
            }
            else
                InstantiateAndShowPopUp(viewType, data, specialInstruction);
        }*/

        public void ShowView(UIViewType viewType, UIViewData data)
        {
            if (viewType == UIViewType.Loading)
            {
                _loadingCanvas.SetActive(true);
                return;
            }

            if (IsPopUp(viewType))
            {
                //Treat view as popUp
                if (_cachedViews.TryGetValue(viewType, out UIView cachedPopUp))
                    ShowPreCachedPopUp(cachedPopUp, data);
                else
                    InstantiateAndShowPopUp(viewType, data);
            }
            else
            {
                //Treat view as view
                if (_cachedViews.TryGetValue(viewType, out UIView cachedView))
                    ShowPreCachedView(cachedView, data);
                else
                    InstantiateAndShowView(viewType, data);
            }
        }

        private bool IsPopUp(UIViewType viewType)
        {
            //Check if view is popUp
            return (int) viewType >= POPUPS_ENUM_START;
        }

        public void CloseView(UIViewType viewType, UnityAction success, bool destroy = false)
        {
            if (viewType == UIViewType.Loading)
            {
                _loadingCanvas.SetActive(false);
                return;
            }

            UIView result;
            if (_cachedViews.TryGetValue(viewType, out result))
            {
                result.Hide();

                if (destroy)
                {
                    _cachedViews.Remove(viewType);
                    Destroy(result.gameObject);
                }
            }

            success?.Invoke();
        }

        private void ShowPreCachedPopUp(UIView cachedPopUp, UIViewData data)
        {
            cachedPopUp.transform.SetAsLastSibling();
            cachedPopUp.SetData(data);
            cachedPopUp.Init();
            cachedPopUp.Show();

            //If view is treated as popup, it still has to be assigned as view
            if (IsPopUp(cachedPopUp.Type)) _currentPopUp = cachedPopUp;
            else _currentView = cachedPopUp;
        }

        private void ShowPreCachedView(UIView cachedView, UIViewData data)
        {
            RebaseToCanvas(cachedView, _mainCanvas); // returning view into main canvas in case last time this view was spawned as popup

            _currentView = cachedView;
            if (_currentView.Type == UIViewType.HomeView) CloseAllActiveViews();
            else _currentView.transform.SetAsLastSibling();

            if (data != null) _currentView.SetData(data);
            _currentView.Show();
        }

        private void InstantiateAndShowView(UIViewType viewType, UIViewData data)
        {
            UIView view = Resources.Load<UIView>(viewType.ToString());
            if (view == null)
            {
                Debug.LogError($"No view found by {viewType} type");
                return;
            }

            UIView instantiatedView = Instantiate(view, _mainCanvas.transform);
            _cachedViews.Add(instantiatedView.Type, instantiatedView);

            _currentView = instantiatedView;
            _currentView.Init();
            if (data != null) _currentView.SetData(data);
            _currentView.Show();
        }

        private void InstantiateAndShowPopUp(UIViewType popUpType, UIViewData data)
        {
            UIView popUp = Resources.Load<UIView>(popUpType.ToString());
            if (popUp == null)
            {
                Debug.LogError($"No popUp found by {popUpType} type");
                return;
            }

            UIView instantiatedPopUp = Instantiate(popUp, _popUpCanvas.transform);
            _cachedViews.Add(instantiatedPopUp.Type, instantiatedPopUp);
            instantiatedPopUp.SetData(data);
            instantiatedPopUp.Init();
            instantiatedPopUp.Show();

            //If view is treated as popup, it still has to be assigned as view
            if (IsPopUp(instantiatedPopUp.Type)) _currentPopUp = instantiatedPopUp;
            else _currentView = instantiatedPopUp;
        }

        public T GetOpenedView<T>() where T : UIView
        {
            UIView result = _cachedViews.FirstOrDefault(view => view.Value.GetType() == typeof(T)).Value;
            return result as T;
        }

        private T GetOpenedView<T>(UIViewType type) where T : UIView
        {
            UIView result = _cachedViews.FirstOrDefault(view => view.Key == type).Value;
            return result as T;
        }

        /*public T GetHomeObject<T>() where T : HomeObject
        {
            HomeView homeView = GetOpenedView<HomeView>();
            if (homeView == null) return null;

            HomeObject result = homeView.HomeContainer.GetHomeObject<T>();
            return (T) result;
        }*/

        private void DisableOpenedView()
        {
            if (_currentView != null && _currentView.gameObject.activeInHierarchy)
                _currentView.Hide();
        }

        public bool IsHomeView(bool closePopUps = true)
        {
            if (_currentView == null) return false;
            if (_currentView.Type == UIViewType.HomeView && _currentView.gameObject.activeInHierarchy)
            {
                if (_currentPopUp != null && closePopUps) _currentPopUp.Close();
                return true;
                /*if (_currentPopUp != null && _currentView.gameObject.activeInHierarchy) return false;
                return true;*/
            }
            else return false;
        }

        public void ConformMainCanvas(bool on)
        {
            CanvasScaler canvasScaler = _mainCanvas.gameObject.GetComponent<CanvasScaler>();
            if (on)
                canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;
            else
                canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        }


        public void CloseAllActiveViews()
        {
            foreach (KeyValuePair<UIViewType, UIView> view in _cachedViews)
            {
                if (view.Value.gameObject.activeInHierarchy) view.Value.Close();
            }
        }

        private void RebaseToCanvas(UIView cachedView, Canvas canvas)
        {
            if (cachedView.transform.parent == canvas.transform) return;

            cachedView.transform.SetParent(canvas.transform);
            cachedView.transform.SetAsLastSibling();
        }

        public void CloseActiveView()
        {
            _currentView?.Close();
            _currentPopUp?.Close();
        }

        public bool IsViewActive(UIViewType type)
        {
            UIView target = GetOpenedView<UIView>(type);
            if (target == null) return false;
            return target.gameObject.activeSelf;
        }

        public bool IsViewPresent(UIViewType type)
        {
            UIView target = GetOpenedView<UIView>(type);
            return target != null;
        }

        public bool IsAnyViewActive()
        {
            bool isAnyActive = false;

            foreach (KeyValuePair<UIViewType, UIView> view in _cachedViews)
                if (IsViewActive(view.Key))
                    return true;

            return isAnyActive;
        }


        public void DisposeActiveViews()
        {
            if (_cachedViews.Count > 0)
            {
                foreach (KeyValuePair<UIViewType, UIView> view in _cachedViews)
                {
                    if (view.Value == null) continue;
                    view.Value.Dispose();
                }
            }

            _cachedViews?.Clear();
        }

        public void Dispose()
        {
            _eventsManager.UnSubscribe<ISceneLoaded>(this);
        }
    }
}