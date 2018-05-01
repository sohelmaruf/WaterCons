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
    public class AdminBusinessService
    {

        IAdminDataService _AdminDataService;

        private IAdminDataService AdminDataService
        {
            get { return _AdminDataService; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AdminBusinessService(IAdminDataService dataService)
        {
            _AdminDataService = dataService;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="passwordConfirmation"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public user RegisterUser(string firstName, string lastName, string userName, string emailAddress, string password, string passwordConfirmation, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();   
         
            AdminBusinessRules adminBusinessRules = new AdminBusinessRules();

            user user = new user();

            try
            {
             
                user.FirstName = WebUtils.UppercaseFirstLetter(firstName.Trim());
                user.LastName = WebUtils.UppercaseFirstLetter(lastName.Trim());
                user.EmailAddress = emailAddress.Trim();
                user.Password = password.Trim();
                user.UserName = userName.Trim();

                AdminDataService.CreateSession();

                adminBusinessRules.ValidateUser(user, AdminDataService);
                adminBusinessRules.ValidatePassword(password, passwordConfirmation);

                if (adminBusinessRules.ValidationStatus == true)
                {
                    AdminDataService.BeginTransaction();
                    AdminDataService.RegisterUser(user);
                    AdminDataService.CommitTransaction(true);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("User registered successfully.");              
                }
                else
                {
                    transaction.ReturnStatus = adminBusinessRules.ValidationStatus;
                    transaction.ReturnMessage = adminBusinessRules.ValidationMessage;
                    transaction.ValidationErrors = adminBusinessRules.ValidationErrors;
                }             
            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                AdminDataService.CloseSession();
            }

            return user;

        }


        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="passwordConfirmation"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public user UpdateUser(int userID, string firstName, string lastName,
            string userName, string emailAddress, string password, string passwordConfirmation, 
            out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            AdminBusinessRules adminBusinessRules = new AdminBusinessRules();

            user user = new user();

            try
            {

                AdminDataService.CreateSession();

                user = AdminDataService.GetUser(userID);
                user.FirstName = firstName.Trim();
                user.LastName = lastName.Trim();
                user.EmailAddress = emailAddress.Trim();
                user.Password = password.Trim();
                user.UserName = userName.Trim();

                adminBusinessRules.ValidateExistingUser(user, AdminDataService);
                adminBusinessRules.ValidatePassword(password, passwordConfirmation);

                if (adminBusinessRules.ValidationStatus == true)
                {
                    AdminDataService.BeginTransaction();
                    AdminDataService.UpdateUser(user);
                    AdminDataService.CommitTransaction(true);
                    transaction.ReturnStatus = true;                  
                }
                else
                {
                    transaction.ReturnStatus = adminBusinessRules.ValidationStatus;
                    transaction.ReturnMessage = adminBusinessRules.ValidationMessage;
                    transaction.ValidationErrors = adminBusinessRules.ValidationErrors;
                }
            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                AdminDataService.CloseSession();
            }

            return user;

        }
        
        
        /// <summary>
        /// Login 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public user Login(string userName, string password, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            AdminBusinessRules adminBusinessRules = new AdminBusinessRules();

            user user = new user();

            try
            {

                user.UserName = userName.Trim();
                user.Password = password.Trim();

                AdminDataService.CreateSession();
                user = AdminDataService.Login(userName, password);

                if (user!=null)              
                {
                    AdminDataService.BeginTransaction();
                    AdminDataService.UpdateLastLogin(user);
                    AdminDataService.CommitTransaction(true);
                    transaction.ReturnStatus = true;                 
                }
                else
                {
                    transaction.ReturnStatus = false;
                    transaction.ReturnMessage.Add("Invalid Login.");                   
                }
            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                AdminDataService.CloseSession();
            }

            return user;

        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public user GetUser(int userID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            AdminBusinessRules adminBusinessRules = new AdminBusinessRules();

            user user = new user();

            try
            {

                AdminDataService.CreateSession();
                user = AdminDataService.GetUser(userID);

                if (user != null)
                {                   
                    transaction.ReturnStatus = true;
                }
                else
                {
                    transaction.ReturnStatus = false;
                    transaction.ReturnMessage.Add("user id not found.");
                }
            }
            catch (Exception ex)
            {
                WebUtils.TransactionException(transaction, ex);
            }
            finally
            {
                AdminDataService.CloseSession();
            }

            return user;

        }

    }
}
