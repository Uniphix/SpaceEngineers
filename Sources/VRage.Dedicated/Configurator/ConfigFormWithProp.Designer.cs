using VRage.Game;

namespace VRage.Dedicated
{
    partial class ConfigFormWithProp<T> where T : MyObjectBuilder_SessionSettings, new()
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
            this.components = new System.ComponentModel.Container();
            this.startGameButton = new System.Windows.Forms.RadioButton();
            this.loadGameButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.worldListTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.battleButton = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.newGameSettingsPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.scenarioCB = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.editConfigButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stopServiceButton = new System.Windows.Forms.Button();
            this.getBackButton = new System.Windows.Forms.Button();
            this.restartServiceButton = new System.Windows.Forms.Button();
            this.serviceStatusLabel = new System.Windows.Forms.Label();
            this.serviceStatusValueLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.serviceUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.battleListTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox_SaveGames = new System.Windows.Forms.ComboBox();
            this.propertyGrid_ServerConfig = new System.Windows.Forms.PropertyGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.newGameSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.AutoSize = true;
            this.startGameButton.Location = new System.Drawing.Point(10, 18);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(76, 17);
            this.startGameButton.TabIndex = 1;
            this.startGameButton.Text = "New game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.CheckedChanged += new System.EventHandler(this.startTypeRadio_CheckedChanged);
            // 
            // loadGameButton
            // 
            this.loadGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadGameButton.AutoSize = true;
            this.loadGameButton.Checked = true;
            this.loadGameButton.Location = new System.Drawing.Point(10, 36);
            this.loadGameButton.Name = "loadGameButton";
            this.loadGameButton.Size = new System.Drawing.Size(89, 17);
            this.loadGameButton.TabIndex = 2;
            this.loadGameButton.TabStop = true;
            this.loadGameButton.Text = "Saved worlds";
            this.loadGameButton.UseVisualStyleBackColor = true;
            this.loadGameButton.CheckedChanged += new System.EventHandler(this.startTypeRadio_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(551, 710);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(149, 48);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "&Save && start";
            this.toolTip1.SetToolTip(this.startButton, "Save current configuration and start dedicated server");
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // worldListTimer
            // 
            this.worldListTimer.Enabled = true;
            this.worldListTimer.Tick += new System.EventHandler(this.worldListTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(349, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 507);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.battleButton);
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.newGameSettingsPanel);
            this.groupBox1.Controls.Add(this.startGameButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.loadGameButton);
            this.groupBox1.Location = new System.Drawing.Point(1, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 589);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game settings";
            // 
            // battleButton
            // 
            this.battleButton.AutoSize = true;
            this.battleButton.Location = new System.Drawing.Point(10, 54);
            this.battleButton.Name = "battleButton";
            this.battleButton.Size = new System.Drawing.Size(82, 17);
            this.battleButton.TabIndex = 12;
            this.battleButton.TabStop = true;
            this.battleButton.Text = "Castle siege";
            this.battleButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 76);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_SaveGames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid_ServerConfig);
            this.splitContainer1.Size = new System.Drawing.Size(337, 507);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 11;
            // 
            // newGameSettingsPanel
            // 
            this.newGameSettingsPanel.Controls.Add(this.label5);
            this.newGameSettingsPanel.Controls.Add(this.scenarioCB);
            this.newGameSettingsPanel.Location = new System.Drawing.Point(349, 14);
            this.newGameSettingsPanel.Name = "newGameSettingsPanel";
            this.newGameSettingsPanel.Size = new System.Drawing.Size(350, 57);
            this.newGameSettingsPanel.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Scenario:";
            // 
            // scenarioCB
            // 
            this.scenarioCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scenarioCB.FormattingEnabled = true;
            this.scenarioCB.Location = new System.Drawing.Point(104, 7);
            this.scenarioCB.Name = "scenarioCB";
            this.scenarioCB.Size = new System.Drawing.Size(215, 21);
            this.scenarioCB.TabIndex = 8;
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(102, 18);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(90, 23);
            this.saveConfigButton.TabIndex = 9;
            this.saveConfigButton.Text = "&Save";
            this.toolTip1.SetToolTip(this.saveConfigButton, "Save configuration data to current config file");
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // editConfigButton
            // 
            this.editConfigButton.Location = new System.Drawing.Point(197, 19);
            this.editConfigButton.Name = "editConfigButton";
            this.editConfigButton.Size = new System.Drawing.Size(90, 23);
            this.editConfigButton.TabIndex = 17;
            this.editConfigButton.Text = "&Edit...";
            this.toolTip1.SetToolTip(this.editConfigButton, "Open current config file in Notepad");
            this.editConfigButton.UseVisualStyleBackColor = true;
            this.editConfigButton.Click += new System.EventHandler(this.editConfigButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Location = new System.Drawing.Point(102, 43);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(90, 23);
            this.reloadButton.TabIndex = 22;
            this.reloadButton.Text = "&Reload";
            this.toolTip1.SetToolTip(this.reloadButton, "Reload data from current config file");
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(197, 44);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(90, 23);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "&Reset";
            this.toolTip1.SetToolTip(this.resetButton, "Reset current configuration to default data");
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(7, 44);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(90, 23);
            this.saveAsButton.TabIndex = 20;
            this.saveAsButton.Text = "S&ave as...";
            this.toolTip1.SetToolTip(this.saveAsButton, "Save configuration data to external file");
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "&Load from...";
            this.toolTip1.SetToolTip(this.button1, "Load configuration data from external file");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.loadConfigButton_Click);
            // 
            // stopServiceButton
            // 
            this.stopServiceButton.Location = new System.Drawing.Point(101, 19);
            this.stopServiceButton.Name = "stopServiceButton";
            this.stopServiceButton.Size = new System.Drawing.Size(90, 23);
            this.stopServiceButton.TabIndex = 11;
            this.stopServiceButton.Text = "Stop";
            this.toolTip1.SetToolTip(this.stopServiceButton, "Stop currently running service");
            this.stopServiceButton.UseVisualStyleBackColor = true;
            this.stopServiceButton.Click += new System.EventHandler(this.stopServiceButton_Click);
            // 
            // getBackButton
            // 
            this.getBackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.getBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.getBackButton.Location = new System.Drawing.Point(551, 685);
            this.getBackButton.Name = "getBackButton";
            this.getBackButton.Size = new System.Drawing.Size(149, 23);
            this.getBackButton.TabIndex = 12;
            this.getBackButton.Text = "Back to instances";
            this.toolTip1.SetToolTip(this.getBackButton, "Return to list of dedicated server instances");
            this.getBackButton.UseVisualStyleBackColor = true;
            this.getBackButton.Click += new System.EventHandler(this.getBackButton_Click);
            // 
            // restartServiceButton
            // 
            this.restartServiceButton.Location = new System.Drawing.Point(6, 19);
            this.restartServiceButton.Name = "restartServiceButton";
            this.restartServiceButton.Size = new System.Drawing.Size(90, 23);
            this.restartServiceButton.TabIndex = 15;
            this.restartServiceButton.Text = "Restart";
            this.toolTip1.SetToolTip(this.restartServiceButton, "Restart currently running service");
            this.restartServiceButton.UseVisualStyleBackColor = true;
            this.restartServiceButton.Click += new System.EventHandler(this.restartServiceButton_Click);
            // 
            // serviceStatusLabel
            // 
            this.serviceStatusLabel.AutoSize = true;
            this.serviceStatusLabel.Location = new System.Drawing.Point(24, 48);
            this.serviceStatusLabel.Name = "serviceStatusLabel";
            this.serviceStatusLabel.Size = new System.Drawing.Size(77, 13);
            this.serviceStatusLabel.TabIndex = 13;
            this.serviceStatusLabel.Text = "Service status:";
            // 
            // serviceStatusValueLabel
            // 
            this.serviceStatusValueLabel.AutoSize = true;
            this.serviceStatusValueLabel.Location = new System.Drawing.Point(103, 48);
            this.serviceStatusValueLabel.Name = "serviceStatusValueLabel";
            this.serviceStatusValueLabel.Size = new System.Drawing.Size(63, 13);
            this.serviceStatusValueLabel.TabIndex = 14;
            this.serviceStatusValueLabel.Text = "Service info";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPictureBox.BackColor = System.Drawing.Color.Black;
            this.logoPictureBox.Location = new System.Drawing.Point(1, 2);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(699, 98);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoPictureBox.TabIndex = 5;
            this.logoPictureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.reloadButton);
            this.groupBox3.Controls.Add(this.resetButton);
            this.groupBox3.Controls.Add(this.saveAsButton);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.editConfigButton);
            this.groupBox3.Controls.Add(this.saveConfigButton);
            this.groupBox3.Location = new System.Drawing.Point(7, 687);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 73);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuration";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.restartServiceButton);
            this.groupBox4.Controls.Add(this.stopServiceButton);
            this.groupBox4.Controls.Add(this.serviceStatusLabel);
            this.groupBox4.Controls.Add(this.serviceStatusValueLabel);
            this.groupBox4.Location = new System.Drawing.Point(343, 687);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(198, 72);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Service";
            // 
            // serviceUpdateTimer
            // 
            this.serviceUpdateTimer.Enabled = true;
            this.serviceUpdateTimer.Interval = 1000;
            this.serviceUpdateTimer.Tick += new System.EventHandler(this.serviceUpdateTimer_Tick);
            // 
            // battleListTimer
            // 
            this.battleListTimer.Enabled = true;
            this.battleListTimer.Tick += new System.EventHandler(this.battleListTimer_Tick);
            // 
            // comboBox_SaveGames
            // 
            this.comboBox_SaveGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_SaveGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SaveGames.Location = new System.Drawing.Point(0, 0);
            this.comboBox_SaveGames.Name = "comboBox_SaveGames";
            this.comboBox_SaveGames.Size = new System.Drawing.Size(337, 21);
            this.comboBox_SaveGames.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBox_SaveGames, "Saved Worlds List");
            this.comboBox_SaveGames.SelectedIndexChanged += new System.EventHandler(this.comboBox_SaveGames_SelectedIndexChanged);
            // 
            // propertyGrid_ServerConfig
            // 
            this.propertyGrid_ServerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_ServerConfig.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid_ServerConfig.Name = "propertyGrid_ServerConfig";
            this.propertyGrid_ServerConfig.Size = new System.Drawing.Size(337, 480);
            this.propertyGrid_ServerConfig.TabIndex = 0;
            // 
            // ConfigFormWithProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 763);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.getBackButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 16384);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 400);
            this.Name = "ConfigFormWithProp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medieval engineers - Dedicated server configurator";
            this.Load += new System.EventHandler(this.ConfigFormWithProp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.newGameSettingsPanel.ResumeLayout(false);
            this.newGameSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton startGameButton;
        private System.Windows.Forms.RadioButton loadGameButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer worldListTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox scenarioCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel newGameSettingsPanel;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.Button stopServiceButton;
        private System.Windows.Forms.Button getBackButton;
        private System.Windows.Forms.Label serviceStatusLabel;
        private System.Windows.Forms.Label serviceStatusValueLabel;
        private System.Windows.Forms.Button restartServiceButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button editConfigButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Timer serviceUpdateTimer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton battleButton;
        private System.Windows.Forms.Timer battleListTimer;
        private System.Windows.Forms.ComboBox comboBox_SaveGames;
        private System.Windows.Forms.PropertyGrid propertyGrid_ServerConfig;
    }
}

