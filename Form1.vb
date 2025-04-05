Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits Form

    'Game elements
    Private WithEvents dino As PictureBox
    Private obstacles As New List(Of PictureBox)
    Private bullets As New List(Of PictureBox)
    Private WithEvents slowTimePowerUp As PictureBox
    Private WithEvents ammoPowerUp As PictureBox
    Private WithEvents scoreLabel As Label
    Private WithEvents ammoLabel As Label

    'Game variables
    Private score As Integer = 0
    Private ammoCount As Integer = 5
    Private isJumping As Boolean = False
    Private jumpHeight As Integer = 0
    Private gravity As Integer = 3
    Private gameSpeed As Integer = 5
    Private isSlowTimeActive As Boolean = False
    Private slowTimeTimer As Integer = 0
    Private gameTimer As Timer
    Private obstacleSpawnTimer As Integer = 0
    Private isOnGround As Boolean = True
    Private jumpForce As Integer = 12
    Private maxJumpHeight As Integer = 150
    Private dinoGroundY As Integer = 300 'Fixed ground position for dino
    Private dinoX As Integer = 100 'Fixed x position for dino
    Private dinoY As Integer = 300 'Fixed y position for dino

    Public Sub New()
        InitializeComponent()
        InitializeGame()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Dino Shooter"
        Me.ClientSize = New Size(800, 400)
        Me.BackColor = Color.White
        Me.DoubleBuffered = True

        'Initialize game elements
        dino = New PictureBox With {
            .Size = New Size(50, 50),
            .Location = New Point(dinoX, dinoY),
            .BackColor = Color.Green,
            .Tag = "dino"
        }

        slowTimePowerUp = New PictureBox With {
            .Size = New Size(20, 20),
            .BackColor = Color.Blue,
            .Visible = False,
            .Tag = "slowTime"
        }

        ammoPowerUp = New PictureBox With {
            .Size = New Size(20, 20),
            .BackColor = Color.Yellow,
            .Visible = False,
            .Tag = "ammo"
        }

        scoreLabel = New Label With {
            .Location = New Point(10, 10),
            .AutoSize = True,
            .Text = "Score: 0"
        }

        ammoLabel = New Label With {
            .Location = New Point(10, 30),
            .AutoSize = True,
            .Text = "Ammo: 5"
        }

        'Add controls to form
        Me.Controls.AddRange({dino, slowTimePowerUp, ammoPowerUp, scoreLabel, ammoLabel})

        'Initialize game timer
        gameTimer = New Timer With {
            .Interval = 20
        }
        AddHandler gameTimer.Tick, AddressOf GameLoop
    End Sub

    Private Sub InitializeGame()
        gameTimer.Start()
    End Sub

    Private Sub GameLoop(sender As Object, e As EventArgs)
        'Spawn new obstacles
        obstacleSpawnTimer += 1
        If obstacleSpawnTimer >= 60 Then 'Spawn every 60 ticks
            SpawnObstacle()
            obstacleSpawnTimer = 0
        End If

        'Move obstacles
        For Each obstacle In obstacles.ToList()
            obstacle.Left -= gameSpeed
            If obstacle.Left < -obstacle.Width Then
                Me.Controls.Remove(obstacle)
                obstacles.Remove(obstacle)
                score += 1
                scoreLabel.Text = "Score: " & score
            End If
        Next

        'Move bullets
        For Each bullet In bullets.ToList()
            bullet.Left += 15
            If bullet.Left > Me.ClientSize.Width Then
                Me.Controls.Remove(bullet)
                bullets.Remove(bullet)
            End If
        Next

        'Handle jumping and gravity
        If isJumping Then
            dinoY -= jumpHeight
            jumpHeight -= 1
            isOnGround = False

            'Limit jump height
            If dinoY <= maxJumpHeight Then
                jumpHeight = 0
            End If
        Else
            'Apply gravity if not on ground
            If Not isOnGround AndAlso dinoY < dinoGroundY Then
                dinoY += gravity
            End If
        End If

        'Check if landed on ground
        If dinoY >= dinoGroundY Then
            dinoY = dinoGroundY
            isJumping = False
            jumpHeight = 0
            isOnGround = True
        End If

        'Update dino position
        dino.Location = New Point(dinoX, dinoY)

        'Handle power-ups
        If Not slowTimePowerUp.Visible AndAlso score Mod 5 = 0 Then
            SpawnPowerUp(slowTimePowerUp)
        End If

        If Not ammoPowerUp.Visible AndAlso score Mod 3 = 0 Then
            SpawnPowerUp(ammoPowerUp)
        End If

        'Check collisions
        CheckCollisions()

        'Handle slow time effect
        If isSlowTimeActive Then
            slowTimeTimer += 1
            If slowTimeTimer >= 150 Then 'Slow time lasts longer
                isSlowTimeActive = False
                gameSpeed = 5
            End If
        End If
    End Sub

    Private Sub SpawnObstacle()
        Dim newObstacle As New PictureBox With {
            .Size = New Size(30, 50),
            .Location = New Point(Me.ClientSize.Width, dinoGroundY + 50 - 30), 'Align with dino's ground level
            .BackColor = Color.Red,
            .Tag = "obstacle"
        }
        obstacles.Add(newObstacle)
        Me.Controls.Add(newObstacle)
    End Sub

    Private Sub SpawnPowerUp(powerUp As PictureBox)
        powerUp.Location = New Point(Me.ClientSize.Width, dinoGroundY - 50) 'Spawn above dino's position
        powerUp.Visible = True
    End Sub

    Private Sub CheckCollisions()
        'Check bullet-obstacle collisions
        For Each bullet In bullets.ToList()
            For Each obstacle In obstacles.ToList()
                If bullet.Bounds.IntersectsWith(obstacle.Bounds) Then
                    Me.Controls.Remove(bullet)
                    bullets.Remove(bullet)
                    Me.Controls.Remove(obstacle)
                    obstacles.Remove(obstacle)
                    score += 2
                    scoreLabel.Text = "Score: " & score
                    Exit For
                End If
            Next
        Next

        'Check dino-obstacle collisions
        For Each obstacle In obstacles
            If dino.Bounds.IntersectsWith(obstacle.Bounds) Then
                GameOver()
            End If
        Next

        'Check power-up collisions
        If dino.Bounds.IntersectsWith(slowTimePowerUp.Bounds) Then
            slowTimePowerUp.Visible = False
            isSlowTimeActive = True
            gameSpeed = 2
            slowTimeTimer = 0
        End If

        If dino.Bounds.IntersectsWith(ammoPowerUp.Bounds) Then
            ammoPowerUp.Visible = False
            ammoCount += 5 'More ammo per pickup
            ammoLabel.Text = "Ammo: " & ammoCount
        End If
    End Sub

    Private Sub GameOver()
        gameTimer.Stop()
        MessageBox.Show("Game Over! Final Score: " & score)
        Application.Restart()
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Space
                If Not isJumping AndAlso isOnGround Then
                    isJumping = True
                    jumpHeight = jumpForce
                End If
            Case Keys.X
                If ammoCount > 0 Then
                    Shoot()
                End If
        End Select
    End Sub

    Private Sub Shoot()
        If ammoCount > 0 Then
            ammoCount -= 1
            ammoLabel.Text = "Ammo: " & ammoCount
            
            Dim newBullet As New PictureBox With {
                .Size = New Size(10, 5),
                .BackColor = Color.Black,
                .Location = New Point(dino.Right, dino.Top + dino.Height \ 2),
                .Tag = "bullet"
            }
            
            bullets.Add(newBullet)
            Me.Controls.Add(newBullet)
        End If
    End Sub
End Class 