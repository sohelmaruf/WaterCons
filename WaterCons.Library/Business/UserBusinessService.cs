﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WaterCons.Library.Models;
using WaterCons.Library.Interfaces;
using WaterCons.Library.Common;

namespace WaterCons.Library.Business
{
    public class UserBusinessService
    {
        IUserDataService _UserDataService;

        private IUserDataService UsersDataService
        {
            get { return _UserDataService; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserBusinessService(IUserDataService dataService)
        {
            _UserDataService = dataService;
        }
        
        public user AddUser(Nullable<int> clientID, string userName, string firstName, string lastName, string password, string passwordConfirmation, string emailAddress, string defaultPage, 
            string role, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            UserBusinessRules userRules = new UserBusinessRules();

            user objUser = new user();

            try
            {
                objUser.ClientID = clientID;
                objUser.UserName = userName;
                objUser.FirstName = firstName;
                objUser.LastName = lastName;
                objUser.Password = password;
                objUser.EmailAddress = emailAddress;
                objUser.DefaultPage = defaultPage;
                objUser.DateCreated = System.DateTime.Now;
                objUser.DateUpdated = System.DateTime.Now;
                objUser.DateLastLogin = System.DateTime.Now;
                objUser.Role = role;
                objUser.IsActive = true;

                UsersDataService.CreateSession();

                UsersDataService.BeginTransaction();
                UsersDataService.AddUser(objUser);
                UsersDataService.CommitTransaction(true);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("User added successfully.");
            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                UsersDataService.CloseSession();
            }

            return objUser;

        }


        public user UpdateUser(int ID, int clientID, string userName, string firstName, string lastName, string password, string emailAddress, string defaultPage,
            out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();


            user objUser = new user();

            try
            {

                UsersDataService.CreateSession();

                objUser = UsersDataService.GetUser(ID);

                objUser.ClientID = clientID;
                objUser.UserName = userName;
                objUser.FirstName = firstName;
                objUser.LastName = lastName;
                objUser.Password = password;
                objUser.EmailAddress = emailAddress;
                objUser.DefaultPage = defaultPage;
                objUser.DateUpdated = System.DateTime.Now;
                objUser.DateLastLogin = System.DateTime.Now;


                UsersDataService.BeginTransaction();
                UsersDataService.UpdateUser(objUser);
                UsersDataService.CommitTransaction(true);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("User updated successfully.");

            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                UsersDataService.CloseSession();
            }

            return objUser;
        }


        public user GetUser(int UserID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            user objUser = new user();

            try
            {

                UsersDataService.CreateSession();
                objUser = UsersDataService.GetUser(UserID);

                if (objUser != null)
                {
                    transaction.ReturnStatus = true;
                }
                else
                {
                    transaction.ReturnStatus = false;
                    transaction.ReturnMessage.Add("User id not found.");
                }
            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                UsersDataService.CloseSession();
            }

            return objUser;
        }

    }
}
