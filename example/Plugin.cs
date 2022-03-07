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
        public override System.Version NeededQurreVersion { get; } = new System.Version(1, 11, 0); /* <- needed version of qurre(optional) */
        public override void Reload() => base.Reload(); /* <- method called by plugin reloading(optional) */
        public override void Enable(){
            CustomConfig = new Config();
            CustomConfigs.Add(CustomConfig); /* <- Add and initialize the configuration */
            EventHandlers = new EventHandlers(this); /* <- class declaration with events */
            RegisterEvents();
        } /* <- method called by enabling the plugin */
        public override void Disable() {
            UnregisterEvents();
            EventHandlers = null; /* <- deleting a class with events */
            CustomConfigs.Clear(); /* <- clear the list of configs */
        } /* <- method called by plugin disabling */
        public Config CustomConfig { get; private set; } /* <- creating a new config class */
        #endregion
        #region RegEvents
        /* registration of events(you can use any name) */
        private void RegisterEvents()
        {
            Qurre.Events.Round.Waiting += EventHandlers.WaitingForPlayers; /* <- method register */
            Qurre.Events.Player.Join += EventHandlers.PlayerJoin; /* <- method register */
        }
        #endregion
        #region UnregEvents
        private void UnregisterEvents()
        {
            Qurre.Events.Round.Waiting -= EventHandlers.WaitingForPlayers; /* <- method unregister */
            Qurre.Events.Player.Join -= EventHandlers.PlayerJoin; /* <- method unregister */
        }
        #endregion
    }
}