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
            this.Value = new System.Windows.Forms.TextBox();
            this.valueComponent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // componentsView
            // 
            this.componentsView.Location = new System.Drawing.Point(12, 12);
            this.componentsView.Name = "componentsView";
            this.componentsView.Size = new System.Drawing.Size(400, 400);
            this.componentsView.TabIndex = 0;
            this.componentsView.UseCompatibleStateImageBehavior = false;
            this.componentsView.DoubleClick += new System.EventHandler(this.componentsView_DoubleClick);
            // 
            // componentChanges
            // 
            this.componentChanges.Location = new System.Drawing.Point(418, 12);
            this.componentChanges.Name = "componentChanges";
            this.componentChanges.Size = new System.Drawing.Size(400, 400);
            this.componentChanges.TabIndex = 1;
            this.componentChanges.Text = "";
            // 
            // connectArduino
            // 
            this.connectArduino.Location = new System.Drawing.Point(611, 418);
            this.connectArduino.Name = "connectArduino";
            this.connectArduino.Size = new System.Drawing.Size(207, 23);
            this.connectArduino.TabIndex = 2;
            this.connectArduino.Text = "Verbinding maken met Arduino";
            this.connectArduino.UseVisualStyleBackColor = true;
            this.connectArduino.Click += new System.EventHandler(this.connectArduino_Click);
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(418, 419);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(187, 20);
            this.ipAddress.TabIndex = 3;
            // 
            // Value
            // 
            this.Value.Location = new System.Drawing.Point(418, 444);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(187, 20);
            this.Value.TabIndex = 4;
            this.Value.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // valueComponent
            // 
            this.valueComponent.Location = new System.Drawing.Point(611, 442);
            this.valueComponent.Name = "valueComponent";
            this.valueComponent.Size = new System.Drawing.Size(207, 23);
            this.valueComponent.TabIndex = 5;
            this.valueComponent.Text = "Aanpassen Waarde";
            this.valueComponent.UseVisualStyleBackColor = true;
            // 
            // ComponentsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 476);
            this.Controls.Add(this.valueComponent);
            this.Controls.Add(this.Value);
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
        private System.Windows.Forms.Button connectArduino;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.RichTextBox componentChanges;
        private System.Windows.Forms.TextBox Value;
        private System.Windows.Forms.Button valueComponent;
    }
}

