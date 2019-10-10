<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.grpBox1 = New System.Windows.Forms.GroupBox()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.tmrGameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.grpBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBox1
        '
        Me.grpBox1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.grpBox1.Controls.Add(Me.lblScore)
        Me.grpBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBox1.Location = New System.Drawing.Point(0, 0)
        Me.grpBox1.Name = "grpBox1"
        Me.grpBox1.Size = New System.Drawing.Size(584, 30)
        Me.grpBox1.TabIndex = 0
        Me.grpBox1.TabStop = False
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.Location = New System.Drawing.Point(12, 9)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(0, 18)
        Me.lblScore.TabIndex = 1
        '
        'tmrGameTimer
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 661)
        Me.Controls.Add(Me.grpBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Falling Ball Game"
        Me.grpBox1.ResumeLayout(False)
        Me.grpBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpBox1 As GroupBox
    Friend WithEvents lblScore As Label
    Friend WithEvents tmrGameTimer As Timer
End Class
