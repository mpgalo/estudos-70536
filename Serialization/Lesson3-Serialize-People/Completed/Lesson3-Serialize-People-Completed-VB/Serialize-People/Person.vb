Imports System.Runtime.Serialization

<Serializable()> Class Person
    Implements ISerializable

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

    Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        name = info.GetString("Name")
        dateOfBirth = info.GetDateTime("DOB")
        CalculateAge()
    End Sub

    Public Overridable Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        info.AddValue("Name", name)
        info.AddValue("DOB", dateOfBirth)
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
