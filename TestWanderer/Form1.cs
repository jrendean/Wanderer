using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Robot.Wanderer;
using System.Collections;
using System.Threading;

namespace TestWanderer
{
	public partial class Form1 : Form
	{
        private Dictionary<Guid, Robot.Wanderer.Bot> bots = new Dictionary<Guid, Robot.Wanderer.Bot>();
        
        public Form1()
		{
			InitializeComponent();
		}
        
		private void Form1_Load(object sender, EventArgs e)
		{
            listBoxExisting.Items.Clear();
            foreach (string filename in System.IO.Directory.GetFiles(Environment.CurrentDirectory + "\\RobotData", "*.eprom"))
                listBoxExisting.Items.Add(System.IO.Path.GetFileNameWithoutExtension(filename));
		}

		private void buttonCreateRandomListener_Click(object sender, EventArgs e)
		{
			Robot.Wanderer.Bot bot = Robot.Wanderer.Bot.CreateRandomListener();
            AddBot(bot);
		}
		private void buttonCreateListener_Click(object sender, EventArgs e)
		{
			if (comboBoxListenerCommTypes.Text == String.Empty)
				MessageBox.Show("You must select an entry");
			else
			{
				Robot.Wanderer.Enums.CommunicationTypes commType = (Robot.Wanderer.Enums.CommunicationTypes)Enum.Parse(typeof(Robot.Wanderer.Enums.CommunicationTypes), comboBoxListenerCommTypes.Text);
				Robot.Wanderer.Bot bot = Robot.Wanderer.Bot.CreateListener(commType);
                AddBot(bot);
			}
		}
		private void buttonCreateGenZero_Click(object sender, EventArgs e)
		{
			if (comboBoxGenZeroCommTypes.Text == String.Empty)
				MessageBox.Show("You must select an entry");
			else
			{
				Robot.Wanderer.Enums.CommunicationTypes commType = (Robot.Wanderer.Enums.CommunicationTypes)Enum.Parse(typeof(Robot.Wanderer.Enums.CommunicationTypes), comboBoxGenZeroCommTypes.Text);
				Robot.Wanderer.Bot bot = Robot.Wanderer.Bot.CreateGenZero(commType);
                AddBot(bot);
			}
		}
		private void buttonCreateExisting_Click(object sender, EventArgs e)
		{
			if (listBoxExisting.SelectedIndex == -1)
				MessageBox.Show("You must select an entry");
			else
			{
                if (bots.ContainsKey(new Guid(listBoxExisting.SelectedItem.ToString())))
                    MessageBox.Show("Bot already created");
                else
                {
                    Robot.Wanderer.Bot bot = Robot.Wanderer.Bot.CreateExisting(new Guid(listBoxExisting.SelectedItem.ToString()));
                    AddBot(bot);
                }
			}
		}

        private void AddBot(Bot bot)
        {
            bots.Add(bot.EPROM.ID, bot);

            treeViewRobotList.Nodes.Add(GenerateTreeNode(bot));
            arena.AddBot(bot);
        }

        private TreeNode GenerateTreeNode(Robot.Wanderer.Bot bot)
        {
            TreeNode tn = new TreeNode(bot.EPROM.ID.ToString());

            tn.Nodes.Add(new TreeNode("ID: " + bot.EPROM.ID.ToString()));
            tn.Nodes.Add(new TreeNode("Communication Type: " + bot.EPROM.CommunicationType));
            tn.Nodes.Add(new TreeNode("Bump Sensors: " + bot.EPROM.BumpSensors));
            if (bot.EPROM.History == null)
            {
                tn.Nodes.Add(new TreeNode("Movement Count: N/A"));
                tn.Nodes.Add(new TreeNode("Transmission Count: N/A"));
                tn.Nodes.Add(new TreeNode("Reception Count: N/A"));
            }
            else
            {
                tn.Nodes.Add(new TreeNode("Movement Count: " + bot.EPROM.History.MovementCount));
                tn.Nodes.Add(new TreeNode("Transmission Count: " + bot.EPROM.History.TransmissionCount));
                tn.Nodes.Add(new TreeNode("Reception Count: " + bot.EPROM.History.ReceptionCount));
            }

            tn.Nodes.Add(new TreeNode("OS Type: " + bot.OS.Type));
            tn.Nodes.Add(new TreeNode("OS Generation: " + bot.OS.Generation));
            tn.Nodes.Add(new TreeNode("OS Process Running: " + bot.OS.Process.Running.ToString()));
            tn.Nodes.Add(new TreeNode("OS Process Fault: " + bot.OS.Process.Fault.ToString()));

            //PopulateExisting();

            return tn;
        }





        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            //right
            MoveBot(Robot.Wanderer.Enums.MovementDirection.Right);
        }
        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            //left
            MoveBot(Robot.Wanderer.Enums.MovementDirection.Left);
        }
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            //up
            MoveBot(Robot.Wanderer.Enums.MovementDirection.Forward);
        }
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            //down
            MoveBot(Robot.Wanderer.Enums.MovementDirection.Backward);
        }
        private void buttonMoveStop_Click(object sender, EventArgs e)
        {
            //stop
            MoveBot(Robot.Wanderer.Enums.MovementDirection.None);
        }

        private void MoveBot(Robot.Wanderer.Enums.MovementDirection direction)
        {
            if (treeViewRobotList.SelectedNode == null)
                return;

            Robot.Wanderer.Bot bot = bots[new Guid(treeViewRobotList.SelectedNode.Text)];

            bot.DriveTrain.Move(direction);
        }
	}
}