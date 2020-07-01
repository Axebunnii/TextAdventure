﻿using System;
using System.Diagnostics;

namespace Zuul
{
	public class Game
	{
		private Parser parser;
		private Player player;
		public Hammer hammer = new Hammer("hammer", 5);
		public Potion potion = new Potion("magic potion", 2);

		public Game ()
		{
			player = new Player();
			createRooms();
			parser = new Parser();
		}

		private void createRooms()
		{
			Room outside, theatre, pub, lab, office, kitchen, library;

			// create the rooms
			outside = new Room("outside the main entrance of the university");
			theatre = new Room("in a lecture theatre");
			pub = new Room("in the campus pub");
			lab = new Room("in a computing lab");
			office = new Room("in the computing admin office");
			kitchen = new Room("in the kitchen");
			library = new Room("in the library");

			//initialise room exits and items
			// Outside
			outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);

			outside.setInventory(null, null);

			// Theatre
			theatre.setExit("west", outside);
			theatre.setExit("up", kitchen);

			theatre.setInventory("hammer", hammer);

			// Pub
			pub.setExit("east", outside);
			pub.setExit("down", library);

			pub.setInventory(null, null);
			// Lab
			lab.setExit("north", outside);
			lab.setExit("east", office);

			lab.setInventory("potion", potion);

			// Office
			office.setExit("west", lab);

			office.setInventory(null, null);

			// Kitchen
			kitchen.setExit("down", theatre);

			kitchen.setInventory("potion", potion);

			// Library
			library.setExit("up", pub);

			library.setInventory(null, null);



			player.currentRoom = outside;
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
			}
			if (player.alive == false)
			{
				Console.WriteLine("You died");
			}
			else
			{
				Console.WriteLine("Thank you for playing.");
			}
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					if (player.alive == false)
					{
						wantToQuit = true;
					}
					goRoom(command);
					break;
				case "look":
					goLook();
					break;
				case "take":
					goTake(command);
					break;
				case "drop":
					goDrop(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */

		//makes the player able to switch rooms
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentRoom.getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("There is no door to " + direction + "!");
			} else {
				player.Damage(1);
				player.currentRoom = nextRoom;
				Console.WriteLine(player.currentRoom.getLongDescription());
			}
		}

		//makes the player look around the room again
		private void goLook()
		{
			Console.WriteLine(player.currentRoom.getLongDescription());
		}

		//makes the player able to pick up items
		private void goTake(Command command)
		{
			if (!command.hasSecondWord())
			{
				// if there is no second command, we don't know what to pick up...
				Console.WriteLine("Take what?");
				return;
			}

			/*string pickup = command.getSecondWord();
			
			Item someItem = player.currentRoom.getRoomInventory();

			if (someItem == null)
			{
				Console.WriteLine("There is no " + someItem + " in this room!");
			}
			else
			{
				Console.WriteLine("You put the item in your inventory");
			}*/
		}

		//makes the player able to drop items
		private void goDrop(Command command)
		{
			if (!command.hasSecondWord())
			{
				// if there is no second command, we don't know what to drop...
				Console.WriteLine("Drop what?");
				return;
			}
		}
	}
}
