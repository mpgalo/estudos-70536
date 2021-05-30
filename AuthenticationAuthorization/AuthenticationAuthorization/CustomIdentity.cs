using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Principal;

namespace AuthenticationAuthorization
{
    //Para as funcionalidades básicas de IIdentity poderia usar GenericIdentity
    class CustomIdentity : IIdentity
    {
        // Implement private variables for standard properties
        private bool isAuthenticated;
        private string name, authenticationType;
        // Implement private variables for custom properties
        private string firstName, lastName, address, city, state, zip;

        // Allow the creation of an empty object
        public CustomIdentity()
        {
            this.name = String.Empty;
            this.isAuthenticated = false;
            this.authenticationType = "None";
            this.firstName = String.Empty;
            this.lastName = String.Empty;
            this.address = String.Empty;
            this.city = String.Empty;
            this.state = String.Empty;
            this.zip = String.Empty;
        }

        // Allow caller to create the object and specify all properties
        public CustomIdentity(bool isLogin, string newAuthenticationType,
        string newFirstName,
        string newLastName, string newAddress, string newCity,
        string newState, string newZip)
        {
            // Create a unique username by concatenating first and last name
            this.name = newFirstName + newLastName;
            this.isAuthenticated = isLogin;
            this.authenticationType = newAuthenticationType;
            this.firstName = newFirstName;
            this.lastName = newLastName;
            this.address = newAddress;
            this.city = newCity;
            this.state = newState;
            this.zip = newZip;
        }

        // Implement public read-only interfaces for standard properties
        public bool IsAuthenticated
        { get { return this.isAuthenticated; } }
        public string Name
        { get { return this.name; } }
        public string AuthenticationType
        { get { return this.authenticationType; } }
        // Implement public, read-only interfaces for custom properties
        public string FirstName
        { get { return this.firstName; } }
        public string LastName
        { get { return this.lastName; } }
        public string Address
        { get { return this.address; } }
        public string City
        { get { return this.city; } }
        public string State
        { get { return this.state; } }
        public string Zip
        { get { return this.zip; } }
    }
}
