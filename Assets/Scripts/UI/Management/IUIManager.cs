using Interfaces;
using UI.UIManagement;
using UI.View;
using UnityEngine.Events;

namespace UI.Management
{
    public interface IUIManager : IManager
    {
        #region ShowMethods

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="viewType">Desired view type</param>
        void ShowView(UIViewType viewType);

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="viewType">Desired view type</param>
        /// <param name="data">Relevant view data</param>
        void ShowView(UIViewType viewType, UIViewData data);

        /*/// <summary>
        /// Show view at top layer (basically treat as popup)
        /// </summary>
        /// <param name="viewType">Desired view type</param>
        /// <param name="data">Relevant view data</param>
        /// <param name="specialInstruction">Instruction for Show() method of desired view</param>
        void ShowAtTop(UIViewType viewType, UIViewData data = null, byte specialInstruction = 0);*/
        

        #endregion

        #region CloseMethods

        /// <summary>
        /// Close Desired view
        /// </summary>
        /// <param name="viewType">Desired view type</param>
        /// <param name="success">Success callback if you wanna track the result</param>
        /// <param name="destroy">Should view be destroyed after closing or not</param>
        void CloseView(UIViewType viewType, UnityAction success = null, bool destroy = false);

        #endregion

        #region GetMethods
        
        /// <summary>
        /// Returns precached view (regardless if its active or not)
        /// Returns null if none found
        /// </summary>
        /// <typeparam name="T">Type of desired view. Has to be derived from UIView</typeparam>
        /// <returns></returns>
        T GetOpenedView<T>() where T : UIView;
        
        /*/// <summary>
        /// Returns specific Home object, that's located at HomeView i.e. Top panel, Loot progress bar etc.
        /// Returns null if none found or if HomeView is not exists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetHomeObject<T>() where T : HomeObject;*/
        
        #endregion

        #region CheckMethods

        /// <summary>
        /// Returns true if only home view is active in hierarchy
        /// </summary>
        /// <returns></returns>
        bool IsHomeView(bool closePopUps = true);
        
        /// <summary>
        /// Returns true if specific view is active in hierarchy
        /// </summary>
        /// <param name="type">view type</param>
        /// <returns></returns>
        bool IsViewActive(UIViewType type);

        /// <summary>
        /// Returns true if specific view is cached
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsViewPresent(UIViewType type);

        /// <summary>
        /// Return true if at least one view is active now
        /// </summary>
        bool IsAnyViewActive();

        #endregion

        #region Other

        /// <summary>
        /// Closes all active views (not destroys them)
        /// </summary>
        void CloseAllActiveViews();
        
        /// <summary>
        /// Closes active view
        /// </summary>
        void CloseActiveView();
        
        void ConformMainCanvas(bool on);

        /// <summary>
        /// Destroys all precached views. UI Manager uses it when scene is changed
        /// </summary>
        void DisposeActiveViews();

        #endregion
    }
}