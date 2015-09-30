namespace BlackSwan.WinForm
{
    partial class ComponentsPanel
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
            this.componentsView = new System.Windows.Forms.ListView();
            this.componentChanges = new System.Windows.Forms.RichTextBox();
            this.connectArduino = new System.Windows.Forms.Button();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // componentsView
            // 
            this.componentsView.Location = new System.Drawing.Point(12, 12);
            this.componentsView.Name = "componentsView";
            this.componentsView.Size = new System.Drawing.Size(379, 397);
            this.componentsView.TabIndex = 0;
            this.componentsView.UseCompatibleStateImageBehavior = false;
            this.componentsView.DoubleClick += new System.EventHandler(this.componentsView_DoubleClick);
            // 
            // componentChanges
            // 
            this.componentChanges.Location = new System.Drawing.Point(397, 12);
            this.componentChanges.Name = "componentChanges";
            this.componentChanges.Size = new System.Drawing.Size(389, 397);
            this.componentChanges.TabIndex = 1;
            this.componentChanges.Text = "";
            // 
            // connectArduino
            // 
            this.connectArduino.Location = new System.Drawing.Point(579, 415);
            this.connectArduino.Name = "connectArduino";
            this.connectArduino.Size = new System.Drawing.Size(207, 23);
            this.connectArduino.TabIndex = 2;
            this.connectArduino.Text = "Verbinding maken met Arduino";
            this.connectArduino.UseVisualStyleBackColor = true;
            this.connectArduino.Click += new System.EventHandler(this.connectArduino_Click);
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(397, 415);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(176, 20);
            this.ipAddress.TabIndex = 3;
            // 
            // ComponentsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.connectArduino);
            this.Controls.Add(this.componentChanges);
            this.Controls.Add(this.componentsView);
            this.Name = "ComponentsPanel";
            this.Text = "Componenten paneel";
            this.Load += new System.EventHandler(this.ComponentsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView componentsView;
        private System.Windows.Forms.RichTextBox componentChanges;
        private System.Windows.Forms.Button connectArduino;
        private System.Windows.Forms.TextBox ipAddress;
    }
}

