using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GDC.Player {
	[RequireComponent(typeof(Text))]
	public class PlayerItem : MonoBehaviour {

		public int player;
		// Use this for initialization
		void Start () {
			PlayerManager.OnUpdate += HandleOnUpdate;
		}

		void HandleOnUpdate ()
		{
			Player p = PlayerManager.instance.players[player];
			GetComponent<Text>().text = p.key.ToString();
		}
	}
}