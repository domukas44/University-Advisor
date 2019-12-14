﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace UniversityAdvisor.Droid.ReviewWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ReviewServiceSoap", Namespace="http://www.xamarin.com/webservices/")]
    public partial class ReviewService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetReviewsOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateReviewOperationCompleted;
        
        private System.Threading.SendOrPostCallback EditReviewOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteReviewOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ReviewService() {
            this.Url = "http://192.168.1.42:59379/ReviewService.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetReviewsCompletedEventHandler GetReviewsCompleted;
        
        /// <remarks/>
        public event CreateReviewCompletedEventHandler CreateReviewCompleted;
        
        /// <remarks/>
        public event EditReviewCompletedEventHandler EditReviewCompleted;
        
        /// <remarks/>
        public event DeleteReviewCompletedEventHandler DeleteReviewCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/GetReviews", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Review[] GetReviews() {
            object[] results = this.Invoke("GetReviews", new object[0]);
            return ((Review[])(results[0]));
        }
        
        /// <remarks/>
        public void GetReviewsAsync() {
            this.GetReviewsAsync(null);
        }
        
        /// <remarks/>
        public void GetReviewsAsync(object userState) {
            if ((this.GetReviewsOperationCompleted == null)) {
                this.GetReviewsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetReviewsOperationCompleted);
            }
            this.InvokeAsync("GetReviews", new object[0], this.GetReviewsOperationCompleted, userState);
        }
        
        private void OnGetReviewsOperationCompleted(object arg) {
            if ((this.GetReviewsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetReviewsCompleted(this, new GetReviewsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/CreateReview", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CreateReview(Review review) {
            this.Invoke("CreateReview", new object[] {
                        review});
        }
        
        /// <remarks/>
        public void CreateReviewAsync(Review review) {
            this.CreateReviewAsync(review, null);
        }
        
        /// <remarks/>
        public void CreateReviewAsync(Review review, object userState) {
            if ((this.CreateReviewOperationCompleted == null)) {
                this.CreateReviewOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateReviewOperationCompleted);
            }
            this.InvokeAsync("CreateReview", new object[] {
                        review}, this.CreateReviewOperationCompleted, userState);
        }
        
        private void OnCreateReviewOperationCompleted(object arg) {
            if ((this.CreateReviewCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateReviewCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/EditReview", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void EditReview(Review review) {
            this.Invoke("EditReview", new object[] {
                        review});
        }
        
        /// <remarks/>
        public void EditReviewAsync(Review review) {
            this.EditReviewAsync(review, null);
        }
        
        /// <remarks/>
        public void EditReviewAsync(Review review, object userState) {
            if ((this.EditReviewOperationCompleted == null)) {
                this.EditReviewOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEditReviewOperationCompleted);
            }
            this.InvokeAsync("EditReview", new object[] {
                        review}, this.EditReviewOperationCompleted, userState);
        }
        
        private void OnEditReviewOperationCompleted(object arg) {
            if ((this.EditReviewCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EditReviewCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/DeleteReview", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteReview(int id) {
            this.Invoke("DeleteReview", new object[] {
                        id});
        }
        
        /// <remarks/>
        public void DeleteReviewAsync(int id) {
            this.DeleteReviewAsync(id, null);
        }
        
        /// <remarks/>
        public void DeleteReviewAsync(int id, object userState) {
            if ((this.DeleteReviewOperationCompleted == null)) {
                this.DeleteReviewOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteReviewOperationCompleted);
            }
            this.InvokeAsync("DeleteReview", new object[] {
                        id}, this.DeleteReviewOperationCompleted, userState);
        }
        
        private void OnDeleteReviewOperationCompleted(object arg) {
            if ((this.DeleteReviewCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteReviewCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.xamarin.com/webservices/")]
    public partial class Review {
        
        private int idField;
        
        private string subjectNameField;
        
        private string authorField;
        
        private string commentField;
        
        private int ratingField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string SubjectName {
            get {
                return this.subjectNameField;
            }
            set {
                this.subjectNameField = value;
            }
        }
        
        /// <remarks/>
        public string Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        public string Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
            }
        }
        
        /// <remarks/>
        public int Rating {
            get {
                return this.ratingField;
            }
            set {
                this.ratingField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetReviewsCompletedEventHandler(object sender, GetReviewsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetReviewsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetReviewsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Review[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Review[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void CreateReviewCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void EditReviewCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void DeleteReviewCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591