using System;
using System.Dynamic;

namespace Zuul
{
	public class Player
	{
		public Room currentRoom;
		public float health = 10f;
		public bool alive = true;
		public Inventory inventory;

		public Player()
		{

		}

		public void Damage(float amount)
		{
			health -= amount;
			Console.WriteLine("health: " + health);
			IsAlive();
		}

		public void Heal(float amount)
		{

		}

		public void IsAlive()
		{
			if (health <= 0)
			{
				alive = false;
			}
		}
	}
}
