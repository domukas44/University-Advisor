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

namespace UniversityAdvisor.Droid.SubjectWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="SubjectServiceSoap", Namespace="http://www.xamarin.com/webservices/")]
    public partial class SubjectService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetSubjectsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSubjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateSubjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback EditSubjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteSubjectOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SubjectService() {
            this.Url = "http://192.168.43.11:58092/SubjectService.asmx";
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
        public event GetSubjectsCompletedEventHandler GetSubjectsCompleted;
        
        /// <remarks/>
        public event GetSubjectCompletedEventHandler GetSubjectCompleted;
        
        /// <remarks/>
        public event CreateSubjectCompletedEventHandler CreateSubjectCompleted;
        
        /// <remarks/>
        public event EditSubjectCompletedEventHandler EditSubjectCompleted;
        
        /// <remarks/>
        public event DeleteSubjectCompletedEventHandler DeleteSubjectCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/GetSubjects", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Subject[] GetSubjects() {
            object[] results = this.Invoke("GetSubjects", new object[0]);
            return ((Subject[])(results[0]));
        }
        
        /// <remarks/>
        public void GetSubjectsAsync() {
            this.GetSubjectsAsync(null);
        }
        
        /// <remarks/>
        public void GetSubjectsAsync(object userState) {
            if ((this.GetSubjectsOperationCompleted == null)) {
                this.GetSubjectsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSubjectsOperationCompleted);
            }
            this.InvokeAsync("GetSubjects", new object[0], this.GetSubjectsOperationCompleted, userState);
        }
        
        private void OnGetSubjectsOperationCompleted(object arg) {
            if ((this.GetSubjectsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSubjectsCompleted(this, new GetSubjectsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/GetSubject", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Subject GetSubject(string name) {
            object[] results = this.Invoke("GetSubject", new object[] {
                        name});
            return ((Subject)(results[0]));
        }
        
        /// <remarks/>
        public void GetSubjectAsync(string name) {
            this.GetSubjectAsync(name, null);
        }
        
        /// <remarks/>
        public void GetSubjectAsync(string name, object userState) {
            if ((this.GetSubjectOperationCompleted == null)) {
                this.GetSubjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSubjectOperationCompleted);
            }
            this.InvokeAsync("GetSubject", new object[] {
                        name}, this.GetSubjectOperationCompleted, userState);
        }
        
        private void OnGetSubjectOperationCompleted(object arg) {
            if ((this.GetSubjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSubjectCompleted(this, new GetSubjectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/CreateSubject", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CreateSubject(Subject subject) {
            this.Invoke("CreateSubject", new object[] {
                        subject});
        }
        
        /// <remarks/>
        public void CreateSubjectAsync(Subject subject) {
            this.CreateSubjectAsync(subject, null);
        }
        
        /// <remarks/>
        public void CreateSubjectAsync(Subject subject, object userState) {
            if ((this.CreateSubjectOperationCompleted == null)) {
                this.CreateSubjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateSubjectOperationCompleted);
            }
            this.InvokeAsync("CreateSubject", new object[] {
                        subject}, this.CreateSubjectOperationCompleted, userState);
        }
        
        private void OnCreateSubjectOperationCompleted(object arg) {
            if ((this.CreateSubjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateSubjectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/EditSubject", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void EditSubject(Subject subject) {
            this.Invoke("EditSubject", new object[] {
                        subject});
        }
        
        /// <remarks/>
        public void EditSubjectAsync(Subject subject) {
            this.EditSubjectAsync(subject, null);
        }
        
        /// <remarks/>
        public void EditSubjectAsync(Subject subject, object userState) {
            if ((this.EditSubjectOperationCompleted == null)) {
                this.EditSubjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEditSubjectOperationCompleted);
            }
            this.InvokeAsync("EditSubject", new object[] {
                        subject}, this.EditSubjectOperationCompleted, userState);
        }
        
        private void OnEditSubjectOperationCompleted(object arg) {
            if ((this.EditSubjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EditSubjectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.xamarin.com/webservices/DeleteSubject", RequestNamespace="http://www.xamarin.com/webservices/", ResponseNamespace="http://www.xamarin.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteSubject(int id) {
            this.Invoke("DeleteSubject", new object[] {
                        id});
        }
        
        /// <remarks/>
        public void DeleteSubjectAsync(int id) {
            this.DeleteSubjectAsync(id, null);
        }
        
        /// <remarks/>
        public void DeleteSubjectAsync(int id, object userState) {
            if ((this.DeleteSubjectOperationCompleted == null)) {
                this.DeleteSubjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteSubjectOperationCompleted);
            }
            this.InvokeAsync("DeleteSubject", new object[] {
                        id}, this.DeleteSubjectOperationCompleted, userState);
        }
        
        private void OnDeleteSubjectOperationCompleted(object arg) {
            if ((this.DeleteSubjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteSubjectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class Subject {
        
        private int idField;
        
        private string nameField;
        
        private double ratingField;
        
        private int reviewCountField;
        
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
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public double Rating {
            get {
                return this.ratingField;
            }
            set {
                this.ratingField = value;
            }
        }
        
        /// <remarks/>
        public int ReviewCount {
            get {
                return this.reviewCountField;
            }
            set {
                this.reviewCountField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetSubjectsCompletedEventHandler(object sender, GetSubjectsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSubjectsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSubjectsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Subject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Subject[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetSubjectCompletedEventHandler(object sender, GetSubjectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSubjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSubjectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Subject Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Subject)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void CreateSubjectCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void EditSubjectCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void DeleteSubjectCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591