using Qurre.API.Events;
using UnityEngine;
namespace example
{
	public class EventHandlers
	{
		private readonly Plugin plugin; /* <- plugin class(for accessing not static objects) */
		public EventHandlers(Plugin plugin) => this.plugin = plugin; /* <- class declaration */
		public void WaitingForPlayers() /* <- waiting for players */
		{
			GameObject.Find("StartRound").transform.localScale = Vector3.zero; /* <- resizing the player waiting window(zero - 0) */
		}
		public void PlayerJoin(JoinEvent ev /* <- event */) /* <- the method called by the player entering the server */
		{
			string str = $"\n<color=#00fffb>Welcome</color>\n<color=#09ff00>Enjoy game!</color>"; /* <- text */
			ev.Player.ShowHint(str, 10); /* <- shows hint with text for 10 sec */
		}
	}
}