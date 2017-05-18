using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstGame
{
	public class Barrel
	{
		// Animation representing the enemy
		private Animation barrelAnimation;

		// The position of the enemy ship relative to the top left corner of thescreen
		public Vector2 Position;

		// The state of the Enemy Ship
		private bool active;

		private Viewport view;

		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		// The amount of damage the enemy inflicts on the player ship
		private int damage;

		public int Damage
		{
			get { return damage; }
			set { damage = value; }
		}



		// Get the width of the enemy ship
		public int Width
		{
			get { return barrelAnimation.FrameWidth; }
		}

		// Get the height of the enemy ship
		public int Height
		{
			get { return barrelAnimation.FrameHeight; }
		}

		// The speed at which the enemy moves
		private float barrelMoveSpeed;

		public void Initialize(Animation animation, Vector2 position, Viewport gameView)
		{
			view = gameView;
			// Load the enemy ship texture
			barrelAnimation = animation;

			// Set the position of the enemy
			Position = position;

			// We initialize the enemy to be active so it will be update in the game
			Active = true;


			// Set the amount of damage the enemy can do
			Damage = 4;

			// Set how fast the enemy moves
			barrelMoveSpeed = 6f;

		}

		public void Update(GameTime gameTime)
		{
			// The enemy always moves to the left so decrement it's xposition
			Position.X += barrelMoveSpeed;

			// Update the position of the Animation
			barrelAnimation.Position = Position;

			// Update Animation
			barrelAnimation.Update(gameTime);

			// If the enemy is past the screen or its health reaches 0 then deactivateit
			if (Position.X + Width / 2 > view.Width)
			{
				// By setting the Active flag to false, the game will remove this objet fromthe
				// active game list
				Active = false;
			}
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			// Draw the animation
			barrelAnimation.Draw(spriteBatch);
		}
	}
}
