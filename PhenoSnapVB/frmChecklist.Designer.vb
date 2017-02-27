<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChecklist
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtChecklist = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtChecklist
        '
        Me.txtChecklist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChecklist.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtChecklist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChecklist.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtChecklist.Location = New System.Drawing.Point(12, 12)
        Me.txtChecklist.Multiline = True
        Me.txtChecklist.Name = "txtChecklist"
        Me.txtChecklist.ReadOnly = True
        Me.txtChecklist.Size = New System.Drawing.Size(382, 189)
        Me.txtChecklist.TabIndex = 3
        Me.txtChecklist.TabStop = False
        Me.txtChecklist.Text = "(1) Checkist"
        '
        'frmChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 213)
        Me.Controls.Add(Me.txtChecklist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmChecklist"
        Me.Text = "Checklist"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChecklist As System.Windows.Forms.TextBox
End Class
