Public Class VisualizerComponent
    Inherits Control

    Public Sub New()
        DoubleBuffered = True
    End Sub

    Private _array As New List(Of Integer)
    Private _prevArray As New List(Of Integer)

    Public Property Array As List(Of Integer)
        Get
            Return _array
        End Get
        Set(value As List(Of Integer))
            _array = value
            Invalidate()
        End Set
    End Property

    Public Property PreviousArray As List(Of Integer)
        Get
            Return _prevArray
        End Get
        Set(value As List(Of Integer))
            _prevArray = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If DesignMode Then Exit Sub

        DrawArray(e.Graphics)
    End Sub

    Private Sub DrawArray(g As Graphics)
        If array Is Nothing Then Exit Sub
        Dim barWidth As Integer = Me.ClientSize.Width / array.Count
        For i As Integer = 0 To array.Count - 1
            Dim bar As New Rectangle(i * barWidth, Me.ClientSize.Height - array(i) * 30, barWidth - 1, array(i) * 30)
            Dim brush As SolidBrush = Brushes.Blue

            If PreviousArray IsNot Nothing Then
                If PreviousArray.Count >= Array.Count Then
                    If PreviousArray(i) <> Array(i) Then
                        brush = Brushes.Red
                    End If
                End If
            End If

            g.FillRectangle(brush, bar)
        Next
    End Sub
End Class
