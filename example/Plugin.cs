namespace example
{
    public class Plugin : Qurre.Plugin
    {
        public EventHandlers EventHandlers;
        #region override
        public override string Developer { get; } = "Qurre Team";
        public override string Name { get; } = "Example Plugin";
        public override System.Version Version { get; } = new System.Version(1, 0, 0);
        public override System.Version NeededQurreVersion { get; } = new System.Version(1, 1, 1);
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        #endregion
        #region RegEvents
        private void RegisterEvents()
        {
            EventHandlers = new EventHandlers(this);
            Qurre.Events.Round.WaitingForPlayers += EventHandlers.WaitingForPlayers;
            Qurre.Events.Player.Join += EventHandlers.PlayerJoin;
        }
        #endregion
        #region UnregEvents
        private void UnregisterEvents()
        {
            Qurre.Events.Round.WaitingForPlayers -= EventHandlers.WaitingForPlayers;
            Qurre.Events.Player.Join -= EventHandlers.PlayerJoin;
            EventHandlers = null;
        }
        #endregion
    }
}