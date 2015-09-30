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
            this.SuspendLayout();
            // 
            // componentsView
            // 
            this.componentsView.Location = new System.Drawing.Point(12, 12);
            this.componentsView.Name = "componentsView";
            this.componentsView.Size = new System.Drawing.Size(379, 445);
            this.componentsView.TabIndex = 0;
            this.componentsView.UseCompatibleStateImageBehavior = false;
            // 
            // componentChanges
            // 
            this.componentChanges.Location = new System.Drawing.Point(397, 12);
            this.componentChanges.Name = "componentChanges";
            this.componentChanges.Size = new System.Drawing.Size(389, 445);
            this.componentChanges.TabIndex = 1;
            this.componentChanges.Text = "";
            // 
            // ComponentsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 469);
            this.Controls.Add(this.componentChanges);
            this.Controls.Add(this.componentsView);
            this.Name = "ComponentsPanel";
            this.Text = "Componenten paneel";
            this.Load += new System.EventHandler(this.ComponentsPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView componentsView;
        private System.Windows.Forms.RichTextBox componentChanges;
    }
}

