﻿using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services.AuthServices;
using SimpleTraderApp.WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }


        private Account _currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            try
            {
                this.CurrentAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            this.CurrentAccount = null;
        }

        public async Task<RegisterResult> Register(string emailId, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(emailId, username, password, confirmPassword);
        }
    }
}