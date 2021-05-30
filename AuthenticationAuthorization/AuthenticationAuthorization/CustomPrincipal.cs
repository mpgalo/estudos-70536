using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace AuthenticationAuthorization
{
    //Para as funcionalidades básicas de IPrincipal poderia usar GenericPrincipal
    class CustomPrincipal : IPrincipal
    {
        private IIdentity _identity;
        private string[] _roles;
        // Allow caller to create the object and specify all properties
        public CustomPrincipal(IIdentity identity, string[] roles)
        {
            _identity = identity;
            _roles = new string[roles.Length];
            roles.CopyTo(_roles, 0);
            Array.Sort(_roles);
        }

        public IIdentity Identity
        { get { return _identity; } }

        public bool IsInRole(string role)
        { return Array.BinarySearch(_roles, role) >= 0 ? true : false; }
    }
}
