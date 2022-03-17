namespace CodeSnippetEditor
{
    partial class ConfigForm
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
            this.expandPanel1 = new System.Windows.Forms.ExpandPanel();
            this.expandPanel2 = new System.Windows.Forms.ExpandPanel();
            this.SuspendLayout();
            // 
            // expandPanel1
            // 
            this.expandPanel1.Location = new System.Drawing.Point(140, 191);
            this.expandPanel1.Name = "expandPanel1";
            this.expandPanel1.Size = new System.Drawing.Size(488, 228);
            this.expandPanel1.TabIndex = 0;
            // 
            // expandPanel2
            // 
            this.expandPanel2.BackColor = System.Drawing.Color.Black;
            this.expandPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.expandPanel2.Location = new System.Drawing.Point(164, 66);
            this.expandPanel2.Name = "expandPanel2";
            this.expandPanel2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.expandPanel2.Size = new System.Drawing.Size(200, 1);
            this.expandPanel2.TabIndex = 1;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.expandPanel2);
            this.Controls.Add(this.expandPanel1);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ExpandPanel expandPanel1;
        private System.Windows.Forms.ExpandPanel expandPanel2;
    }
}