using System;
using System.Timers;

namespace Robot.Wanderer.Components
{
	/// <summary>
	/// Descriptor of a wheel 
	/// </summary>
	internal sealed class Wheel
	{
		private bool enabled;
		private double radius;
		//private double speed;
		private double distance;
        private Timer rotationTimer;
		private long rotations;

		internal enum Direction
		{
			Forward,
			Reverse
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="radius">The radius of the wheel, this will be used to calculate circumference and thus distance</param>
		/// <param name="speed">The speed at which the wheel rotates, in rotations per second</param>
		internal Wheel(double radius, double speed)
		{
			rotationTimer = new Timer(1000);
            rotationTimer.Elapsed += new ElapsedEventHandler(RotationTimerElapsed);
            this.radius = radius;
            //this.speed = speed;
		}

		private void RotationTimerElapsed(object sender, ElapsedEventArgs e)
		{
            rotations++;
            distance = (Math.PI * (2 * radius)) * rotations;
		}

				
		internal void Enable(Direction direction)
		{
            enabled = true;
            rotationTimer.Enabled = true;
		}

		internal void Disable()
		{
            enabled = false;
            rotationTimer.Enabled = false;
		}


		internal bool Enabled
		{
            get { return enabled; }
		}

		internal double Radius
		{
            get { return radius; }
		}

		internal double Distance
		{
            get { return distance; }
		}
	}
}
