<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtbalance = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtDucoprice = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtbalance
        '
        Me.txtbalance.Location = New System.Drawing.Point(60, 12)
        Me.txtbalance.Name = "txtbalance"
        Me.txtbalance.ReadOnly = True
        Me.txtbalance.Size = New System.Drawing.Size(133, 20)
        Me.txtbalance.TabIndex = 4
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(10, 15)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(49, 13)
        Me.Label35.TabIndex = 8
        Me.Label35.Text = "Balance:"
        '
        'txtDucoprice
        '
        Me.txtDucoprice.Location = New System.Drawing.Point(95, 38)
        Me.txtDucoprice.Name = "txtDucoprice"
        Me.txtDucoprice.ReadOnly = True
        Me.txtDucoprice.Size = New System.Drawing.Size(78, 20)
        Me.txtDucoprice.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Duco price:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtDucoprice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbalance)
        Me.Controls.Add(Me.Label35)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbalance As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtDucoprice As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
End Class
