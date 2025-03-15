
namespace Jumping_Frog
{
    partial class Load
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
            this.progressLoad = new System.Windows.Forms.ProgressBar();
            this.labelLoad = new System.Windows.Forms.Label();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressLoad
            // 
            this.progressLoad.Location = new System.Drawing.Point(92, 592);
            this.progressLoad.Name = "progressLoad";
            this.progressLoad.Size = new System.Drawing.Size(369, 10);
            this.progressLoad.TabIndex = 0;
            // 
            // labelLoad
            // 
            this.labelLoad.AutoSize = true;
            this.labelLoad.BackColor = System.Drawing.Color.Transparent;
            this.labelLoad.Font = new System.Drawing.Font("Walibi0615", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoad.ForeColor = System.Drawing.Color.White;
            this.labelLoad.Location = new System.Drawing.Point(252, 564);
            this.labelLoad.Name = "labelLoad";
            this.labelLoad.Size = new System.Drawing.Size(46, 25);
            this.labelLoad.TabIndex = 1;
            this.labelLoad.Text = "0%";
            // 
            // timerLoad
            // 
            this.timerLoad.Interval = 50;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Jumping_Frog.Properties.Resources.bg_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(561, 733);
            this.Controls.Add(this.labelLoad);
            this.Controls.Add(this.progressLoad);
            this.Name = "Load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jumping Frog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressLoad;
        private System.Windows.Forms.Label labelLoad;
        private System.Windows.Forms.Timer timerLoad;
    }
}

