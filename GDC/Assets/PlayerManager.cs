using UnityEngine;
using System.Collections;

namespace GDC.Player {
	public class Player {
		public KeyCode key = KeyCode.None;
		public int score;
	}

	public class PlayerManager : MonoBehaviour {
		[HideInInspector]
		public Player[] players;

		public int playerCount;

		public KeyCode[] keys;

		public delegate void UpdateAction();
		public static event UpdateAction OnUpdate;

		static public PlayerManager instance;

		void Start () {
			instance = this;
			players = new Player[playerCount+1];
		}

		public void Update() {
			bool needUpdate = false;
			for(int i=1;i<players.Length;i++) {
				if(players[i] == null) {
					players[i] = new Player();
				}
				if(players[i].key == KeyCode.None) {
					players[i].key = keys[Random.Range(0,keys.Length-1)];
					needUpdate = true;
				}

				if(Input.GetKeyDown(players[i].key)) {
					players[i].key = KeyCode.None;
					players[i].score++;
					needUpdate = true;
				}
			}
			OnUpdate();
		}
	}
}