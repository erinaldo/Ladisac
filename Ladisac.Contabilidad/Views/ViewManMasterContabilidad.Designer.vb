﻿Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ViewManMasterContabilidad
        Inherits Ladisac.Foundation.Views.ViewManMaster
        'System.Windows.Forms.Form

        'Form reemplaza a Dispose para limpiar la lista de componentes.
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

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(453, 28)
            '
            'ViewManMasterContabilidad
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(453, 254)
            Me.Name = "ViewManMasterContabilidad"
            Me.Text = "ViewManMasterContabilidad"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class
End Namespace
