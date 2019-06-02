using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Components;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Systems
{
    public sealed class DriveTrain
	{
		private Wheel rightWheel;
		private Wheel leftWheel;
        private bool isMoving;
        private MovementDirection direction = MovementDirection.None;

        public DriveTrain(double wheelRadius, double wheelSpeed)
		{
            this.rightWheel = new Wheel(wheelRadius, wheelSpeed);
            this.leftWheel = new Wheel(wheelRadius, wheelSpeed);
		}

        public void Move(MovementDirection direction)
		{
            this.isMoving = true;
            this.direction = direction;

			switch (direction)
			{
                case MovementDirection.None:
                    Stop();
                    break;
                
                case MovementDirection.Forward:
                    this.rightWheel.Enable(Wheel.Direction.Forward);
                    this.leftWheel.Enable(Wheel.Direction.Forward);
					break;
				
                case MovementDirection.Backward:
                    this.rightWheel.Enable(Wheel.Direction.Reverse);
                    this.leftWheel.Enable(Wheel.Direction.Reverse);
					break;
				
                case MovementDirection.Left:
                    this.rightWheel.Enable(Wheel.Direction.Forward);
                    this.leftWheel.Enable(Wheel.Direction.Reverse);
					break;
				
                case MovementDirection.Right:
                    this.rightWheel.Enable(Wheel.Direction.Reverse);
                    this.leftWheel.Enable(Wheel.Direction.Forward);
					break;
			}
		}

        public void Stop()
        {
            this.isMoving = false;
            this.rightWheel.Disable();
            this.leftWheel.Disable();
            this.direction = MovementDirection.None;
        }

        public bool IsMoving
        {
            get { return this.isMoving; }
        }

        public MovementDirection Direction
        {
            get { return this.direction; }
        }

        public double Distance
		{
            get { return Math.Max(leftWheel.Distance, rightWheel.Distance); }
		}
	}
}
