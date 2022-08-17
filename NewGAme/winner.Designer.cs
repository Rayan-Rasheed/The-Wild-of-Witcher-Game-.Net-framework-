
namespace NewGAme
{
    partial class winner
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
            this.btnclose = new System.Windows.Forms.Button();
            this.btnlvl2 = new System.Windows.Forms.Button();
            this.btnStarting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(302, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(41, 35);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnlvl2
            // 
            this.btnlvl2.Location = new System.Drawing.Point(179, 377);
            this.btnlvl2.Name = "btnlvl2";
            this.btnlvl2.Size = new System.Drawing.Size(75, 23);
            this.btnlvl2.TabIndex = 1;
            this.btnlvl2.Text = "Level2";
            this.btnlvl2.UseVisualStyleBackColor = true;
            this.btnlvl2.Click += new System.EventHandler(this.btnlvl2_Click);
            // 
            // btnStarting
            // 
            this.btnStarting.Location = new System.Drawing.Point(77, 377);
            this.btnStarting.Name = "btnStarting";
            this.btnStarting.Size = new System.Drawing.Size(74, 23);
            this.btnStarting.TabIndex = 2;
            this.btnStarting.Text = "Back";
            this.btnStarting.UseVisualStyleBackColor = true;
            this.btnStarting.Click += new System.EventHandler(this.btnStarting_Click);
            // 
            // winner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NewGAme.Properties.Resources.winner;
            this.ClientSize = new System.Drawing.Size(355, 494);
            this.Controls.Add(this.btnStarting);
            this.Controls.Add(this.btnlvl2);
            this.Controls.Add(this.btnclose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "winner";
            this.Text = "winner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnlvl2;
        private System.Windows.Forms.Button btnStarting;
    }
}