using System;
using System.Dynamic;

namespace Zuul
{
	public class Player
	{
		public Room currentRoom;
		public Item item;
		public float health = 10f;
		public bool alive = true;
		public bool hurt = false;
		public Inventory inventory = new Inventory(10);

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

		public void IsHurt(bool h)
		{
			if (h)
			{
				hurt = true;
			}
			else
			{
				hurt = false;
			}
		}
	}
}
