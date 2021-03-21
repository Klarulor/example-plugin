using Qurre.API.Events;
using UnityEngine;
namespace example
{
	public class EventHandlers
	{
		private readonly Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;
		public void WaitingForPlayers()
		{
			GameObject.Find("StartRound").transform.localScale = Vector3.zero;
		}
		public void PlayerJoin(JoinEvent ev)
		{
			string str = $"\n<color=#00fffb>Welcome</color>\n<color=#09ff00>Enjoy game!</color>";
			ev.Player.ShowHint(str, 10);
		}
	}
}