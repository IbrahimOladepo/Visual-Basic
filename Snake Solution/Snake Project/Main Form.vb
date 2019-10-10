' Name:         Snake Project
' Purpose:      A simple snake game
'               You play it with the arrow keys

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    Dim graphGameSurface As Graphics

    Private rectFood As Rectangle
    Private rectSnake As Rectangle

    Private Const intWidth As Integer = 10

    Private intPoints As Integer = 0

    Private intYlimit As Integer = Me.Height - (5 * intWidth)
    Private intXlimit As Integer = Me.Width - (3 * intWidth) - 200

    ' snake properties/attributes
    Private colSegmentLocations As Collection = New Collection     ' stores location of segments
    Private boolDead As Boolean           ' status of snake
    Private intDirection As Integer         ' direction of snake motion 1:right, 2:left, 3:up, 4:down

    Private Const intStartLen As Integer = 3    ' initial length of snake
    Private intStartX As Integer        ' initial x position of snake
    Private intStartY As Integer         ' initial y position of snake

    ' location of food
    Private pntFoodLoc As Point

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' initialize game environment
        Me.Show()
        Me.Focus()

        graphGameSurface = Me.CreateGraphics
        SpawnFood()
        Restart()
        System.Threading.Thread.Sleep(2000)
        tmrTimer.Enabled = True

        'Debug.Write("Height: " & Me.Height.ToString & " Width: " & Me.Width.ToString & vbNewLine)
    End Sub

    Private Sub Update_Game()
        If boolDead Then
            'Debug.Write("Dead" & vbNewLine)
            Render()
            Exit Sub
        End If
        'Debug.Write("Not Dead" & vbNewLine)

        ' check for wall collision
        Dim pntHead As Point = CType(colSegmentLocations(1), Point)
        'Debug.Write("pntHead.X:" & pntHead.X.ToString & "pntHead.Y:" & pntHead.Y.ToString & vbNewLine)
        If pntHead.X <= 0 Or pntHead.Y <= 0 Or pntHead.X >= intXlimit Or pntHead.Y >= intYlimit Then
            boolDead = True
            'Debug.Write("Wall collision" & vbNewLine)
            Render()
            MessageBox.Show("Game Over",
                            "Game Over", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        End If
        'Debug.Write("No wall collision" & vbNewLine)

        ' check for self collision
        For intNum As Integer = 2 To colSegmentLocations.Count
            Dim pntCurrentSegment As Point = CType(colSegmentLocations(intNum), Point)
            If pntCurrentSegment.X = pntHead.X And pntCurrentSegment.Y = pntHead.Y Then
                'Debug.Write("Self collision" & vbNewLine)
                boolDead = True
                Render()
                MessageBox.Show("Game Over",
                            "Game Over", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                Me.Close()
                Exit Sub
            End If
        Next

        ' check for food collision
        If pntHead.X = pntFoodLoc.X And pntHead.Y = pntFoodLoc.Y Then
            intPoints = intPoints + 1
            SpawnFood()
        Else
            ' remove last segment
            colSegmentLocations.Remove(colSegmentLocations.Count)
        End If

        MoveSnake()
        Render()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' respond to key presses
        ' direction of snake motion 1:right, 2:left, 3:up, 4:down
        Select Case e.KeyCode
            Case Keys.Right
                ' move right if not moving left already
                If intDirection <> 2 Then
                    intDirection = 1
                End If
            Case Keys.Down
                ' move down if not already moving up
                If intDirection <> 3 Then
                    intDirection = 4
                End If
            Case Keys.Left
                ' move left if not already moving right
                If intDirection <> 1 Then
                    intDirection = 2
                End If
            Case Keys.Up
                ' move up if not already moving down
                If intDirection <> 4 Then
                    intDirection = 3
                End If
            Case Keys.Escape
                ' stop the game
                Me.Close()

        End Select
        Call Update_Game()

    End Sub

    Private Sub Main_Form_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        ' adjust game limits when window size changes
        intYlimit = Me.Height - (5 * intWidth)
        intXlimit = Me.Width - (3 * intWidth) - 200

        intStartX = intXlimit \ 2
        intStartX = (intStartX \ intWidth) * intWidth ' make it fit into the grid
        intStartY = intYlimit \ 2
        intStartY = (intStartY \ intWidth) * intWidth ' make it fit into the grid
    End Sub

    Private Sub SpawnFood()
        ' puts food in a random position
        Dim randGen As New Random
        pntFoodLoc.X = randGen.Next(1, (intXlimit - intWidth) \ intWidth) * intWidth
        pntFoodLoc.Y = randGen.Next(1, (intYlimit - intWidth) \ intWidth) * intWidth
    End Sub

    Private Sub Restart()
        ' restart the game
        SpawnFood()
        colSegmentLocations.Clear()
        For intNum As Integer = 0 To intStartLen - 1
            AddSegment(intStartX - (intNum * intWidth), intStartY)
        Next
        intDirection = 1 ' right
        boolDead = False

    End Sub

    Private Sub AddSegment(ByVal intX As Integer, ByVal intY As Integer)
        ' add segment to snake
        Dim pntNewSegment As Point
        pntNewSegment.X = intX
        pntNewSegment.Y = intY
        colSegmentLocations.Add(pntNewSegment)
    End Sub

    Private Sub MoveSnake()
        ' direction of snake motion 1:right, 2:left, 3:up, 4:down
        Dim pntHead As Point = CType(colSegmentLocations(1), Point)
        Dim pntNextSegment As Point

        If intDirection = 3 Then ' moving up
            pntNextSegment.X = pntHead.X
            pntNextSegment.Y = pntHead.Y - intWidth
        End If

        ' moving down
        If intDirection = 4 Then
            pntNextSegment.X = pntHead.X
            pntNextSegment.Y = pntHead.Y + intWidth
        End If

        ' moving left
        If intDirection = 2 Then
            pntNextSegment.X = pntHead.X - intWidth
            pntNextSegment.Y = pntHead.Y
        End If

        ' moving right
        If intDirection = 1 Then
            pntNextSegment.X = pntHead.X + intWidth
            pntNextSegment.Y = pntHead.Y
        End If

        colSegmentLocations.Add(pntNextSegment, Before:=1)
    End Sub

    Private Sub Render()

        If boolDead Then
            Exit Sub
        End If

        lblPoints.Text = "Points: " & intPoints.ToString
        rectFood = New Rectangle(pntFoodLoc.X, pntFoodLoc.Y, intWidth, intWidth)

        Dim penFoodPen As New Pen(Color.MediumVioletRed)
        Dim penSnakePen As New Pen(Color.Green)
        Dim pntSnakeSeg As Point

        graphGameSurface.Clear(Me.BackColor)
        'Me.Refresh()

        graphGameSurface.FillRectangle(Brushes.MediumVioletRed, rectFood)

        rectSnake = New Rectangle(0, 0, intWidth, intWidth)
        For intNum As Integer = 1 To colSegmentLocations.Count
            pntSnakeSeg = CType(colSegmentLocations(intNum), Point)
            rectSnake.X = pntSnakeSeg.X
            rectSnake.Y = pntSnakeSeg.Y
            graphGameSurface.FillRectangle(Brushes.Green, rectSnake)
        Next


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmrTimer.Tick
        Update_Game()
    End Sub
End Class
