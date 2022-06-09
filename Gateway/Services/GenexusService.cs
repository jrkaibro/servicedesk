using System;
using System.Collections.Generic;
using Artech.Architecture.BL.Framework.Services;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Services;
using Artech.Architecture.Common.Services.TeamDev;
using Artech.Architecture.Common.Services.TeamDevData.Client;
using Artech.Architecture.UI.Framework.Services;
using Artech.Common.Exceptions;
using Artech.Common.Helpers.Identity;
using Artech.Common.Tracing;
using Artech.Udm.Framework;
using ServiceDesk.Gateway.Interfaces;
using ServiceDesk.Gateway.WsGenexusDemanda;
using ServiceDesk.Gateway.WsGenexusSolucao;
using ServiceDesk.Gateway.WsGenexusUpdateDemanda;

namespace ServiceDesk.Gateway.Services
{
    public class GenexusService : IGenexusService
    {
        private readonly WS_Servdesk_Commit _wsServdeskCommit;
        private readonly ws_servdesk_demanda _wsServdeskDemanda;
        private readonly ws_servdesk_demanda_objetos _wsServdeskDemandaObjetos;
        private ITeamDevClientUpdate _mUpdateTask;
        private List<TeamDevUpdateItem> _listaUpdateItems;
        private Boolean _retornoUpdate;
        private string _comentario = string.Empty;
        private List<KBObjectHistory> _objetosComitados = new List<KBObjectHistory>();

        public GenexusService()
        {
            _wsServdeskCommit = new WS_Servdesk_Commit();
            _wsServdeskDemanda = new ws_servdesk_demanda();
            _wsServdeskDemandaObjetos = new ws_servdesk_demanda_objetos();                     
        }

        public Boolean EnviarSolucaoObjetos(string codDemanda, string comentario, string solucao)
        {
            var versao = GetVersaoKb();

            return _wsServdeskCommit.Execute(codDemanda, comentario, versao, solucao);
        }

        public string BuscarDemandaCommit(string nomeUsuario, int codDemanda = 0, int skip = 0)
        {
            return _wsServdeskDemanda.Execute(nomeUsuario, codDemanda);
        }

        public string GetLinkGenexusServer()
        {
            var kb = UIServices.KB.CurrentKB;

            return BLServices.TeamDevClient.GetServerUrl(kb);
        }

        public IEnumerable<KBObjectHistory> GetListaObjetosModificados()
        {
            var model = UIServices.KB.CurrentModel;
            
            return BLServices.TeamDevClient.GetLocalChanges(model); //.Where(s => s.Username == currentUser);
        }

        public string GetUsuario()
        {
            var currentUser = IdentityHelper.CurrentUser;
            var array = currentUser.Split('\\');
            return array[1];
        }

        public string GetVersaoKb()
        {
            var model = UIServices.KB.CurrentModel;

            return BLServices.TeamDevClient.RemoteVersionName(model);
        }

        public Boolean RealizarLockDosObjetos()
        {
            var model = UIServices.KB.CurrentModel;
            BLServices.TeamDevClient.RemoveLockKbObject(model, new EntityKey(new Guid(), 12));
            
            return false;
        }

        #region Commit

        public Boolean RealizarCommit(Object comentario, List<KBObjectHistory> objetosModificados)
        {
            _comentario = comentario.ToString();
            _objetosComitados = objetosModificados;
            bool retorno;

            try
            {
                retorno = CommitWorker();
            }
            catch (Exception ex)
            {
                CommonServices.Output.AddErrorLine(ex.Message);
                TraceManager.Error("Could not commit objects", ex);
                return false;                
            }

            return retorno;
        }

        private Boolean CommitWorker()
        {
            CommonServices.Output.SelectOutput("Team Development");
            CommonServices.Output.Show("Team Development");

            var sendChangesData1 = new SendChangesData
            {
                Model = UIServices.KB.CurrentModel,
                Comments = _comentario,
                ObjectList = _objetosComitados,
                User = IdentityHelper.CurrentUser,
                Options = ExportOptions.Default
            };

            return UIServices.TeamDevClient.SendChanges(sendChangesData1);
        }
        
        #endregion

        #region Update

        public string BuscarDemandaUpdate(string codDemanda)
        {
            return _wsServdeskDemandaObjetos.Execute(codDemanda);
        }

        public ITeamDevClientUpdate BuscarObjetosComitados()
        {
            UIServices.TeamDevClient.CheckForBrokenCommits();
            var receiveChangesData1 = new ReceiveChangesData
            {
                Model = UIServices.KB.CurrentModel,
                KeepTryingOnTimeout = false,
            };
            var receiveChangesData2 = receiveChangesData1;
            var retorno = UIServices.TeamDevClient.JustReceiveChanges(ref receiveChangesData2);
            return retorno;
        }

        public Boolean RealizarUpdate(ITeamDevClientUpdate task, List<TeamDevUpdateItem> items)
        {
            _mUpdateTask = task;
            _listaUpdateItems = items;

            try
            {
                _retornoUpdate = _mUpdateTask.Update(_listaUpdateItems);
            }
            catch (Exception ex)
            {
                _retornoUpdate = false;
                CommonServices.Output.AddErrorLine(ex.Message);
                ExceptionManager.HandleException(ex);
            }

            return _retornoUpdate;
        }
        
        #endregion

    }
}
