namespace TestWanderer
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.treeViewRobotList = new System.Windows.Forms.TreeView();
            this.buttonCreateRandomListener = new System.Windows.Forms.Button();
            this.buttonCreateExisting = new System.Windows.Forms.Button();
            this.listBoxExisting = new System.Windows.Forms.ListBox();
            this.buttonCreateGenZero = new System.Windows.Forms.Button();
            this.buttonCreateListener = new System.Windows.Forms.Button();
            this.comboBoxListenerCommTypes = new System.Windows.Forms.ComboBox();
            this.comboBoxGenZeroCommTypes = new System.Windows.Forms.ComboBox();
            this.buttonMoveRight = new System.Windows.Forms.Button();
            this.buttonMoveStop = new System.Windows.Forms.Button();
            this.buttonMoveLeft = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.arena = new TestWanderer.Arena();
            this.SuspendLayout();
            // 
            // treeViewRobotList
            // 
            this.treeViewRobotList.HideSelection = false;
            this.treeViewRobotList.Location = new System.Drawing.Point(12, 175);
            this.treeViewRobotList.Name = "treeViewRobotList";
            this.treeViewRobotList.Size = new System.Drawing.Size(372, 437);
            this.treeViewRobotList.TabIndex = 2;
            // 
            // buttonCreateRandomListener
            // 
            this.buttonCreateRandomListener.Location = new System.Drawing.Point(12, 13);
            this.buttonCreateRandomListener.Name = "buttonCreateRandomListener";
            this.buttonCreateRandomListener.Size = new System.Drawing.Size(98, 21);
            this.buttonCreateRandomListener.TabIndex = 5;
            this.buttonCreateRandomListener.Text = "Random Listener";
            this.buttonCreateRandomListener.UseVisualStyleBackColor = true;
            this.buttonCreateRandomListener.Click += new System.EventHandler(this.buttonCreateRandomListener_Click);
            // 
            // buttonCreateExisting
            // 
            this.buttonCreateExisting.Location = new System.Drawing.Point(12, 40);
            this.buttonCreateExisting.Name = "buttonCreateExisting";
            this.buttonCreateExisting.Size = new System.Drawing.Size(98, 21);
            this.buttonCreateExisting.TabIndex = 6;
            this.buttonCreateExisting.Text = "Exisiting";
            this.buttonCreateExisting.UseVisualStyleBackColor = true;
            this.buttonCreateExisting.Click += new System.EventHandler(this.buttonCreateExisting_Click);
            // 
            // listBoxExisting
            // 
            this.listBoxExisting.FormattingEnabled = true;
            this.listBoxExisting.Location = new System.Drawing.Point(12, 70);
            this.listBoxExisting.Name = "listBoxExisting";
            this.listBoxExisting.Size = new System.Drawing.Size(278, 95);
            this.listBoxExisting.TabIndex = 7;
            // 
            // buttonCreateGenZero
            // 
            this.buttonCreateGenZero.Location = new System.Drawing.Point(115, 40);
            this.buttonCreateGenZero.Name = "buttonCreateGenZero";
            this.buttonCreateGenZero.Size = new System.Drawing.Size(98, 21);
            this.buttonCreateGenZero.TabIndex = 8;
            this.buttonCreateGenZero.Text = "Gen Zero";
            this.buttonCreateGenZero.UseVisualStyleBackColor = true;
            this.buttonCreateGenZero.Click += new System.EventHandler(this.buttonCreateGenZero_Click);
            // 
            // buttonCreateListener
            // 
            this.buttonCreateListener.Location = new System.Drawing.Point(115, 13);
            this.buttonCreateListener.Name = "buttonCreateListener";
            this.buttonCreateListener.Size = new System.Drawing.Size(98, 21);
            this.buttonCreateListener.TabIndex = 9;
            this.buttonCreateListener.Text = "Listener";
            this.buttonCreateListener.UseVisualStyleBackColor = true;
            this.buttonCreateListener.Click += new System.EventHandler(this.buttonCreateListener_Click);
            // 
            // comboBoxListenerCommTypes
            // 
            this.comboBoxListenerCommTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListenerCommTypes.FormattingEnabled = true;
            this.comboBoxListenerCommTypes.Items.AddRange(new object[] {
            "None",
            "IR",
            "RF",
            "IR, RF"});
            this.comboBoxListenerCommTypes.Location = new System.Drawing.Point(219, 14);
            this.comboBoxListenerCommTypes.Name = "comboBoxListenerCommTypes";
            this.comboBoxListenerCommTypes.Size = new System.Drawing.Size(71, 21);
            this.comboBoxListenerCommTypes.TabIndex = 10;
            // 
            // comboBoxGenZeroCommTypes
            // 
            this.comboBoxGenZeroCommTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenZeroCommTypes.FormattingEnabled = true;
            this.comboBoxGenZeroCommTypes.Items.AddRange(new object[] {
            "None",
            "IR",
            "RF",
            "IR, RF"});
            this.comboBoxGenZeroCommTypes.Location = new System.Drawing.Point(219, 41);
            this.comboBoxGenZeroCommTypes.Name = "comboBoxGenZeroCommTypes";
            this.comboBoxGenZeroCommTypes.Size = new System.Drawing.Size(71, 21);
            this.comboBoxGenZeroCommTypes.TabIndex = 11;
            // 
            // buttonMoveRight
            // 
            this.buttonMoveRight.Location = new System.Drawing.Point(357, 70);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveRight.TabIndex = 14;
            this.buttonMoveRight.UseVisualStyleBackColor = true;
            this.buttonMoveRight.Click += new System.EventHandler(this.buttonMoveRight_Click);
            // 
            // buttonMoveStop
            // 
            this.buttonMoveStop.Location = new System.Drawing.Point(327, 70);
            this.buttonMoveStop.Name = "buttonMoveStop";
            this.buttonMoveStop.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveStop.TabIndex = 15;
            this.buttonMoveStop.UseVisualStyleBackColor = true;
            this.buttonMoveStop.Click += new System.EventHandler(this.buttonMoveStop_Click);
            // 
            // buttonMoveLeft
            // 
            this.buttonMoveLeft.Location = new System.Drawing.Point(297, 70);
            this.buttonMoveLeft.Name = "buttonMoveLeft";
            this.buttonMoveLeft.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveLeft.TabIndex = 16;
            this.buttonMoveLeft.UseVisualStyleBackColor = true;
            this.buttonMoveLeft.Click += new System.EventHandler(this.buttonMoveLeft_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Location = new System.Drawing.Point(327, 40);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveUp.TabIndex = 18;
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Location = new System.Drawing.Point(327, 100);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveDown.TabIndex = 20;
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // arena
            // 
            this.arena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arena.Location = new System.Drawing.Point(390, 12);
            this.arena.Name = "arena";
            this.arena.Size = new System.Drawing.Size(688, 600);
            this.arena.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 627);
            this.Controls.Add(this.arena);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.buttonMoveLeft);
            this.Controls.Add(this.buttonMoveStop);
            this.Controls.Add(this.buttonMoveRight);
            this.Controls.Add(this.comboBoxGenZeroCommTypes);
            this.Controls.Add(this.comboBoxListenerCommTypes);
            this.Controls.Add(this.buttonCreateListener);
            this.Controls.Add(this.buttonCreateGenZero);
            this.Controls.Add(this.listBoxExisting);
            this.Controls.Add(this.buttonCreateExisting);
            this.Controls.Add(this.buttonCreateRandomListener);
            this.Controls.Add(this.treeViewRobotList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewRobotList;
		private System.Windows.Forms.Button buttonCreateRandomListener;
		private System.Windows.Forms.Button buttonCreateExisting;
		private System.Windows.Forms.ListBox listBoxExisting;
		private System.Windows.Forms.Button buttonCreateGenZero;
		private System.Windows.Forms.Button buttonCreateListener;
		private System.Windows.Forms.ComboBox comboBoxListenerCommTypes;
        private System.Windows.Forms.ComboBox comboBoxGenZeroCommTypes;
		private System.Windows.Forms.Button buttonMoveRight;
		private System.Windows.Forms.Button buttonMoveStop;
        private System.Windows.Forms.Button buttonMoveLeft;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private Arena arena;
	}
}

