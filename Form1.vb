Public Class Form1
    Private steps As List(Of List(Of Integer))
    Private currentStep As Integer
    Private isPlaying As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeVisualization()
    End Sub

    Private Sub InitializeVisualization()
        steps = New List(Of List(Of Integer))()
        currentStep = 0
        isPlaying = False

        Dim array As Integer() = {5, 3, 8, 4, 2, 7, 1, 6}
        BubbleSort(array)

        TrackBar1.Minimum = 0
        TrackBar1.Maximum = steps.Count - 1
        TrackBar1.Value = currentStep
    End Sub

    Private Sub tmrVisualize_Tick(sender As Object, e As EventArgs) Handles tmrVisualize.Tick
        If isPlaying AndAlso currentStep < steps.Count - 1 Then
            currentStep += 1
            TrackBar1.Value = currentStep

            If currentStep >= 1 Then
                VisualizerComponent1.PreviousArray = steps(currentStep - 1)
            End If

            VisualizerComponent1.Array = steps(currentStep)
        Else
            tmrVisualize.Stop()
            isPlaying = False
        End If
    End Sub

    Private Sub BubbleSort(array As Integer())
        Dim n As Integer = array.Length
        Dim tempArray As Integer() = CType(array.Clone(), Integer())

        For i As Integer = 0 To n - 1
            For j As Integer = 0 To n - i - 2
                If tempArray(j) > tempArray(j + 1) Then
                    Dim temp As Integer = tempArray(j)
                    tempArray(j) = tempArray(j + 1)
                    tempArray(j + 1) = temp
                End If
                steps.Add(New List(Of Integer)(tempArray))
            Next
        Next
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        isPlaying = True
        tmrVisualize.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        isPlaying = False
        tmrVisualize.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        isPlaying = False
        tmrVisualize.Stop()
        currentStep = 0
        TrackBar1.Value = currentStep
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        currentStep = TrackBar1.Value
        VisualizerComponent1.Array = steps(currentStep)
        If currentStep > 1 Then
            VisualizerComponent1.PreviousArray = steps(currentStep - 1)
        End If
    End Sub
End Class
