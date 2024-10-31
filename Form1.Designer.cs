namespace Expanding_Langton_s_And;

partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        stepsList = new ListBox();
        label1 = new Label();
        label2 = new Label();
        colorButton = new Button();
        rotateButton = new Button();
        minusButton = new Button();
        addButton = new Button();
        SuspendLayout();
        // 
        // stepsList
        // 
        stepsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        stepsList.FormattingEnabled = true;
        stepsList.Location = new Point(9, 9);
        stepsList.Margin = new Padding(0);
        stepsList.Name = "stepsList";
        stepsList.Size = new Size(217, 284);
        stepsList.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(9, 342);
        label1.Name = "label1";
        label1.Size = new Size(39, 20);
        label1.TabIndex = 1;
        label1.Text = "转向";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(9, 375);
        label2.Name = "label2";
        label2.Size = new Size(39, 20);
        label2.TabIndex = 2;
        label2.Text = "颜色";
        // 
        // colorButton
        // 
        colorButton.Location = new Point(54, 371);
        colorButton.Name = "colorButton";
        colorButton.Size = new Size(172, 29);
        colorButton.TabIndex = 3;
        colorButton.Text = "button1";
        colorButton.UseVisualStyleBackColor = true;
        // 
        // rotateButton
        // 
        rotateButton.Location = new Point(54, 338);
        rotateButton.Name = "rotateButton";
        rotateButton.Size = new Size(172, 29);
        rotateButton.TabIndex = 4;
        rotateButton.Text = "button1";
        rotateButton.UseVisualStyleBackColor = true;
        // 
        // minusButton
        // 
        minusButton.Location = new Point(191, 303);
        minusButton.Name = "minusButton";
        minusButton.Size = new Size(35, 29);
        minusButton.TabIndex = 5;
        minusButton.Text = "-";
        minusButton.UseVisualStyleBackColor = true;
        // 
        // addButton
        // 
        addButton.Location = new Point(150, 303);
        addButton.Name = "addButton";
        addButton.Size = new Size(35, 29);
        addButton.TabIndex = 6;
        addButton.Text = "+";
        addButton.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(235, 413);
        Controls.Add(addButton);
        Controls.Add(minusButton);
        Controls.Add(rotateButton);
        Controls.Add(colorButton);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(stepsList);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form1";
        Text = "设置";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox stepsList;
    private Label label1;
    private Label label2;
    private Button colorButton;
    private Button rotateButton;
    private Button minusButton;
    private Button addButton;
}