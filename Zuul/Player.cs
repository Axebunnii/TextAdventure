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
		public int hurtAmount = 0;
		public Inventory inventory = new Inventory(10);

		public Player()
		{

		}

		public void Damage(float amount)
		{
			float totalDamage = amount * hurtAmount;
			health -= totalDamage;
			Console.WriteLine("You lost " + totalDamage + " health.\n" + "health: " + health);
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
				hurtAmount += 1;
			}
			else
			{
				hurt = false;
			}
		}
	}
}
