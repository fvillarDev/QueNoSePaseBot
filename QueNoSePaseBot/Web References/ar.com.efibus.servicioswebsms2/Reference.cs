﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace QueNoSePaseBot.ar.com.efibus.servicioswebsms2 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicioWebHorariosProximosSoap", Namespace="http://serviciosWebSms2.efibus.com.ar/")]
    public partial class ServicioWebHorariosProximos : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RecuperarHorarioProgramadoPorParadaOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecuperarHorarioProximoPorParadaOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecuperarHorarioParadaInteligenteAndroiOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecuperarHorarioInspectoresOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecuperarHorarioCuandoLlegaAndroidOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecuperarMarkesinaCuandoLlegaAndroidPorUserIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback RecuperarVersionDBSQLiteVigenteAndroidOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServicioWebHorariosProximos() {
            this.Url = global::QueNoSePaseBot.Properties.Settings.Default.Bot_Application1_ar_com_efibus_servicioswebsms2_ServicioWebHorariosProximos;
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
        public event RecuperarHorarioProgramadoPorParadaCompletedEventHandler RecuperarHorarioProgramadoPorParadaCompleted;
        
        /// <remarks/>
        public event RecuperarHorarioProximoPorParadaCompletedEventHandler RecuperarHorarioProximoPorParadaCompleted;
        
        /// <remarks/>
        public event RecuperarHorarioParadaInteligenteAndroiCompletedEventHandler RecuperarHorarioParadaInteligenteAndroiCompleted;
        
        /// <remarks/>
        public event RecuperarHorarioInspectoresCompletedEventHandler RecuperarHorarioInspectoresCompleted;
        
        /// <remarks/>
        public event RecuperarHorarioCuandoLlegaAndroidCompletedEventHandler RecuperarHorarioCuandoLlegaAndroidCompleted;
        
        /// <remarks/>
        public event RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompletedEventHandler RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompleted;
        
        /// <remarks/>
        public event RecuperarVersionDBSQLiteVigenteAndroidCompletedEventHandler RecuperarVersionDBSQLiteVigenteAndroidCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarHorarioProgramadoPorParada", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarHorarioProgramadoPorParada(string gatewayId, string dn, string source, string mensajeUsuario, string carrier, string applidId, string userId, string usuario, string clave, int codigoEmpresa) {
            object[] results = this.Invoke("RecuperarHorarioProgramadoPorParada", new object[] {
                        gatewayId,
                        dn,
                        source,
                        mensajeUsuario,
                        carrier,
                        applidId,
                        userId,
                        usuario,
                        clave,
                        codigoEmpresa});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarHorarioProgramadoPorParadaAsync(string gatewayId, string dn, string source, string mensajeUsuario, string carrier, string applidId, string userId, string usuario, string clave, int codigoEmpresa) {
            this.RecuperarHorarioProgramadoPorParadaAsync(gatewayId, dn, source, mensajeUsuario, carrier, applidId, userId, usuario, clave, codigoEmpresa, null);
        }
        
        /// <remarks/>
        public void RecuperarHorarioProgramadoPorParadaAsync(string gatewayId, string dn, string source, string mensajeUsuario, string carrier, string applidId, string userId, string usuario, string clave, int codigoEmpresa, object userState) {
            if ((this.RecuperarHorarioProgramadoPorParadaOperationCompleted == null)) {
                this.RecuperarHorarioProgramadoPorParadaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarHorarioProgramadoPorParadaOperationCompleted);
            }
            this.InvokeAsync("RecuperarHorarioProgramadoPorParada", new object[] {
                        gatewayId,
                        dn,
                        source,
                        mensajeUsuario,
                        carrier,
                        applidId,
                        userId,
                        usuario,
                        clave,
                        codigoEmpresa}, this.RecuperarHorarioProgramadoPorParadaOperationCompleted, userState);
        }
        
        private void OnRecuperarHorarioProgramadoPorParadaOperationCompleted(object arg) {
            if ((this.RecuperarHorarioProgramadoPorParadaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarHorarioProgramadoPorParadaCompleted(this, new RecuperarHorarioProgramadoPorParadaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarHorarioProximoPorParada", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarHorarioProximoPorParada(string identificadorParada, string userId) {
            object[] results = this.Invoke("RecuperarHorarioProximoPorParada", new object[] {
                        identificadorParada,
                        userId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarHorarioProximoPorParadaAsync(string identificadorParada, string userId) {
            this.RecuperarHorarioProximoPorParadaAsync(identificadorParada, userId, null);
        }
        
        /// <remarks/>
        public void RecuperarHorarioProximoPorParadaAsync(string identificadorParada, string userId, object userState) {
            if ((this.RecuperarHorarioProximoPorParadaOperationCompleted == null)) {
                this.RecuperarHorarioProximoPorParadaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarHorarioProximoPorParadaOperationCompleted);
            }
            this.InvokeAsync("RecuperarHorarioProximoPorParada", new object[] {
                        identificadorParada,
                        userId}, this.RecuperarHorarioProximoPorParadaOperationCompleted, userState);
        }
        
        private void OnRecuperarHorarioProximoPorParadaOperationCompleted(object arg) {
            if ((this.RecuperarHorarioProximoPorParadaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarHorarioProximoPorParadaCompleted(this, new RecuperarHorarioProximoPorParadaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarHorarioParadaInteligenteAndroi", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarHorarioParadaInteligenteAndroi(string identificadorParada, string userId, string usuario, string clave) {
            object[] results = this.Invoke("RecuperarHorarioParadaInteligenteAndroi", new object[] {
                        identificadorParada,
                        userId,
                        usuario,
                        clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarHorarioParadaInteligenteAndroiAsync(string identificadorParada, string userId, string usuario, string clave) {
            this.RecuperarHorarioParadaInteligenteAndroiAsync(identificadorParada, userId, usuario, clave, null);
        }
        
        /// <remarks/>
        public void RecuperarHorarioParadaInteligenteAndroiAsync(string identificadorParada, string userId, string usuario, string clave, object userState) {
            if ((this.RecuperarHorarioParadaInteligenteAndroiOperationCompleted == null)) {
                this.RecuperarHorarioParadaInteligenteAndroiOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarHorarioParadaInteligenteAndroiOperationCompleted);
            }
            this.InvokeAsync("RecuperarHorarioParadaInteligenteAndroi", new object[] {
                        identificadorParada,
                        userId,
                        usuario,
                        clave}, this.RecuperarHorarioParadaInteligenteAndroiOperationCompleted, userState);
        }
        
        private void OnRecuperarHorarioParadaInteligenteAndroiOperationCompleted(object arg) {
            if ((this.RecuperarHorarioParadaInteligenteAndroiCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarHorarioParadaInteligenteAndroiCompleted(this, new RecuperarHorarioParadaInteligenteAndroiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarHorarioInspectores", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarHorarioInspectores(string identificadorParada, string userId, string usuario, string clave) {
            object[] results = this.Invoke("RecuperarHorarioInspectores", new object[] {
                        identificadorParada,
                        userId,
                        usuario,
                        clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarHorarioInspectoresAsync(string identificadorParada, string userId, string usuario, string clave) {
            this.RecuperarHorarioInspectoresAsync(identificadorParada, userId, usuario, clave, null);
        }
        
        /// <remarks/>
        public void RecuperarHorarioInspectoresAsync(string identificadorParada, string userId, string usuario, string clave, object userState) {
            if ((this.RecuperarHorarioInspectoresOperationCompleted == null)) {
                this.RecuperarHorarioInspectoresOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarHorarioInspectoresOperationCompleted);
            }
            this.InvokeAsync("RecuperarHorarioInspectores", new object[] {
                        identificadorParada,
                        userId,
                        usuario,
                        clave}, this.RecuperarHorarioInspectoresOperationCompleted, userState);
        }
        
        private void OnRecuperarHorarioInspectoresOperationCompleted(object arg) {
            if ((this.RecuperarHorarioInspectoresCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarHorarioInspectoresCompleted(this, new RecuperarHorarioInspectoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarHorarioCuandoLlegaAndroid", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarHorarioCuandoLlegaAndroid(string identificadorParada, string userId, string descripcionLinea, string usuario, string clave, string codigoLineaGrupo) {
            object[] results = this.Invoke("RecuperarHorarioCuandoLlegaAndroid", new object[] {
                        identificadorParada,
                        userId,
                        descripcionLinea,
                        usuario,
                        clave,
                        codigoLineaGrupo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarHorarioCuandoLlegaAndroidAsync(string identificadorParada, string userId, string descripcionLinea, string usuario, string clave, string codigoLineaGrupo) {
            this.RecuperarHorarioCuandoLlegaAndroidAsync(identificadorParada, userId, descripcionLinea, usuario, clave, codigoLineaGrupo, null);
        }
        
        /// <remarks/>
        public void RecuperarHorarioCuandoLlegaAndroidAsync(string identificadorParada, string userId, string descripcionLinea, string usuario, string clave, string codigoLineaGrupo, object userState) {
            if ((this.RecuperarHorarioCuandoLlegaAndroidOperationCompleted == null)) {
                this.RecuperarHorarioCuandoLlegaAndroidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarHorarioCuandoLlegaAndroidOperationCompleted);
            }
            this.InvokeAsync("RecuperarHorarioCuandoLlegaAndroid", new object[] {
                        identificadorParada,
                        userId,
                        descripcionLinea,
                        usuario,
                        clave,
                        codigoLineaGrupo}, this.RecuperarHorarioCuandoLlegaAndroidOperationCompleted, userState);
        }
        
        private void OnRecuperarHorarioCuandoLlegaAndroidOperationCompleted(object arg) {
            if ((this.RecuperarHorarioCuandoLlegaAndroidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarHorarioCuandoLlegaAndroidCompleted(this, new RecuperarHorarioCuandoLlegaAndroidCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarMarkesinaCuandoLlegaAndroidPorUser" +
            "Id", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarMarkesinaCuandoLlegaAndroidPorUserId(string userId, string usuario, string clave) {
            object[] results = this.Invoke("RecuperarMarkesinaCuandoLlegaAndroidPorUserId", new object[] {
                        userId,
                        usuario,
                        clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarMarkesinaCuandoLlegaAndroidPorUserIdAsync(string userId, string usuario, string clave) {
            this.RecuperarMarkesinaCuandoLlegaAndroidPorUserIdAsync(userId, usuario, clave, null);
        }
        
        /// <remarks/>
        public void RecuperarMarkesinaCuandoLlegaAndroidPorUserIdAsync(string userId, string usuario, string clave, object userState) {
            if ((this.RecuperarMarkesinaCuandoLlegaAndroidPorUserIdOperationCompleted == null)) {
                this.RecuperarMarkesinaCuandoLlegaAndroidPorUserIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarMarkesinaCuandoLlegaAndroidPorUserIdOperationCompleted);
            }
            this.InvokeAsync("RecuperarMarkesinaCuandoLlegaAndroidPorUserId", new object[] {
                        userId,
                        usuario,
                        clave}, this.RecuperarMarkesinaCuandoLlegaAndroidPorUserIdOperationCompleted, userState);
        }
        
        private void OnRecuperarMarkesinaCuandoLlegaAndroidPorUserIdOperationCompleted(object arg) {
            if ((this.RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompleted(this, new RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://serviciosWebSms2.efibus.com.ar/RecuperarVersionDBSQLiteVigenteAndroid", RequestNamespace="http://serviciosWebSms2.efibus.com.ar/", ResponseNamespace="http://serviciosWebSms2.efibus.com.ar/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RecuperarVersionDBSQLiteVigenteAndroid(string userId, string usuario, string clave) {
            object[] results = this.Invoke("RecuperarVersionDBSQLiteVigenteAndroid", new object[] {
                        userId,
                        usuario,
                        clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RecuperarVersionDBSQLiteVigenteAndroidAsync(string userId, string usuario, string clave) {
            this.RecuperarVersionDBSQLiteVigenteAndroidAsync(userId, usuario, clave, null);
        }
        
        /// <remarks/>
        public void RecuperarVersionDBSQLiteVigenteAndroidAsync(string userId, string usuario, string clave, object userState) {
            if ((this.RecuperarVersionDBSQLiteVigenteAndroidOperationCompleted == null)) {
                this.RecuperarVersionDBSQLiteVigenteAndroidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRecuperarVersionDBSQLiteVigenteAndroidOperationCompleted);
            }
            this.InvokeAsync("RecuperarVersionDBSQLiteVigenteAndroid", new object[] {
                        userId,
                        usuario,
                        clave}, this.RecuperarVersionDBSQLiteVigenteAndroidOperationCompleted, userState);
        }
        
        private void OnRecuperarVersionDBSQLiteVigenteAndroidOperationCompleted(object arg) {
            if ((this.RecuperarVersionDBSQLiteVigenteAndroidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RecuperarVersionDBSQLiteVigenteAndroidCompleted(this, new RecuperarVersionDBSQLiteVigenteAndroidCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarHorarioProgramadoPorParadaCompletedEventHandler(object sender, RecuperarHorarioProgramadoPorParadaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarHorarioProgramadoPorParadaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarHorarioProgramadoPorParadaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarHorarioProximoPorParadaCompletedEventHandler(object sender, RecuperarHorarioProximoPorParadaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarHorarioProximoPorParadaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarHorarioProximoPorParadaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarHorarioParadaInteligenteAndroiCompletedEventHandler(object sender, RecuperarHorarioParadaInteligenteAndroiCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarHorarioParadaInteligenteAndroiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarHorarioParadaInteligenteAndroiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarHorarioInspectoresCompletedEventHandler(object sender, RecuperarHorarioInspectoresCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarHorarioInspectoresCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarHorarioInspectoresCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarHorarioCuandoLlegaAndroidCompletedEventHandler(object sender, RecuperarHorarioCuandoLlegaAndroidCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarHorarioCuandoLlegaAndroidCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarHorarioCuandoLlegaAndroidCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompletedEventHandler(object sender, RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarMarkesinaCuandoLlegaAndroidPorUserIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RecuperarVersionDBSQLiteVigenteAndroidCompletedEventHandler(object sender, RecuperarVersionDBSQLiteVigenteAndroidCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RecuperarVersionDBSQLiteVigenteAndroidCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RecuperarVersionDBSQLiteVigenteAndroidCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591