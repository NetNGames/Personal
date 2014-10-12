'Application to calculate simple math functions
'Author: Elbert Dang
Option Strict On
Public Class MainForm
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Close()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub




    '2D Shapes
    Private Sub Calculate2DButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calculate2DButton.Click
        Dim Radius As Decimal
        Dim Length As Decimal
        Dim Width As Decimal
        Dim Base As Decimal
        Dim Height As Decimal
        Dim Area As Decimal
        Dim Circumference As Decimal
        Dim Perimeter As Decimal

        'Circles
        If CircleRadioButton.Checked Then
            If Length2DTextBox.Text <> "" And AreaTextBox.Text = "" And PerimeterTextBox.Text = "" Then
                Try
                    Radius = Decimal.Parse(Length2DTextBox.Text)
                    If Radius > 0 Then
                        Area = CDec(Math.PI * (Radius ^ 2))
                        Circumference = CDec(2 * Math.PI * Radius)
                        AreaTextBox.Text = Area.ToString("N4")
                        PerimeterTextBox.Text = Circumference.ToString("N4")
                    Else
                        MessageBox.Show("Radius cannot be negative")
                        Length2DTextBox.Focus()
                        Length2DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Radius is missing or is not a number")
                    Length2DTextBox.Focus()
                    Length2DTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And AreaTextBox.Text <> "" And PerimeterTextBox.Text = "" Then
                Try
                    Area = Decimal.Parse(AreaTextBox.Text)
                    Try
                        Radius = CDec(Math.Sqrt(Area / Math.PI))
                        Perimeter = CDec(2 * Math.PI * Radius)
                        Length2DTextBox.Text = Radius.ToString("N4")
                        PerimeterTextBox.Text = Perimeter.ToString("N4")
                    Catch ex As Exception
                        MessageBox.Show("Area cannot be negative")
                        AreaTextBox.Focus()
                        AreaTextBox.SelectAll()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Area is not a number")
                    AreaTextBox.Focus()
                    AreaTextBox.SelectAll()
                End Try
            ElseIf AreaTextBox.Text = "" And Length2DTextBox.Text = "" And PerimeterTextBox.Text <> "" Then
                Try
                    Perimeter = Decimal.Parse(PerimeterTextBox.Text)
                    If Perimeter > 0 Then
                        Try
                            Radius = CDec(Perimeter / (2 * Math.PI))
                            Area = CDec(Math.PI * (Radius ^ 2))
                            Length2DTextBox.Text = Radius.ToString("N4")
                            AreaTextBox.Text = Area.ToString("N4")
                        Catch ex As Exception
                            MessageBox.Show("Perimeter cannot be negative")
                            PerimeterTextBox.Focus()
                            PerimeterTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Circumference cannot be negative")
                        PerimeterTextBox.Focus()
                        PerimeterTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Perimeter is not a number")
                    PerimeterTextBox.Focus()
                    PerimeterTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 1 value (only)")
            End If


            'Rectangle
        ElseIf RectangleRadioButton.Checked Then
            If Length2DTextBox.Text <> "" And Width2DTextBox.Text <> "" And AreaTextBox.Text = "" And PerimeterTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Length2DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Width = Decimal.Parse(Width2DTextBox.Text)
                            If Width > 0 Then
                                Area = Length * Width
                                Perimeter = 2 * (Length + Width)
                                AreaTextBox.Text = Area.ToString("N4")
                                PerimeterTextBox.Text = Perimeter.ToString("N4")
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width2DTextBox.Focus()
                                Width2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is missing or is not a number")
                            Width2DTextBox.Focus()
                            Width2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length2DTextBox.Focus()
                        Length2DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length2DTextBox.Focus()
                    Length2DTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text <> "" And Width2DTextBox.Text = "" And AreaTextBox.Text <> "" And PerimeterTextBox.Text = "" Then
                Try
                    Area = Decimal.Parse(AreaTextBox.Text)
                    If Area > 0 Then
                        Try
                            Length = Decimal.Parse(Length2DTextBox.Text)
                            If Length > 0 Then
                                Width = Area / Length
                                Perimeter = 2 * (Length + Width)
                                Width2DTextBox.Text = Width.ToString("N4")
                                PerimeterTextBox.Text = Perimeter.ToString("N4")
                            Else
                                MessageBox.Show("Length cannot be negative")
                                Length2DTextBox.Focus()
                                Length2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Length must be a number")
                            Length2DTextBox.Focus()
                            Length2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Area cannot be negative")
                        AreaTextBox.Focus()
                        AreaTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Area missing or is not a number")
                    AreaTextBox.Focus()
                    AreaTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And Width2DTextBox.Text <> "" And AreaTextBox.Text <> "" And PerimeterTextBox.Text = "" Then
                Try
                    Area = Decimal.Parse(AreaTextBox.Text)
                    If Area > 0 Then
                        Try
                            Width = Decimal.Parse(Width2DTextBox.Text)
                            If Width > 0 Then
                                Length = Area / Width
                                Perimeter = 2 * (Length + Width)
                                Length2DTextBox.Text = Length.ToString("N4")
                                PerimeterTextBox.Text = Perimeter.ToString("N4")
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width2DTextBox.Focus()
                                Width2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width must be a number")
                            Width2DTextBox.Focus()
                            Width2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Area cannot be negative")
                        AreaTextBox.Focus()
                        AreaTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Area missing or is not a number")
                    AreaTextBox.Focus()
                    AreaTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And Width2DTextBox.Text <> "" And AreaTextBox.Text = "" And PerimeterTextBox.Text <> "" Then
                Try
                    Perimeter = Decimal.Parse(PerimeterTextBox.Text)
                    If Perimeter > 0 Then
                        Try
                            Width = Decimal.Parse(Width2DTextBox.Text)
                            If Width > 0 Then
                                Length = (Perimeter / 2) - Width
                                Area = Width * Length
                                If Length > 0 And Area > 0 Then
                                    Length2DTextBox.Text = Length.ToString("N4")
                                    AreaTextBox.Text = Area.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                    Length2DTextBox.Focus()
                                    Length2DTextBox.SelectAll()
                                End If
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width2DTextBox.Focus()
                                Width2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width must be a number")
                            Width2DTextBox.Focus()
                            Width2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Perimeter cannot be negative")
                        PerimeterTextBox.Focus()
                        PerimeterTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Perimeter missing or is not a number")
                    PerimeterTextBox.Focus()
                    PerimeterTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text <> "" And Width2DTextBox.Text = "" And AreaTextBox.Text = "" And PerimeterTextBox.Text <> "" Then
                Try
                    Perimeter = Decimal.Parse(PerimeterTextBox.Text)
                    If Perimeter > 0 Then
                        Try
                            Length = Decimal.Parse(Length2DTextBox.Text)
                            If Length > 0 Then
                                Width = (Perimeter / 2) - Length
                                Area = Width * Length
                                If Width > 0 And Area > 0 Then
                                    Width2DTextBox.Text = Width.ToString("N4")
                                    AreaTextBox.Text = Area.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                    Length2DTextBox.Focus()
                                    Length2DTextBox.SelectAll()
                                End If
                            Else
                                MessageBox.Show("Length cannot be negative")
                                Length2DTextBox.Focus()
                                Length2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width must be a number")
                            Length2DTextBox.Focus()
                            Length2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Perimeter cannot be negative")
                        PerimeterTextBox.Focus()
                        PerimeterTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Perimeter is missing or is not a number")
                    PerimeterTextBox.Focus()
                    PerimeterTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And Width2DTextBox.Text = "" And AreaTextBox.Text <> "" And PerimeterTextBox.Text <> "" Then
                MessageBox.Show("Unable to calculate length or width with these values" & Environment.NewLine &
                                "Please try a different combination")
            Else
                MessageBox.Show("Please enter 2 values")
            End If


            'Square
        ElseIf SquareRadioButton.Checked Then
            If Length2DTextBox.Text <> "" And AreaTextBox.Text = "" And PerimeterTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Length2DTextBox.Text)
                    If Length > 0 Then
                        Area = CDec(Length ^ 2)
                        Perimeter = 4 * Length
                        AreaTextBox.Text = Area.ToString("N4")
                        PerimeterTextBox.Text = Perimeter.ToString("N4")
                    Else
                        MessageBox.Show("Side Length cannot be negative")
                        Length2DTextBox.Focus()
                        Length2DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Side Length is missing or is not a number")
                    Length2DTextBox.Focus()
                    Length2DTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And AreaTextBox.Text <> "" And PerimeterTextBox.Text = "" Then
                Try
                    Area = Decimal.Parse(AreaTextBox.Text)
                    If Area > 0 Then
                        Try
                            Length = CDec(Math.Sqrt(Area))
                            Perimeter = 4 * Length
                            Length2DTextBox.Text = Length.ToString("N4")
                            PerimeterTextBox.Text = Perimeter.ToString("N4")
                        Catch ex As Exception
                            MessageBox.Show("Area cannot be negative")
                            AreaTextBox.Focus()
                            AreaTextBox.SelectAll()
                        End Try
                    End If
                Catch ex As Exception
                    MessageBox.Show("Area is not a number")
                    AreaTextBox.Focus()
                    AreaTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And AreaTextBox.Text = "" And PerimeterTextBox.Text <> "" Then
                Try
                    Perimeter = Decimal.Parse(PerimeterTextBox.Text)
                    If Perimeter > 0 Then
                        Try
                            Length = Perimeter / 4
                            Area = CDec(Length ^ 2)
                            Length2DTextBox.Text = Length.ToString("N4")
                            AreaTextBox.Text = Area.ToString("N4")
                        Catch ex As Exception
                            MessageBox.Show("Perimeter cannot be negative")
                            PerimeterTextBox.Focus()
                            PerimeterTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Perimeter cannot be negative")
                        PerimeterTextBox.Focus()
                        PerimeterTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Perimeter is not a number")
                    PerimeterTextBox.Focus()
                    PerimeterTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 1 value (only)")
            End If


            'Triangle
        ElseIf TriangleRadioButton.Checked Then
            If Length2DTextBox.Text <> "" And Width2DTextBox.Text <> "" And AreaTextBox.Text = "" Then
                Try
                    Base = Decimal.Parse(Length2DTextBox.Text)
                    If Base > 0 Then
                        Try
                            Height = Decimal.Parse(Width2DTextBox.Text)
                            If Height > 0 Then
                                Area = 0.5D * Base * Height
                                AreaTextBox.Text = Area.ToString("N4")
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Width2DTextBox.Focus()
                                Width2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is missing or is not a number")
                            Width2DTextBox.Focus()
                            Width2DTextBox.SelectAll()
                        End Try

                    Else
                        MessageBox.Show("Length of Base cannot be negative")
                        Length2DTextBox.Focus()
                        Length2DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Base is missing or is not a number")
                    Length2DTextBox.Focus()
                    Length2DTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text = "" And Width2DTextBox.Text <> "" And AreaTextBox.Text <> "" Then
                Try
                    Area = Decimal.Parse(AreaTextBox.Text)
                    If Area > 0 Then
                        Try
                            Height = Decimal.Parse(Width2DTextBox.Text)
                            If Height > 0 Then
                                Base = (2 * Area) / Height
                                Length2DTextBox.Text = Base.ToString
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Width2DTextBox.Focus()
                                Width2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Please enter another value")
                            Width2DTextBox.Focus()
                            Width2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Area cannot be negative")
                        Length2DTextBox.Focus()
                        Length2DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Area is missing or is not a number")
                    AreaTextBox.Focus()
                    AreaTextBox.SelectAll()
                End Try
            ElseIf Length2DTextBox.Text <> "" And Width2DTextBox.Text = "" And AreaTextBox.Text <> "" Then
                Try
                    Area = Decimal.Parse(AreaTextBox.Text)
                    If Area > 0 Then
                        Try
                            Base = Decimal.Parse(Length2DTextBox.Text)
                            If Base > 0 Then
                                Height = (2 * Area) / Base
                                Width2DTextBox.Text = Height.ToString
                            Else
                                MessageBox.Show("Base cannot be negative")
                                Length2DTextBox.Focus()
                                Length2DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Base must be a number")
                            Length2DTextBox.Focus()
                            Length2DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Area cannot be negative")
                        Length2DTextBox.Focus()
                        Length2DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Area is not a number")
                    AreaTextBox.Focus()
                    AreaTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 2 values")
            End If
        End If
    End Sub
    Private Sub CircleRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CircleRadioButton.CheckedChanged
        PerimeterLabel.Text = "Circumference"
        Length2DLabel.Text = "r = Radius"
        Length2DTextBox.Clear()
        Width2DTextBox.Clear()
        AreaTextBox.Clear()
        PerimeterTextBox.Clear()
        PerimeterLabel.Visible = True
        PerimeterTextBox.Visible = True
        Width2DLabel.Visible = False
        Width2DTextBox.Visible = False
        PictureBox2D.Image = My.Resources.Circle
    End Sub
    Private Sub RectangleRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleRadioButton.CheckedChanged
        PerimeterLabel.Text = "Perimeter"
        Length2DLabel.Text = "Length"
        Width2DLabel.Text = "Width"
        Length2DTextBox.Clear()
        Width2DTextBox.Clear()
        AreaTextBox.Clear()
        PerimeterTextBox.Clear()
        PerimeterLabel.Visible = True
        PerimeterTextBox.Visible = True
        Width2DLabel.Visible = True
        Width2DTextBox.Visible = True
        PictureBox2D.Image = My.Resources.Rectangle
    End Sub
    Private Sub SquareRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SquareRadioButton.CheckedChanged
        PerimeterLabel.Text = "Perimeter"
        Length2DLabel.Text = "Side Length"
        Length2DTextBox.Clear()
        Width2DTextBox.Clear()
        AreaTextBox.Clear()
        PerimeterTextBox.Clear()
        PerimeterLabel.Visible = True
        PerimeterTextBox.Visible = True
        Width2DLabel.Visible = False
        Width2DTextBox.Visible = False
        PictureBox2D.Image = My.Resources.Square
    End Sub
    Private Sub TriangleRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriangleRadioButton.CheckedChanged
        Length2DLabel.Text = "Base"
        Width2DLabel.Text = "Height"
        Length2DTextBox.Clear()
        Width2DTextBox.Clear()
        AreaTextBox.Clear()
        PerimeterTextBox.Clear()
        PerimeterLabel.Visible = False
        PerimeterTextBox.Visible = False
        Width2DLabel.Visible = True
        Width2DTextBox.Visible = True
        PictureBox2D.Image = My.Resources.Triangle
    End Sub
    Private Sub Clear2DButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear2DButton.Click
        AreaTextBox.Clear()
        Length2DTextBox.Clear()
        PerimeterTextBox.Clear()
        Width2DTextBox.Clear()
        Length2DTextBox.Focus()
    End Sub




    '3D Shapes
    Private Sub Calculate3DButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calculate3DButton.Click
        Dim Radius As Double
        Dim Length As Double
        Dim Width As Double
        Dim Height As Double
        Dim Volume As Double
        Dim SurfaceArea As Double


        'Cone
        If ConeRadioButton.Checked Then
            If Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" Then
                Try
                    Radius = Decimal.Parse(Width3DTextBox.Text)
                    If Radius > 0 Then
                        Try
                            Height = Decimal.Parse(Height3DTextBox.Text)
                            If Height > 0 Then
                                Volume = (1 / 3) * Math.PI * (Radius ^ 2) * Height
                                If Volume > 0 Then
                                    VolumeTextBox.Text = Volume.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Height3DTextBox.Focus()
                                Height3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is missing or is not a number")
                            Height3DTextBox.Focus()
                            Height3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Radius cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Radius is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" Then
                Try
                    Radius = Decimal.Parse(Width3DTextBox.Text)
                    If Radius > 0 Then
                        Try
                            Volume = Decimal.Parse(VolumeTextBox.Text)
                            If Volume > 0 Then
                                Height = CDec((3 * Volume) / (Math.PI * (Radius ^ 2)))
                                If Height > 0 Then
                                    Height3DTextBox.Text = Height.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Volume cannot be negative")
                                VolumeTextBox.Focus()
                                VolumeTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Volume is missing or is not a number")
                            VolumeTextBox.Focus()
                            VolumeTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Radius cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Radius is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" Then
                Try
                    Height = Decimal.Parse(Height3DTextBox.Text)
                    If Height > 0 Then
                        Try
                            Volume = Decimal.Parse(VolumeTextBox.Text)
                            If Volume > 0 Then
                                Radius = CDec(Math.Sqrt((3 * Volume) / (Math.PI * Height)))
                                If Radius > 0 Then
                                    Width3DTextBox.Text = Radius.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Volume cannot be negative")
                                VolumeTextBox.Focus()
                                VolumeTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Volume is missing or is not a number")
                            VolumeTextBox.Focus()
                            VolumeTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Height cannot be negative")
                        Height3DTextBox.Focus()
                        Height3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Height is missing or is not a number")
                    Height3DTextBox.Focus()
                    Height3DTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 2 values")
            End If


            'Cube
        ElseIf CubeRadioButton.Checked Then
            If Width3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Width3DTextBox.Text)
                    If Length > 0 Then
                        Volume = Length ^ 3
                        SurfaceArea = 6 * (Length ^ 2)
                        If Volume > 0 And SurfaceArea > 0 Then
                            VolumeTextBox.Text = Volume.ToString("N4")
                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                        Else
                            MessageBox.Show("Impossibly sized shape")
                        End If
                    Else
                        MessageBox.Show("Height cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Height is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Volume = Decimal.Parse(VolumeTextBox.Text)
                    If Volume > 0 Then
                        Length = CDec(Volume ^ (1 / 3))
                        SurfaceArea = 6 * (Length ^ 2)
                        If Length > 0 And SurfaceArea > 0 Then
                            Width3DTextBox.Text = Length.ToString("N4")
                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                        Else
                            MessageBox.Show("Impossibly sized shape")
                        End If
                    Else
                        MessageBox.Show("Volume cannot be negative")
                        VolumeTextBox.Focus()
                        VolumeTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Volume is not a number")
                    VolumeTextBox.Focus()
                    VolumeTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                Try
                    SurfaceArea = Decimal.Parse(SurfaceAreaTextBox.Text)
                    If SurfaceArea > 0 Then
                        Length = CDec(Math.Sqrt(SurfaceArea / 6))
                        Volume = 6 * (Length ^ 2)
                        If Volume > 0 And Length > 0 Then
                            Width3DTextBox.Text = Length.ToString("N4")
                            VolumeTextBox.Text = Volume.ToString("N4")
                        Else
                            MessageBox.Show("Impossibly sized shape")
                        End If
                    Else
                        MessageBox.Show("Surface Area cannot be negative")
                        VolumeTextBox.Focus()
                        VolumeTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Surface Area is not a number")
                    SurfaceAreaTextBox.Focus()
                    SurfaceAreaTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 1 value")
            End If


            'Cylinder
        ElseIf CylinderRadioButton.Checked Then
            If Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Radius = Decimal.Parse(Width3DTextBox.Text)
                    If Radius > 0 Then
                        Try
                            Height = Decimal.Parse(Height3DTextBox.Text)
                            If Height > 0 Then
                                Volume = Math.PI * (Radius ^ 2) * Height
                                SurfaceArea = 2 * Math.PI * Radius * (Radius + Height)
                                If Volume > 0 And SurfaceArea > 0 Then
                                    VolumeTextBox.Text = Volume.ToString("N4")
                                    SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Height3DTextBox.Focus()
                                Height3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is not a number")
                            Height3DTextBox.Focus()
                            Height3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Radius cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Radius is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Radius = Decimal.Parse(Width3DTextBox.Text)
                    If Radius > 0 Then
                        Try
                            Volume = Decimal.Parse(VolumeTextBox.Text)
                            If Volume > 0 Then
                                Height = Volume / (Math.PI * (Radius ^ 2))
                                SurfaceArea = 2 * Math.PI * Radius * (Radius + Height)
                                If Height > 0 And SurfaceArea > 0 Then
                                    Height3DTextBox.Text = Height.ToString("N4")
                                    SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Volume cannot be negative")
                                VolumeTextBox.Focus()
                                VolumeTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Volume is not a number")
                            VolumeTextBox.Focus()
                            VolumeTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Radius cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Radius is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                Try
                    Radius = Decimal.Parse(Width3DTextBox.Text)
                    If Radius > 0 Then
                        Try
                            SurfaceArea = Decimal.Parse(SurfaceAreaTextBox.Text)
                            If SurfaceArea > 0 Then
                                Height = (SurfaceArea / (2 * Math.PI * Radius)) - Radius
                                Volume = Math.PI * (Radius ^ 2) * Height
                                If Volume > 0 And Height > 0 Then
                                    Height3DTextBox.Text = Height.ToString("N4")
                                    VolumeTextBox.Text = Volume.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Surface Area cannot be negative")
                                SurfaceAreaTextBox.Focus()
                                SurfaceAreaTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Surface Area is not a number")
                            SurfaceAreaTextBox.Focus()
                            SurfaceAreaTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Radius cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Radius is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Height = Decimal.Parse(Height3DTextBox.Text)
                    If Height > 0 Then
                        Try
                            Volume = Decimal.Parse(VolumeTextBox.Text)
                            If Volume > 0 Then
                                Radius = Math.Sqrt(Volume / (Math.PI * Height))
                                SurfaceArea = Math.PI * (Radius ^ 2) * Height
                                If Radius > 0 And SurfaceArea > 0 Then
                                    Width3DTextBox.Text = Radius.ToString("N4")
                                    SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                Else
                                    MessageBox.Show("Impossibly sized shape")
                                End If
                            Else
                                MessageBox.Show("Volume cannot be negative")
                                VolumeTextBox.Focus()
                                VolumeTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Volume is not a number")
                            VolumeTextBox.Focus()
                            VolumeTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Height cannot be negative")
                        Height3DTextBox.Focus()
                        Height3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Height is missing or is not a number")
                    Height3DTextBox.Focus()
                    Height3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                MessageBox.Show("Cannot calculate Radius or Volume from these values" & Environment.NewLine &
                                "Please try a different combination")
            ElseIf Width3DTextBox.Text = "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text <> "" Then
                MessageBox.Show("Cannot calculate Radius or Height from these values" & Environment.NewLine &
                                "Please try a different combination")
            Else
                MessageBox.Show("Please enter 2 values")
            End If


            'Pyramid
        ElseIf PyramidRadioButton.Checked Then
            If Length3DTextBox.Text <> "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    Height = Decimal.Parse(Height3DTextBox.Text)
                                    If Height > 0 Then
                                        Volume = (1 / 3) * Length * Width * Height
                                        If Volume > 0 Then
                                            VolumeTextBox.Text = Volume.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Height cannot be negative")
                                        Height3DTextBox.Focus()
                                        Height3DTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Height is not a number")
                                    Height3DTextBox.Focus()
                                    Height3DTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    Volume = Decimal.Parse(VolumeTextBox.Text)
                                    If Volume > 0 Then
                                        Height = (3 * Volume) / (Length * Width)
                                        If Height > 0 Then
                                            Height3DTextBox.Text = Height.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Volume cannot be negative")
                                        VolumeTextBox.Focus()
                                        VolumeTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Volume is not a number")
                                    VolumeTextBox.Focus()
                                    VolumeTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Height = Decimal.Parse(Height3DTextBox.Text)
                            If Height > 0 Then
                                Try
                                    Volume = Decimal.Parse(VolumeTextBox.Text)
                                    If Volume > 0 Then
                                        Width = (3 * Volume) / (Length * Height)
                                        If Width > 0 Then
                                            Width3DTextBox.Text = Width.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Volume cannot be negative")
                                        VolumeTextBox.Focus()
                                        VolumeTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Volume is not a number")
                                    VolumeTextBox.Focus()
                                    VolumeTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Height3DTextBox.Focus()
                                Height3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is not a number")
                            Height3DTextBox.Focus()
                            Height3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
            ElseIf Length3DTextBox.Text = "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" Then
                Try
                    Width = Decimal.Parse(Width3DTextBox.Text)
                    If Width > 0 Then
                        Try
                            Height = Decimal.Parse(Height3DTextBox.Text)
                            If Height > 0 Then
                                Try
                                    Volume = Decimal.Parse(VolumeTextBox.Text)
                                    If Volume > 0 Then
                                        Length = (3 * Volume) / (Width * Height)
                                        If Length > 0 Then
                                            Length3DTextBox.Text = Length.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Volume cannot be negative")
                                        VolumeTextBox.Focus()
                                        VolumeTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Volume is not a number")
                                    VolumeTextBox.Focus()
                                    VolumeTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Height3DTextBox.Focus()
                                Height3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is not a number")
                            Height3DTextBox.Focus()
                            Height3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Width cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Width is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 3 values")
            End If


            'Rectangular Prism
        ElseIf RectangularPrismRadioButton.Checked Then
            'Standard
            If Length3DTextBox.Text <> "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    Height = Decimal.Parse(Height3DTextBox.Text)
                                    If Height > 0 Then
                                        Volume = Length * Width * Height
                                        SurfaceArea = 2 * (Length * Width + Length * Height + Width * Height)
                                        If Volume > 0 And SurfaceArea > 0 Then
                                            VolumeTextBox.Text = Volume.ToString("N4")
                                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Height cannot be negative")
                                        Height3DTextBox.Focus()
                                        Height3DTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Height is not a number")
                                    Height3DTextBox.Focus()
                                    Height3DTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
                'Missing Height and SA
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    Volume = Decimal.Parse(VolumeTextBox.Text)
                                    If Volume > 0 Then
                                        Height = Volume / (Length * Width)
                                        SurfaceArea = 2 * (Length * Width + Length * Height + Width * Height)
                                        If Height > 0 And SurfaceArea > 0 Then
                                            Height3DTextBox.Text = Height.ToString("N4")
                                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Volume cannot be negative")
                                        VolumeTextBox.Focus()
                                        VolumeTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Volume is not a number")
                                    VolumeTextBox.Focus()
                                    VolumeTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
                'Missing Height and Vol
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    SurfaceArea = Decimal.Parse(SurfaceAreaTextBox.Text)
                                    If SurfaceArea > 0 Then
                                        Height = ((0.5 * SurfaceArea) - (Length * Width)) / (Length + Width)
                                        Volume = Length * Width * Height
                                        If Height > 0 And Volume > 0 Then
                                            Height3DTextBox.Text = Height.ToString("N4")
                                            VolumeTextBox.Text = Volume.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Surface Area cannot be negative")
                                        SurfaceAreaTextBox.Focus()
                                        SurfaceAreaTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Surface Area is not a number")
                                    SurfaceAreaTextBox.Focus()
                                    SurfaceAreaTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
                'Missing Width and SA
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Height = Decimal.Parse(Height3DTextBox.Text)
                            If Height > 0 Then
                                Try
                                    Volume = Decimal.Parse(VolumeTextBox.Text)
                                    If Volume > 0 Then
                                        Width = Volume / (Length * Height)
                                        SurfaceArea = 2 * (Length * Width + Length * Height + Width * Height)
                                        If Width > 0 And SurfaceArea > 0 Then
                                            Width3DTextBox.Text = Width.ToString("N4")
                                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Volume cannot be negative")
                                        VolumeTextBox.Focus()
                                        VolumeTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Volume is not a number")
                                    VolumeTextBox.Focus()
                                    VolumeTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Height3DTextBox.Focus()
                                Height3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is not a number")
                            Height3DTextBox.Focus()
                            Height3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
                'Missing width and vol
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                Try
                    Length = Decimal.Parse(Length3DTextBox.Text)
                    If Length > 0 Then
                        Try
                            Height = Decimal.Parse(Height3DTextBox.Text)
                            If Height > 0 Then
                                Try
                                    SurfaceArea = Decimal.Parse(SurfaceAreaTextBox.Text)
                                    If SurfaceArea > 0 Then
                                        Width = ((0.5 * SurfaceArea) - (Length * Height)) / (Length + Height)
                                        Volume = Length * Width * Height
                                        If Width > 0 And Volume > 0 Then
                                            Width3DTextBox.Text = Width.ToString("N4")
                                            VolumeTextBox.Text = Volume.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Surface Area cannot be negative")
                                        SurfaceAreaTextBox.Focus()
                                        SurfaceAreaTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Surface Area is not a number")
                                    SurfaceAreaTextBox.Focus()
                                    SurfaceAreaTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Height cannot be negative")
                                Height3DTextBox.Focus()
                                Height3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Height is not a number")
                            Height3DTextBox.Focus()
                            Height3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Length cannot be negative")
                        Length3DTextBox.Focus()
                        Length3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Length is missing or is not a number")
                    Length3DTextBox.Focus()
                    Length3DTextBox.SelectAll()
                End Try
                'Missing Length and sa
            ElseIf Length3DTextBox.Text = "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Height = Decimal.Parse(Height3DTextBox.Text)
                    If Height > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    Volume = Decimal.Parse(VolumeTextBox.Text)
                                    If Volume > 0 Then
                                        Length = Volume / (Height * Width)
                                        SurfaceArea = 2 * (Length * Width + Length * Height + Width * Height)
                                        If Length > 0 And SurfaceArea > 0 Then
                                            Length3DTextBox.Text = Length.ToString("N4")
                                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Volume cannot be negative")
                                        VolumeTextBox.Focus()
                                        VolumeTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Volume is not a number")
                                    VolumeTextBox.Focus()
                                    VolumeTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Height cannot be negative")
                        Height3DTextBox.Focus()
                        Height3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Height is not a number")
                    Height3DTextBox.Focus()
                    Height3DTextBox.SelectAll()
                End Try
                'missing length and vol
            ElseIf Length3DTextBox.Text = "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                Try
                    Height = Decimal.Parse(Height3DTextBox.Text)
                    If Height > 0 Then
                        Try
                            Width = Decimal.Parse(Width3DTextBox.Text)
                            If Width > 0 Then
                                Try
                                    SurfaceArea = Decimal.Parse(SurfaceAreaTextBox.Text)
                                    If SurfaceArea > 0 Then
                                        Length = ((0.5 * SurfaceArea) - (Height * Width)) / (Height + Width)
                                        Volume = Length * Width * Height
                                        If Length > 0 And Volume > 0 Then
                                            Length3DTextBox.Text = Length.ToString("N4")
                                            VolumeTextBox.Text = Volume.ToString("N4")
                                        Else
                                            MessageBox.Show("Impossibly sized shape")
                                        End If
                                    Else
                                        MessageBox.Show("Surface Area cannot be negative")
                                        SurfaceAreaTextBox.Focus()
                                        SurfaceAreaTextBox.SelectAll()
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Surface Area is not a number")
                                    SurfaceAreaTextBox.Focus()
                                    SurfaceAreaTextBox.SelectAll()
                                End Try
                            Else
                                MessageBox.Show("Width cannot be negative")
                                Width3DTextBox.Focus()
                                Width3DTextBox.SelectAll()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Width is not a number")
                            Width3DTextBox.Focus()
                            Width3DTextBox.SelectAll()
                        End Try
                    Else
                        MessageBox.Show("Height cannot be negative")
                        Height3DTextBox.Focus()
                        Height3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Height is not a number")
                    Height3DTextBox.Focus()
                    Height3DTextBox.SelectAll()
                End Try
            ElseIf Length3DTextBox.Text = "" And Width3DTextBox.Text = "" And Height3DTextBox.Text <> "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text <> "" Then
                MessageBox.Show("Cannot calculate Length or Width from these values" & Environment.NewLine &
                               "Please try a different combination")
            ElseIf Length3DTextBox.Text = "" And Width3DTextBox.Text <> "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text <> "" Then
                MessageBox.Show("Cannot calculate Length or Height from these values" & Environment.NewLine &
                                   "Please try a different combination")
            ElseIf Length3DTextBox.Text <> "" And Width3DTextBox.Text = "" And Height3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text <> "" Then
                MessageBox.Show("Cannot calculate Width or Height from these values" & Environment.NewLine &
                                   "Please try a different combination")
            Else
                MessageBox.Show("Please enter 3 values")
            End If


            'Sphere
        ElseIf SphereRadioButton.Checked Then
            If Width3DTextBox.Text <> "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Radius = Decimal.Parse(Width3DTextBox.Text)
                    If Radius > 0 Then
                        Volume = (4 / 3) * Math.PI * (Radius ^ 3)
                        SurfaceArea = 4 * Math.PI * (Radius ^ 2)
                        If Volume > 0 And SurfaceArea > 0 Then
                            VolumeTextBox.Text = Volume.ToString("N4")
                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                        Else
                            MessageBox.Show("Impossibly sized shape")
                        End If
                    Else
                        MessageBox.Show("Width cannot be negative")
                        Width3DTextBox.Focus()
                        Width3DTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Width is missing or is not a number")
                    Width3DTextBox.Focus()
                    Width3DTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And VolumeTextBox.Text <> "" And SurfaceAreaTextBox.Text = "" Then
                Try
                    Volume = Decimal.Parse(VolumeTextBox.Text)
                    If Volume > 0 Then
                        Radius = ((3 * Volume) / (4 * Math.PI)) ^ (1 / 3)
                        SurfaceArea = 4 * Math.PI * (Radius ^ 2)
                        If Radius > 0 And SurfaceArea > 0 Then
                            Width3DTextBox.Text = Radius.ToString("N4")
                            SurfaceAreaTextBox.Text = SurfaceArea.ToString("N4")
                        Else
                            MessageBox.Show("Impossibly sized shape")
                        End If
                    Else
                        MessageBox.Show("Volume cannot be negative")
                        VolumeTextBox.Focus()
                        VolumeTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Volume is missing or is not a number")
                    VolumeTextBox.Focus()
                    VolumeTextBox.SelectAll()
                End Try
            ElseIf Width3DTextBox.Text = "" And VolumeTextBox.Text = "" And SurfaceAreaTextBox.Text <> "" Then
                Try
                    SurfaceArea = Decimal.Parse(SurfaceAreaTextBox.Text)
                    If SurfaceArea > 0 Then
                        Radius = Math.Sqrt(SurfaceArea / (4 * Math.PI))
                        Volume = 4 * Math.PI * (Radius ^ 2)
                        If Radius > 0 And SurfaceArea > 0 Then
                            Width3DTextBox.Text = Radius.ToString("N4")
                            VolumeTextBox.Text = Volume.ToString("N4")
                        Else
                            MessageBox.Show("Impossibly sized shape")
                        End If
                    Else
                        MessageBox.Show("Surface Area cannot be negative")
                        SurfaceAreaTextBox.Focus()
                        SurfaceAreaTextBox.SelectAll()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Surface Area is missing or is not a number")
                    SurfaceAreaTextBox.Focus()
                    SurfaceAreaTextBox.SelectAll()
                End Try
            Else
                MessageBox.Show("Please enter 1 value")
            End If
        End If

    End Sub
    Private Sub ConeRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConeRadioButton.CheckedChanged
        Width3DLabel.Text = "Radius"
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        SurfaceAreaLabel.Visible = False
        SurfaceAreaTextBox.Visible = False
        Length3DLabel.Visible = False
        Length3DTextBox.Visible = False
        Height3DLabel.Visible = True
        Height3DTextBox.Visible = True
        PictureBox3D.Image = My.Resources.Cone
    End Sub
    Private Sub CubeRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CubeRadioButton.CheckedChanged
        Width3DLabel.Text = "Length"
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        SurfaceAreaLabel.Visible = True
        SurfaceAreaTextBox.Visible = True
        Length3DLabel.Visible = False
        Length3DTextBox.Visible = False
        Height3DLabel.Visible = False
        Height3DTextBox.Visible = False
        PictureBox3D.Image = My.Resources.Cube
    End Sub
    Private Sub CylinderRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CylinderRadioButton.CheckedChanged
        Width3DLabel.Text = "Radius"
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        SurfaceAreaLabel.Visible = True
        SurfaceAreaTextBox.Visible = True
        Length3DLabel.Visible = False
        Length3DTextBox.Visible = False
        Height3DLabel.Visible = True
        Height3DTextBox.Visible = True
        PictureBox3D.Image = My.Resources.Cylinder
    End Sub
    Private Sub PyramidRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PyramidRadioButton.CheckedChanged
        Width3DLabel.Text = "Width"
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        SurfaceAreaLabel.Visible = False
        SurfaceAreaTextBox.Visible = False
        Length3DLabel.Visible = True
        Length3DTextBox.Visible = True
        Height3DLabel.Visible = True
        Height3DTextBox.Visible = True
        PictureBox3D.Image = My.Resources.Pyramid
    End Sub
    Private Sub RectangularPrismRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RectangularPrismRadioButton.CheckedChanged
        Width3DLabel.Text = "Width"
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        SurfaceAreaLabel.Visible = True
        SurfaceAreaTextBox.Visible = True
        Length3DLabel.Visible = True
        Length3DTextBox.Visible = True
        Height3DLabel.Visible = True
        Height3DTextBox.Visible = True
        PictureBox3D.Image = My.Resources.RectangularPrism
    End Sub
    Private Sub SphereRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SphereRadioButton.CheckedChanged
        Width3DLabel.Text = "Radius"
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        SurfaceAreaLabel.Visible = True
        SurfaceAreaTextBox.Visible = True
        Length3DLabel.Visible = False
        Length3DTextBox.Visible = False
        Height3DLabel.Visible = False
        Height3DTextBox.Visible = False
        PictureBox3D.Image = My.Resources.Sphere
    End Sub
    Private Sub Clear3DButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clear3DButton.Click
        VolumeTextBox.Clear()
        SurfaceAreaTextBox.Clear()
        Length3DTextBox.Clear()
        Width3DTextBox.Clear()
        Height3DTextBox.Clear()
        Length3DTextBox.Focus()
    End Sub




    'Interest and Half-Life
    Private Sub CalculateRateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateRateButton.Click
        Dim Amount As Decimal
        Dim Rate As Decimal
        Dim Years As Decimal
        Dim Compounded As Decimal
        Dim FutureValue As Double

        Try
            Amount = Decimal.Parse(InitialAmountTextBox.Text)
            Try
                Rate = Decimal.Parse(RateTextBox.Text)
                Try
                    Years = Decimal.Parse(YearsTextBox.Text)
                    Try
                        Compounded = Decimal.Parse(CompoundedTextBox.Text)
                        If AnnualRadioButton.Checked Then
                            FutureValue = Amount * (1 + Rate) ^ Years
                        ElseIf ContinousRadioButton.Checked Then
                            FutureValue = Amount * (1 + (Rate / Compounded)) ^ (Years * Compounded)
                        End If

                        'Display
                        AmountTextBox.Text = FutureValue.ToString("N4")
                    Catch ex As Exception
                        MessageBox.Show("Times compounded is missing or is not a number",
                          "Data entry error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation)
                        CompoundedTextBox.Focus()
                        CompoundedTextBox.SelectAll()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Years is missing or is not a number",
                          "Data entry error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation)
                    YearsTextBox.Focus()
                    YearsTextBox.SelectAll()
                End Try
            Catch ex As Exception
                MessageBox.Show("Interest Rate is missing or is not a number",
                           "Data entry error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation)
                RateTextBox.Focus()
                RateTextBox.SelectAll()
            End Try
        Catch ex As Exception
            MessageBox.Show("Investment Amount is missing or is not a number",
                           "Data entry error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation)
            InitialAmountTextBox.Focus()
            InitialAmountTextBox.SelectAll()
        End Try
    End Sub
    Private Sub ContinousRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContinousRadioButton.CheckedChanged
        InitialAmountTextBox.Clear()
        RateTextBox.Clear()
        CompoundedTextBox.Text = "1"
        YearsTextBox.Clear()
        AmountTextBox.Clear()
        CompoundedLabel.Visible = True
        CompoundedTextBox.Visible = True
        InitialAmountTextBox.Focus()
    End Sub
    Private Sub AnnualRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnualRadioButton.CheckedChanged
        InitialAmountTextBox.Clear()
        RateTextBox.Clear()
        CompoundedTextBox.Text = "1"
        YearsTextBox.Clear()
        AmountTextBox.Clear()
        CompoundedLabel.Visible = False
        CompoundedTextBox.Visible = False
        InitialAmountTextBox.Focus()
    End Sub
    Private Sub ClearRateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearRateButton.Click
        InitialAmountTextBox.Clear()
        RateTextBox.Clear()
        CompoundedTextBox.Text = "1"
        YearsTextBox.Clear()
        AmountTextBox.Clear()
        InitialAmountTextBox.Focus()
    End Sub




    'Quadratic formula
    Private Sub CalculateQuadraticButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateQuadraticButton.Click
        Dim A As Decimal
        Dim B As Decimal
        Dim C As Decimal
        Dim D As Double
        Dim X1 As Double
        Dim X2 As Double

        Try
            A = Decimal.Parse(Quad1TextBox.Text)
            Try
                B = Decimal.Parse(Quad2TextBox.Text)
                Try
                    C = Decimal.Parse(Quad3TextBox.Text)
                    D = (B ^ 2) - (4 * A * C)

                    If D > 0 Then
                        X1 = (-B + Math.Sqrt(D)) / (2 * A)
                        X2 = (-B - Math.Sqrt(D)) / (2 * A)
                        QuadX1TextBox.Text = X1.ToString("N4")
                        QuadX2TextBox.Text = X2.ToString("N4")
                    ElseIf D = 0 Then
                        X1 = (-B / (2 * A))
                        QuadX1TextBox.Text = X1.ToString("N4")
                        QuadX2TextBox.Text = "None"
                    Else
                        MessageBox.Show("No Real answer")
                    End If

                Catch ex As Exception
                    MessageBox.Show("Constant value is not a number",
                                   "Data entry error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation)
                    Quad3TextBox.Focus()
                    Quad3TextBox.SelectAll()
                End Try
            Catch ex As Exception
                MessageBox.Show("X value is not a number",
                               "Data entry error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
                Quad2TextBox.Focus()
                Quad2TextBox.SelectAll()
            End Try
        Catch ex As Exception
            MessageBox.Show("X^2 value is not a number",
                           "Data entry error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation)
            Quad1TextBox.Focus()
            Quad1TextBox.SelectAll()
        End Try
    End Sub
    Private Sub ClearQuadraticButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearQuadraticButton.Click
        Quad1TextBox.Clear()
        Quad2TextBox.Clear()
        Quad3TextBox.Clear()
        QuadX1TextBox.Clear()
        QuadX2TextBox.Clear()
        Quad1TextBox.Focus()
    End Sub




    'Vectors
    Private Sub CalculateVectorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateVectorButton.Click
        Dim V1 As Decimal
        Dim V2 As Decimal
        Dim V3 As Decimal
        Dim W1 As Decimal
        Dim W2 As Decimal
        Dim W3 As Decimal
        Dim Dot As Double
        Dim CrossX As Double
        Dim CrossY As Double
        Dim CrossZ As Double
        Dim MagV As Double
        Dim MagW As Double
        Dim UnitV1 As Double
        Dim UnitV2 As Double
        Dim UnitV3 As Double
        Dim UnitW1 As Double
        Dim UnitW2 As Double
        Dim UnitW3 As Double

        Try
            V1 = Decimal.Parse(V1TextBox.Text)
            Try
                V2 = Decimal.Parse(V2TextBox.Text)
                Try
                    V3 = Decimal.Parse(V3TextBox.Text)
                    Try
                        W1 = Decimal.Parse(W1TextBox.Text)
                        Try
                            W2 = Decimal.Parse(W2TextBox.Text)
                            Try
                                W3 = Decimal.Parse(W3TextBox.Text)
                                Dot = V1 * W1 + V2 * W2 + V3 * W3
                                MagV = Math.Sqrt(V1 ^ 2 + V2 ^ 2 + V3 ^ 2)
                                MagW = Math.Sqrt(W1 ^ 2 + W2 ^ 2 + W3 ^ 2)
                                UnitV1 = V1 / MagV
                                UnitV2 = V2 / MagV
                                UnitV3 = V3 / MagV
                                UnitW1 = W1 / MagW
                                UnitW2 = W2 / MagW
                                UnitW3 = W3 / MagW
                                CrossX = (V2 * W3 - V3 * W2)
                                CrossY = (V3 * W1 - V1 * W3)
                                CrossZ = (V1 * W2 - V2 * W1)

                                UnitV1TextBox.Text = UnitV1.ToString("N4")
                                UnitV2TextBox.Text = UnitV2.ToString("N4")
                                UnitV3TextBox.Text = UnitV3.ToString("N4")
                                UnitW1TextBox.Text = UnitW1.ToString("N4")
                                UnitW2TextBox.Text = UnitW2.ToString("N4")
                                UnitW3TextBox.Text = UnitW3.ToString("N4")
                                CrossXTextBox.Text = CrossX.ToString("N4")
                                CrossYTextBox.Text = CrossY.ToString("N4")
                                CrossZTextBox.Text = CrossZ.ToString("N4")
                                MagVTextBox.Text = MagV.ToString("N4")
                                MagWTextBox.Text = MagW.ToString("N4")
                                DotVecTextBox.Text = Dot.ToString("N4")
                            Catch ex As Exception
                                MessageBox.Show("K component for Vector W is not a number")
                                W3TextBox.Focus()
                                W3TextBox.SelectAll()
                            End Try
                        Catch ex As Exception
                            MessageBox.Show("J component for Vector W is not a number")
                            W2TextBox.Focus()
                            W2TextBox.SelectAll()
                        End Try
                    Catch ex As Exception
                        MessageBox.Show("I component for Vector W is not a number")
                        W1TextBox.Focus()
                        W1TextBox.SelectAll()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("K component for Vector V is not a number")
                    V3TextBox.Focus()
                    V3TextBox.SelectAll()
                End Try

            Catch ex As Exception
                MessageBox.Show("J component for Vector V is not a number")
                V2TextBox.Focus()
                V2TextBox.SelectAll()
            End Try
        Catch ex As Exception
            MessageBox.Show("I component for Vector V is not a number")
            V1TextBox.Focus()
            V1TextBox.SelectAll()
        End Try

    End Sub

    Private Sub ClearVectorsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearVectorsButton.Click
        V1TextBox.Clear()
        V2TextBox.Clear()
        V3TextBox.Clear()
        W1TextBox.Clear()
        W2TextBox.Clear()
        W3TextBox.Clear()
        UnitV1TextBox.Clear()
        UnitV2TextBox.Clear()
        UnitV3TextBox.Clear()
        UnitW1TextBox.Clear()
        UnitW2TextBox.Clear()
        UnitW3TextBox.Clear()
        CrossXTextBox.Clear()
        CrossYTextBox.Clear()
        CrossZTextBox.Clear()
        MagVTextBox.Clear()
        MagWTextBox.Clear()
        DotVecTextBox.Clear()
        V1TextBox.Focus()
    End Sub

    Private Sub Length2DTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Length2DTextBox.TextChanged

    End Sub
End Class
