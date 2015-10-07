namespace BlackSwan.WinForm
{
    partial class ComponentInfo
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
            this.currentComponentValue = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.setComponentValue = new System.Windows.Forms.Button();
            this.componentValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // currentComponentValue
            // 
            this.currentComponentValue.Location = new System.Drawing.Point(12, 28);
            this.currentComponentValue.Name = "currentComponentValue";
            this.currentComponentValue.ReadOnly = true;
            this.currentComponentValue.Size = new System.Drawing.Size(526, 22);
            this.currentComponentValue.TabIndex = 0;
            this.currentComponentValue.Text = "Haaaalooo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Huidige waarde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "In te stellen waarde";
            // 
            // setComponentValue
            // 
            this.setComponentValue.Location = new System.Drawing.Point(12, 112);
            this.setComponentValue.Name = "setComponentValue";
            this.setComponentValue.Size = new System.Drawing.Size(526, 23);
            this.setComponentValue.TabIndex = 3;
            this.setComponentValue.Text = "Instellen";
            this.setComponentValue.UseVisualStyleBackColor = true;
            this.setComponentValue.Click += new System.EventHandler(this.setComponentValue_Click);
            // 
            // componentValue
            // 
            this.componentValue.Location = new System.Drawing.Point(12, 86);
            this.componentValue.Name = "componentValue";
            this.componentValue.Size = new System.Drawing.Size(526, 20);
            this.componentValue.TabIndex = 4;
            // 
            // ComponentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 145);
            this.Controls.Add(this.componentValue);
            this.Controls.Add(this.setComponentValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentComponentValue);
            this.Name = "ComponentInfo";
            this.Text = "Informatie van component: {name}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox currentComponentValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setComponentValue;
        private System.Windows.Forms.TextBox componentValue;
    }
}