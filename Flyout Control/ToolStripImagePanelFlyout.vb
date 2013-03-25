Imports System.ComponentModel
Imports System.Windows.Forms.Design

<ToolStripItemDesignerAvailabilityAttribute(ToolStripItemDesignerAvailability.All)> _
Public Class ToolStripImagePanelFlyout
    Inherits Windows.Forms.ToolStripControlHost

    Public ReadOnly Property ImageControl() As ImagePanelFlyout
        Get
            Return CType(Control, ImagePanelFlyout)
        End Get
    End Property

    Public Sub New()
        MyBase.New(New ImagePanelFlyout)

    End Sub

End Class
