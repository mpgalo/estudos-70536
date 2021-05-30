Class Person

    Public name As String

    Public dateOfBirth As DateTime

    Public age As Integer

    Public Sub New(ByVal _name As String, ByVal _dateOfBirth As DateTime)
        MyBase.New()
        name = _name
        dateOfBirth = _dateOfBirth
        CalculateAge()
    End Sub

    Public Sub New()
        MyBase.New()

    End Sub

    Public Overrides Function ToString() As String
        Return (name + (" was born on " _
                    + (dateOfBirth.ToShortDateString + (" and is " _
                    + (age.ToString + " years old.")))))
    End Function

    Private Sub CalculateAge()
        age = (DateTime.Now.Year - dateOfBirth.Year)

        ' If they haven't had their birthday this year, 
        ' subtract a year from their age
        If (dateOfBirth.AddYears((DateTime.Now.Year - dateOfBirth.Year)) > DateTime.Now) Then
            age = (age - 1)
        End If
    End Sub

End Class
