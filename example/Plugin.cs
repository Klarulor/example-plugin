namespace example
{
    public class Plugin : Qurre.Plugin /* <- indicate that the plugin inherits Qurre.Plugin */
    {
        public EventHandlers EventHandlers; /* <- declare a class with events, because it is not static */
        #region override
        /* variable names must match */
        public override string Developer { get; } = "Qurre Team"; /* <- plugin developer(optional) */
        public override string Name { get; } = "Example Plugin"; /* <- plugin name(optional) */
        public override System.Version Version { get; } = new System.Version(1, 0, 0); /* <- plugin version(optional) */
        public override System.Version NeededQurreVersion { get; } = new System.Version(1, 1, 1); /* <- needed version of qurre(optional) */
        public override void Reload() => base.Reload(); /* <- method called by plugin reloading(optional) */
        public override void Enable() => RegisterEvents(); /* <- method called by enabling the plugin */
        public override void Disable() => UnregisterEvents(); /* <- method called by plugin disabling */
        #endregion
        #region RegEvents
        /* registration of events(you can use any name) */
        private void RegisterEvents()
        {
            EventHandlers = new EventHandlers(this); /* <- class declaration with events */
            Qurre.Events.Round.WaitingForPlayers += EventHandlers.WaitingForPlayers; /* <- method register */
            Qurre.Events.Player.Join += EventHandlers.PlayerJoin; /* <- method register */
        }
        #endregion
        #region UnregEvents
        private void UnregisterEvents()
        {
            Qurre.Events.Round.WaitingForPlayers -= EventHandlers.WaitingForPlayers; /* <- method unregister */
            Qurre.Events.Player.Join -= EventHandlers.PlayerJoin; /* <- method unregister */
            EventHandlers = null; /* <- deleting a class with events */
        }
        #endregion
    }
}