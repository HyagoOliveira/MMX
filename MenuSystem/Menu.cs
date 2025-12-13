using UnityEngine;
using System.Collections.Generic;

namespace MMX.MenuSystem
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]

    public sealed class Menu : MonoBehaviour
    {
        [field: SerializeField] public AudioSource Audio { get; private set; }

        [field: Space]
        [field: SerializeField] public AbstractMenuScreen FirstScreen { get; private set; }

        public AbstractMenuScreen LastScreen { get; private set; }
        public AbstractMenuScreen CurrentScreen { get; private set; }
        public Dictionary<string, AbstractMenuScreen> Screens { get; private set; }

        private readonly Stack<AbstractMenuScreen> undoHistory = new();

        private void Reset()
        {
            Audio = GetComponent<AudioSource>();
        }

        private void Awake() => InitializeScreens();
        private void OnEnable() => TryOpenFirstScreen();

        /// <summary>
        /// Enables or disables the sending of navigation events globally.
        /// </summary>
        /// <param name="enabled">
        /// Should the EventSystem allow navigation events (move/submit/cancel).
        /// </param>
        public static void SetSendNavigationEvents(bool enabled)
        {
            var eventSystem = UnityEngine.EventSystems.EventSystem.current;
            if (eventSystem) eventSystem.sendNavigationEvents = enabled;
        }

        public async void OpenScreen(AbstractMenuScreen screen, bool undoable = true)
        {
            SetSendNavigationEvents(false);
            DisposeElements();

            LastScreen = CurrentScreen;

            await CurrentScreen.FadeOutAsync();
            HideAllScreens();

            if (undoable)
            {
                var hasLastController = LastScreen != null;
                if (hasLastController) undoHistory.Push(LastScreen);
            }

            CurrentScreen = screen;
            CurrentScreen.Show();

            await CurrentScreen.FadeInAsync();

            InitializeElements();
            SetSendNavigationEvents(true);
        }

        private void TryOpenFirstScreen()
        {
            if (FirstScreen == null) return;
            OpenScreen(FirstScreen, undoable: false);
        }

        private void InitializeScreens()
        {
            var screens = GetComponentsInChildren<AbstractMenuScreen>(includeInactive: true);
            Screens = new(screens.Length);

            foreach (var screen in screens)
            {
                screen.Initialize(this);
                Screens.Add(screen.GetIdentifier(), screen);
            }
        }

        private void HideAllScreens()
        {
            foreach (var screen in Screens.Values)
            {
                screen.Hide();
            }
        }

        private void InitializeElements()
        {
            //Highlighter.Initialize(CurrentScreen.Root);
            //FocusPlayer.Initialize(CurrentScreen.Root);
            //ButtonClickPlayer.Initialize(CurrentScreen.Root);
        }

        private void DisposeElements()
        {
            //Highlighter.Dispose();
            //FocusPlayer.Dispose();
            //ButtonClickPlayer.Dispose();
        }
    }
}