﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.DatabaseHostService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DatabaseConnectionStatus", Namespace="http://schemas.datacontract.org/2004/07/FinanceServices.Enum")]
    public enum DatabaseConnectionStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IsOpen = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IsClose = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DatabaseStatus", Namespace="http://schemas.datacontract.org/2004/07/FinanceServices.Enum")]
    public enum DatabaseStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IsWaiting = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IsWorking = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DatabaseHostService.IDatabaseService", CallbackContract=typeof(Client.DatabaseHostService.IDatabaseServiceCallback))]
    public interface IDatabaseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/Connect", ReplyAction="http://tempuri.org/IDatabaseService/ConnectResponse")]
        int Connect(int ApplicationHashCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/Connect", ReplyAction="http://tempuri.org/IDatabaseService/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(int ApplicationHashCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/Disconnect", ReplyAction="http://tempuri.org/IDatabaseService/DisconnectResponse")]
        void Disconnect(int ApplicationHashCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/Disconnect", ReplyAction="http://tempuri.org/IDatabaseService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int ApplicationHashCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/GetDatabaseConnectionStatus", ReplyAction="http://tempuri.org/IDatabaseService/GetDatabaseConnectionStatusResponse")]
        Client.DatabaseHostService.DatabaseConnectionStatus GetDatabaseConnectionStatus();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/GetDatabaseConnectionStatus", ReplyAction="http://tempuri.org/IDatabaseService/GetDatabaseConnectionStatusResponse")]
        System.Threading.Tasks.Task<Client.DatabaseHostService.DatabaseConnectionStatus> GetDatabaseConnectionStatusAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/GetDatabaseStatus", ReplyAction="http://tempuri.org/IDatabaseService/GetDatabaseStatusResponse")]
        Client.DatabaseHostService.DatabaseStatus GetDatabaseStatus();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseService/GetDatabaseStatus", ReplyAction="http://tempuri.org/IDatabaseService/GetDatabaseStatusResponse")]
        System.Threading.Tasks.Task<Client.DatabaseHostService.DatabaseStatus> GetDatabaseStatusAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDatabaseService/DataCallBack")]
        void DataCallBack(string obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseServiceChannel : Client.DatabaseHostService.IDatabaseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseServiceClient : System.ServiceModel.DuplexClientBase<Client.DatabaseHostService.IDatabaseService>, Client.DatabaseHostService.IDatabaseService {
        
        public DatabaseServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DatabaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DatabaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect(int ApplicationHashCode) {
            return base.Channel.Connect(ApplicationHashCode);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(int ApplicationHashCode) {
            return base.Channel.ConnectAsync(ApplicationHashCode);
        }
        
        public void Disconnect(int ApplicationHashCode) {
            base.Channel.Disconnect(ApplicationHashCode);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int ApplicationHashCode) {
            return base.Channel.DisconnectAsync(ApplicationHashCode);
        }
        
        public Client.DatabaseHostService.DatabaseConnectionStatus GetDatabaseConnectionStatus() {
            return base.Channel.GetDatabaseConnectionStatus();
        }
        
        public System.Threading.Tasks.Task<Client.DatabaseHostService.DatabaseConnectionStatus> GetDatabaseConnectionStatusAsync() {
            return base.Channel.GetDatabaseConnectionStatusAsync();
        }
        
        public Client.DatabaseHostService.DatabaseStatus GetDatabaseStatus() {
            return base.Channel.GetDatabaseStatus();
        }
        
        public System.Threading.Tasks.Task<Client.DatabaseHostService.DatabaseStatus> GetDatabaseStatusAsync() {
            return base.Channel.GetDatabaseStatusAsync();
        }
    }
}
