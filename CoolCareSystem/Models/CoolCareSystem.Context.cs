﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoolCareSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CoolCareSystemEntities : DbContext
    {
        public CoolCareSystemEntities()
            : base("name=CoolCareSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
    
        public virtual int AddUser(string firstName, string lastName, string emailAddress, Nullable<decimal> mobileNumber, string userName, string password)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var mobileNumberParameter = mobileNumber.HasValue ?
                new ObjectParameter("MobileNumber", mobileNumber) :
                new ObjectParameter("MobileNumber", typeof(decimal));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", firstNameParameter, lastNameParameter, emailAddressParameter, mobileNumberParameter, userNameParameter, passwordParameter);
        }
    
        public virtual int ApproveProduct(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ApproveProduct", idParameter);
        }
    
        public virtual int ApproveService(Nullable<int> id, Nullable<int> workerId, Nullable<decimal> price)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var workerIdParameter = workerId.HasValue ?
                new ObjectParameter("WorkerId", workerId) :
                new ObjectParameter("WorkerId", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ApproveService", idParameter, workerIdParameter, priceParameter);
        }
    
        public virtual ObjectResult<CheckUserCredentials_Result> CheckUserCredentials(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckUserCredentials_Result>("CheckUserCredentials", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<GetAllProducts_Result> GetAllProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProducts_Result>("GetAllProducts");
        }
    
        public virtual ObjectResult<GetAllProductsForUser_Result> GetAllProductsForUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductsForUser_Result>("GetAllProductsForUser");
        }
    
        public virtual ObjectResult<GetAllServices_Result> GetAllServices()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllServices_Result>("GetAllServices");
        }
    
        public virtual ObjectResult<GetAllServicesStatus_Result> GetAllServicesStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllServicesStatus_Result>("GetAllServicesStatus");
        }
    
        public virtual ObjectResult<GetProductById_Result> GetProductById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductById_Result>("GetProductById", idParameter);
        }
    
        public virtual ObjectResult<GetProductsByUserId_Result> GetProductsByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductsByUserId_Result>("GetProductsByUserId", userIdParameter);
        }
    
        public virtual ObjectResult<GetServiceById_Result> GetServiceById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetServiceById_Result>("GetServiceById", idParameter);
        }
    
        public virtual ObjectResult<GetServicesByUserId_Result> GetServicesByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetServicesByUserId_Result>("GetServicesByUserId", userIdParameter);
        }
    
        public virtual ObjectResult<GetUserDetails_Result> GetUserDetails(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserDetails_Result>("GetUserDetails", usernameParameter);
        }
    
        public virtual int InsertImage(Nullable<int> id, string imageName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var imageNameParameter = imageName != null ?
                new ObjectParameter("ImageName", imageName) :
                new ObjectParameter("ImageName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertImage", idParameter, imageNameParameter);
        }
    
        public virtual int InsertProduct(Nullable<int> userId, string producName, string description, Nullable<int> billedYear, Nullable<decimal> price, ObjectParameter returnId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var producNameParameter = producName != null ?
                new ObjectParameter("ProducName", producName) :
                new ObjectParameter("ProducName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var billedYearParameter = billedYear.HasValue ?
                new ObjectParameter("BilledYear", billedYear) :
                new ObjectParameter("BilledYear", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertProduct", userIdParameter, producNameParameter, descriptionParameter, billedYearParameter, priceParameter, returnId);
        }
    
        public virtual int UpdateProductAvailable(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProductAvailable", idParameter);
        }
    
        public virtual int UpdateServiceStatus(Nullable<int> id, string status, Nullable<decimal> price)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateServiceStatus", idParameter, statusParameter, priceParameter);
        }
    
        public virtual int UpdateUserProfile(Nullable<int> id, string firstName, string lastName, string emailAddress, Nullable<decimal> mobileNumber, string userName, string password)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var mobileNumberParameter = mobileNumber.HasValue ?
                new ObjectParameter("MobileNumber", mobileNumber) :
                new ObjectParameter("MobileNumber", typeof(decimal));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUserProfile", idParameter, firstNameParameter, lastNameParameter, emailAddressParameter, mobileNumberParameter, userNameParameter, passwordParameter);
        }
    
        public virtual int RateService(Nullable<int> id, Nullable<int> rating)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var ratingParameter = rating.HasValue ?
                new ObjectParameter("Rating", rating) :
                new ObjectParameter("Rating", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RateService", idParameter, ratingParameter);
        }
    
        public virtual int InsertService(Nullable<int> userId, string producName, string serviceIssue)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var producNameParameter = producName != null ?
                new ObjectParameter("ProducName", producName) :
                new ObjectParameter("ProducName", typeof(string));
    
            var serviceIssueParameter = serviceIssue != null ?
                new ObjectParameter("ServiceIssue", serviceIssue) :
                new ObjectParameter("ServiceIssue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertService", userIdParameter, producNameParameter, serviceIssueParameter);
        }
    
        public virtual ObjectResult<GetReports_Result> GetReports(Nullable<int> month, Nullable<int> year)
        {
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetReports_Result>("GetReports", monthParameter, yearParameter);
        }
    }
}