
namespace Swin_Adventure
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
            this.loadCommand = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.mainConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loadCommand
            // 
            this.loadCommand.Location = new System.Drawing.Point(302, 375);
            this.loadCommand.Name = "loadCommand";
            this.loadCommand.Size = new System.Drawing.Size(168, 23);
            this.loadCommand.TabIndex = 0;
            this.loadCommand.Text = "Load Command";
            this.loadCommand.UseVisualStyleBackColor = true;
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(12, 12);
            this.commandBox.Multiline = true;
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(776, 296);
            this.commandBox.TabIndex = 1;
            // 
            // mainConsole
            // 
            this.mainConsole.Location = new System.Drawing.Point(12, 334);
            this.mainConsole.Name = "mainConsole";
            this.mainConsole.Size = new System.Drawing.Size(776, 22);
            this.mainConsole.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainConsole);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.loadCommand);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadCommand;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.TextBox mainConsole;
    }
}

